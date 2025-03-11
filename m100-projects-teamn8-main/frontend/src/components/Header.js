import React, { useState, useEffect } from "react";
import { FaLongArrowAltRight } from "react-icons/fa";
import { FaAngleRight } from "react-icons/fa";
import { MdDownload } from "react-icons/md";
import { Link, useNavigate } from "react-router-dom";

const Header = () => {
  const [deferredPrompt, setDeferredPrompt] = useState(null);
  const [isInstallable, setIsInstallable] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    // Listen for the 'beforeinstallprompt' event
    const handleBeforeInstallPrompt = (event) => {
      event.preventDefault();
      setDeferredPrompt(event);
      setIsInstallable(true); // Enable the Download button
    };

    window.addEventListener("beforeinstallprompt", handleBeforeInstallPrompt);

    return () => {
      window.removeEventListener(
        "beforeinstallprompt",
        handleBeforeInstallPrompt
      );
    };
  }, []);

  const handleDownloadClick = async () => {
    if (deferredPrompt) {
      deferredPrompt.prompt(); // Show the install prompt
      const { outcome } = await deferredPrompt.userChoice; // Wait for user response
      if (outcome === "accepted") {
        console.log("App installed");
      } else {
        console.log("App installation dismissed");
      }
      setDeferredPrompt(null); // Clear the deferred prompt
    }
  };
  const handleLogout = () => {
    localStorage.removeItem("authToken"); // Remove the auth token
    navigate("/"); // Redirect the user to the login page
  };

  return (
    <div className="header">
      <div className="lft-header">
        <div className="city-btn">
          <FaLongArrowAltRight className="arrow" />
          <h3>&nbsp;&nbsp;Citymapper&nbsp;&nbsp;</h3>
        </div>
        {isInstallable && (
          <div className="btn-app" onClick={handleDownloadClick}>
            <MdDownload />
            Download
          </div>
        )}
      </div>
      <div className="rgt-header">
        <span className="btn-app" onClick={handleLogout}>
          Logout
          <FaAngleRight />
        </span>
        {/* <button className="btn-app" onClick={handleLogout}>
          Logout <FaAngleRight />
        </button> */}
      </div>
    </div>
  );
};

export default Header;
