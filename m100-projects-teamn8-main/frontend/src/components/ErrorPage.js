// ErrorPage.jsx
import React from "react";
import { Link } from "react-router-dom";

const ErrorPage = () => {
  return (
    <div className="error-content">
      <h1 className="error-title">404 - Page Not Found</h1>
      <p className="error-message">
        The page you’re looking for doesn’t exist, or you may not have
        permission to access it. If you’re trying to access certain features,
        make sure you’re logged in or have an account. Let’s help you get back
        on track!
      </p>
      <Link to="/" className="error-link">
        Return to Home
      </Link>
    </div>
  );
};

export default ErrorPage;
