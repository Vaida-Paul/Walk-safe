import "./App.css";
import Header from "./components/Header.js";
import City from "./components/City.js";
import GridView from "./components/GridView.js";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import Register from "./components/Register";
import ErrorPage from "./components/ErrorPage";
import Login from "./components/Login";
import logo from "./images/logo.svg";
import Main from "./components/Main.js";

function App() {
  return (
    <div className="main">
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/main" element={<Main />} />
          <Route path="*" element={<ErrorPage />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
