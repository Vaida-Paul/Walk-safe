import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { IoPersonSharp } from "react-icons/io5";
import { FaLock } from "react-icons/fa";
import { IoMdMail } from "react-icons/io";
import { IoEyeSharp, IoEyeOffSharp } from "react-icons/io5";
import api from "../api"; // Import the Axios instance

const Register = () => {
  const [name, setName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const navigate = useNavigate();

  const validatePassword = (password) => {
    const minLength = /.{8,}/;
    const hasTwoNumbers = /(?=.*\d.*\d)/;
    const hasSpecialChar = /[!@#$%^&*()-+<>?,./';:"]/;

    if (!minLength.test(password)) {
      return "Password must be at least 8 characters long.";
    }
    if (!hasTwoNumbers.test(password)) {
      return "Password must contain at least two numbers.";
    }
    if (!hasSpecialChar.test(password)) {
      return "Password must contain at least one special character.(Ex: ?,!,@,&..";
    }

    return "Password looks good!";
  };

  const handlePasswordChange = (e) => {
    const inputPassword = e.target.value;
    setPassword(inputPassword);

    const validationMessage = validatePassword(inputPassword);
    setPasswordError(validationMessage);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const finalValidation = validatePassword(password);
    if (finalValidation !== "Password looks good!") {
      setError(finalValidation);
      setSuccess("");
      return;
    }

    try {
      const response = await api.post("/User/register", {
        name,
        email,
        password,
      });

      const { token } = response.data;
      if (token) {
        localStorage.setItem("authToken", token);
        setSuccess("Registration successful!");
        setError("");
        navigate("/");
      } else {
        setError("Registration failed: No token received.");
      }
    } catch (err) {
      const errorMessage =
        err.response?.data?.message ||
        "Something went wrong during registration.";
      setError(errorMessage);
      setSuccess("");
    }
  };

  return (
    <div className="card-log">
      <form onSubmit={handleSubmit}>
        <div className="description-card">
          <h2>
            <span className="letter-style">R</span>egister
          </h2>
          <p>create your account</p>
        </div>

        {error && <p className="error">{error}</p>}
        {success && <p className="success">{success}</p>}

        <div className="input-container-log">
          <IoPersonSharp className="input-icon" />
          <input
            type="text"
            value={name}
            placeholder="Name..."
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div className="input-container-log">
          <IoMdMail className="input-icon" />
          <input
            type="email"
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
            onChange={handlePasswordChange}
            required
          />
          <span
            className="toggle-password"
            onClick={() => setShowPassword((prev) => !prev)}
          >
            {showPassword ? <IoEyeSharp /> : <IoEyeOffSharp />}
          </span>
        </div>

        <p
          className="password-validation"
          style={{
            color: passwordError === "Password looks good!" ? "green" : "red",
          }}
        >
          {passwordError}
        </p>

        <button type="submit" className="btn">
          Register
        </button>
        <div className="register-link-container">
          <p>
            Already have an account?{" "}
            <Link to="/" className="register-link">
              Login here
            </Link>
          </p>
        </div>
      </form>
    </div>
  );
};

export default Register;
