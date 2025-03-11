import React from "react";
import Header from "./Header";
import City from "./City";
import GridView from "./GridView";
import logo from "../images/logo.svg";

const Main = () => {
  return (
    <div>
      <Header />
      <div className="main-content">
        <City />
        <GridView />
        <image src={logo} />
      </div>
    </div>
  );
};

export default Main;
