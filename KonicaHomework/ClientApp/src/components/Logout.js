import React from 'react';
import { Redirect } from "react-router";

const Logout = () => {
    localStorage.removeItem("id");
    localStorage.removeItem("username");
    return <Redirect to="/" />;
};

export default Logout;
