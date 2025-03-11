from typing import List
from fastapi import FastAPI
from flask import Flask, request, jsonify
from GraphHandler import GraphHandler
from pydantic import BaseModel
import matplotlib.pyplot as plt
import osmnx as ox
import numpy as np

graph_handler = GraphHandler()
app = FastAPI()
#graph_handler.load_raster_data("RasterData\\cluj_treecover2020.tif", 20)
#graph_handler.load_raster_data("RasterData\\cluj_grassland.tif", 10)
#graph_handler.load_landmarks("Data\\parks.json", 1500, -0.05)
#graph_handler.set_default_values()
#graph_handler.load_waze("https://www.waze.com/row-partnerhub-api/partners/11315398994/waze-feeds/d15f3f75-64f0-4455-8bdd-a9b1fc1d1d44?format=1")

class RouteRequest(BaseModel):
    start: List[float]
    end: List[float]


@app.post("/route")
def generate_route(request: RouteRequest):
    route = graph_handler.generate_route(request.start, request.end)
    route_coords = [
        {"latitude": graph_handler.graph.nodes[node]['y'], "longitude": graph_handler.graph.nodes[node]['x']}
        for node in route
    ]
    return {"route": route_coords}

# start = ox.distance.nearest_nodes(graph_handler.graph, 23.577730194693775, 46.78269778420891)
# end = ox.distance.nearest_nodes(graph_handler.graph, 23.547689937011032, 46.75212660772752)
# route = ox.shortest_path(graph_handler.graph, start, end)
# fig, ax = ox.plot_graph_route(graph_handler.graph, route, route_color="green")