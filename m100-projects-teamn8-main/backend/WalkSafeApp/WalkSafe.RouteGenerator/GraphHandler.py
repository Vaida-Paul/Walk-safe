import osmnx as ox
import networkx as nx
import os
import json
import numpy
import requests
import rasterio
from shapely.geometry import Point, LineString
from geopy.distance import geodesic
import geopandas as gpd

class GraphHandler:
    def __init__(self):
        self.graph = None
        if os.path.exists("cluj_graph.graphml"):
            self.graph = self.load_graph()
            #self.revert_default_weights()
            print("Loaded Graph")
        else:
            self.graph = self.generate_graph("Cluj-Napoca, Cluj, Romania")
            self.set_default_values()
            print("Generated Graph")
    
    @staticmethod
    def generate_graph(city: str):
        graph = ox.graph_from_place(city, network_type="walk")
        ox.save_graphml(graph, "cluj_graph.graphml")
        return graph
    
    @staticmethod
    def load_graph():
        return ox.load_graphml("cluj_graph.graphml")
    
    def load_landmarks(self, path: str, radius: int, decay: float):
        with open(path, "r") as file:
            landmarks = json.load(file)
        for landmark in landmarks["features"]:
            lat, long = landmark["geometry"]["coordinates"]
            edges = self.get_edges_workaround([lat, long], radius)
            for (u, v, key, data), distance in edges:
                if data["length"] == 1:
                    continue
                factor = 1 - (1/(1 + numpy.exp(decay * (distance * 3/4))))
                new_length = self.graph[u][v][key]["length"] -  factor * self.graph[u][v][key]["length"]
                self.graph[u][v][key]["length"] = max(new_length, 1)
        ox.save_graphml(self.graph, "cluj_graph.graphml")
        print("Data Loaded.\n")

    def load_waze(self, link: str):
        alerts_location = []
        response = requests.get(link)
        if response.status_code == 200:
            data = response.json()
            with open("Data\\waze_data.json", "w+") as file:
                json.dump(data, file, indent=4)
                alerts = json.load(file)
                for alert in alerts["alerts"]:
                    if alert["subtype"] in ["JAM_HEAVY_TRAFFIC", "HAZARD_ON_ROAD_CONSTRUCTION"]:
                        [y, x] = alert["location"]["x"], alert["location"]["y"]
                        alerts_location.append([x, y])
                alert_x = numpy.array(alerts_location[:][0])
                alert_y = numpy.array(alerts_location[:][1])
                edges = ox.distance.nearest_edges(self.graph, alert_x, alert_y)
                for (u, v, key) in edges:
                    if self.graph.has_edge(u, v, key):
                        #self.graph[u][v][key]["default_value"] = int(self.graph[u][v][key]["length"])
                        self.graph[u][v][key]["length"] *= 10000
                ox.save_graphml(self.graph, "cluj_graph.graphml")
        else:
            print("Bad request.\n")
    
    def revert_default_weights(self):
        for u, v, data in self.graph.edges(data=True):
            if float(data["default_value"]) != float(data["length"]):
                data["length"] = float(data["default_value"])
            ox.save_graphml(self.graph, "cluj_graph.graphml")
            
    def set_default_values(self):
        for u, v, data in self.graph.edges(data=True):
            data["length"] = int(data["length"])
            data["default_value"] = int(data["length"])
        ox.save_graphml(self.graph, "cluj_graph.graphml")
    
    def load_raster_data(self, path, percentage):
        points = []
        factor = percentage / 100
        dataset = rasterio.open(path)
        band1 = dataset.read(1)
        nodes_gdf, edges_gdf = ox.graph_to_gdfs(self.graph)
        bounds = nodes_gdf.total_bounds # [west ,south, east, north]
        row_start, col_start = dataset.index(bounds[0], bounds[3])
        row_end, col_end = dataset.index(bounds[2], bounds[1])
        for i in range(row_start, row_end+1):
            for j in range(col_start, col_end+1):
                if band1[i][j] != 0:
                    x, y = dataset.xy(i ,j)
                    points.append([float(x), float(y)])
        #print(points[:10])
        point_x = numpy.array(points[:][0])
        point_y = numpy.array(points[:][1])
        edges = ox.distance.nearest_edges(self.graph, point_x, point_y)
        for u, v, key in edges:
            edge_length = self.graph[u][v][key]["length"]
            new_length = max(1, edge_length - factor * edge_length)  # Ensure min length = 1
            self.graph[u][v][key]["length"] = new_length
        ox.save_graphml(self.graph, "cluj_graph.graphml")
        
    def generate_route(self, point1, point2):
        start_node = ox.distance.nearest_nodes(self.graph, X=point1[1], Y=point1[0])
        end_node = ox.distance.nearest_nodes(self.graph, X=point2[1], Y=point2[0])
        return ox.shortest_path(self.graph, start_node, end_node)
    
    def get_edges_workaround(self, point, radius):
        edges_with_distances = []
        point_geom = Point(point[0], point[1])  # Convert to (lon, lat) format for Shapely

        for u, v, key, data in self.graph.edges(keys=True, data=True):
            # Get the geometry of the edge
            edge_geom = data.get("geometry")
            if not edge_geom:  # If no geometry, create a LineString from nodes
                u_coords = (self.graph.nodes[u]['x'], self.graph.nodes[u]['y'])
                v_coords = (self.graph.nodes[v]['x'], self.graph.nodes[v]['y'])
                edge_geom = LineString([Point(u_coords[0], u_coords[1]), Point(v_coords[0], v_coords[1])])
        
            # Calculate the shortest distance from the point to the edge in meters
            distance_meters = int(point_geom.distance(edge_geom) * 111320)  # Convert degrees to meters

            # Check if the edge is within the radius
            if distance_meters <= radius:
                edges_with_distances.append(((u, v, key, data), distance_meters))
                #print(distance_meters)
        return edges_with_distances