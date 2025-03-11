import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { FaLock } from "react-icons/fa";
import { IoMdMail } from "react-icons/io";
import { IoEyeSharp, IoEyeOffSharp } from "react-icons/io5";
import api from "../api";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await api.post("/Authentication/login", {
        email,
        password,
      });
      const { token } = response.data;
      localStorage.setItem("authToken", token); // Store the token in localStorage
      navigate("/main");
      setError(""); // Clear errors
    } catch (err) {
      setError(err.response?.data || "Invalid email or password");
    }
  };

  return (
    <div className="card-log">
      <form onSubmit={handleSubmit}>
        <div className="description-card">
          <h2>
            <span className="letter-style">L</span>ogin
          </h2>
          <p>enter your account</p>
        </div>
        {error && <p className="error">{error}</p>}
        <div className="input-container-log">
          <IoMdMail className="input-icon" />
          <input
            type="text"
            value={email}
            placeholder="Email..."
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="input-container-log">
          <FaLock className="input-icon" />
          <input
            type={showPassword ? "text" : "password"}
            value={password}
            placeholder="Password..."
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          <span
            className="toggle-password"
            onClick={() => setShowPassword((prev) => !prev)}
          >
            {showPassword ? <IoEyeSharp /> : <IoEyeOffSharp />}
          </span>
        </div>
        <button type="submit" className="btn">
          Login
        </button>
        <div className="register-link-container">
          <p>
            Don't have an account?{" "}
            <Link to="/register" className="register-link">
              Register here
            </Link>
          </p>
        </div>
      </form>
    </div>
  );
};

export default Login;
