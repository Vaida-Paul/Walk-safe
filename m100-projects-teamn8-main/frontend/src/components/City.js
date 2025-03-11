import React from "react";
import boy from "../images/romanian.png";

const City = () => {
  return (
    <div className="city-description">
      <div className="city-description-lft">
        <img src={boy} alt="boy" className="boy-image" />
      </div>
      <h1>Cluj-Napoca</h1>
    </div>
  );
};
export default City;
