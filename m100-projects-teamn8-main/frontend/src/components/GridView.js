import React, { useState, useEffect } from "react";
import L from "leaflet";
import { FaAngleRight, FaSearchLocation } from "react-icons/fa";
import { IoLogoApple, IoLogoAndroid } from "react-icons/io";

const GridView = () => {
  const [map, setMap] = useState(null);
  const [startMarker, setStartMarker] = useState(null);
  const [endMarker, setEndMarker] = useState(null);
  const [startCoords, setStartCoords] = useState("");
  const [endCoords, setEndCoords] = useState("");
  const [activeInput, setActiveInput] = useState(null);

  // Set default Leaflet marker icons
  useEffect(() => {
    delete L.Icon.Default.prototype._getIconUrl;
    L.Icon.Default.mergeOptions({
      iconUrl:
        "https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon.png",
      iconRetinaUrl:
        "https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon-2x.png",
      shadowUrl:
        "https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-shadow.png",
    });
  }, []);

  // Initialize the map
  useEffect(() => {
    const clujCoords = [46.7712, 23.6236];
    const mapInstance = L.map("map").setView(clujCoords, 13);

    L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
      attribution: "© OpenStreetMap contributors",
    }).addTo(mapInstance);

    setMap(mapInstance);
    return () => mapInstance.remove();
  }, []);

  const handleMapClick = (e) => {
    if (!activeInput) return;

    const { lat, lng } = e.latlng;
    const coordString = `${lat}, ${lng}`;

    if (activeInput === "start") {
      setStartCoords(coordString);
      if (startMarker) map.removeLayer(startMarker);
      const marker = L.marker([lat, lng]).addTo(map);
      setStartMarker(marker);
    } else if (activeInput === "end") {
      setEndCoords(coordString);
      if (endMarker) map.removeLayer(endMarker);
      const marker = L.marker([lat, lng]).addTo(map);
      setEndMarker(marker);
    }

    setActiveInput(null);
    updateRoute();
  };

  useEffect(() => {
    if (map) {
      map.on("click", handleMapClick);
      return () => map.off("click", handleMapClick);
    }
  }, [map, activeInput]);

  const handleInputChange = (e, type) => {
    const value = e.target.value;
    if (type === "start") setStartCoords(value);
    else setEndCoords(value);
  };

  const handleInputBlur = (type) => {
    const coords = type === "start" ? startCoords : endCoords;

    try {
      const [lat, lng] = coords
        .split(",")
        .map((coord) => parseFloat(coord.trim()));

      if (isNaN(lat) || isNaN(lng)) throw new Error("Invalid coordinates");

      if (type === "start") {
        if (startMarker) map.removeLayer(startMarker);
        const marker = L.marker([lat, lng]).addTo(map);
        setStartMarker(marker);
      } else {
        if (endMarker) map.removeLayer(endMarker);
        const marker = L.marker([lat, lng]).addTo(map);
        setEndMarker(marker);
      }

      updateRoute();
    } catch (error) {
      console.error("Invalid coordinates:", error.message);
    }
  };

  const updateRoute = async () => {
    if (!map || !startCoords || !endCoords) return;

    const start = startCoords
      .split(",")
      .map((coord) => parseFloat(coord.trim()));
    const end = endCoords.split(",").map((coord) => parseFloat(coord.trim()));

    try {
      const response = await fetch(
        "https://localhost:7280/api/route/generate",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ start, end }),
        }
      );

      if (!response.ok) throw new Error("Failed to fetch route");

      const routeData = await response.json();
      const latLngs = routeData.route.map((point) => [
        point.latitude,
        point.longitude,
      ]);

      L.polyline(latLngs, { color: "#6FA1EC", weight: 4 }).addTo(map);
      map.fitBounds(L.latLngBounds(latLngs));
    } catch (error) {
      console.error("Error fetching route:", error.message);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (startCoords && endCoords) updateRoute();
  };

  const handleLabelClick = (type) => {
    setActiveInput(type);
  };

  return (
    <div className="container">
      <div className="map">
        <div
          id="map"
          style={{ height: "100%", width: "100%", borderRadius: "10px" }}
        ></div>
      </div>
      <div className="session card">
        <p>GET ME SOMEWHERE</p>
        <form className="input-form" onSubmit={handleSubmit}>
          <div className="input-container">
            <label
              htmlFor="start"
              className="input-label"
              onClick={() => handleLabelClick("start")}
              style={{ cursor: "pointer" }}
            >
              START
            </label>
            <input
              type="text"
              id="start"
              className="input-field"
              placeholder="Click label then map, or type coordinates..."
              value={startCoords}
              onChange={(e) => handleInputChange(e, "start")}
              onBlur={() => handleInputBlur("start")}
            />
          </div>
          <div className="input-container">
            <label
              htmlFor="end"
              className="input-label"
              onClick={() => handleLabelClick("end")}
              style={{ cursor: "pointer" }}
            >
              END&nbsp;&nbsp;&nbsp;&nbsp;
            </label>
            <input
              type="text"
              id="end"
              className="input-field"
              placeholder="Click label then map, or type coordinates..."
              value={endCoords}
              onChange={(e) => handleInputChange(e, "end")}
              onBlur={() => handleInputBlur("end")}
            />
          </div>
          <div className="session-options">
            <p>
              Now
              <FaAngleRight />
            </p>
            <button type="submit" className="submit-button">
              Go
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default GridView;
