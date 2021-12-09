import React, { Component, useEffect, useState } from 'react';
import { ReactSession } from 'react-client-session';
import { Link, useParams } from "react-router-dom";
import { Form, Row, Col, Button, Label, Input } from 'react-bootstrap';
import DocumentTable from "./DocumentTable";
import EventTable from "./EventTable";
import axios from "axios";
import { Redirect } from "react-router";





const Login = () => {
    const [userData, setUserData] = useState({
        Username: "",
        Password: ""
    });
    const [loggedIn, setLoggedIn] = useState(false);


    const handleChange = (e) => {
        setUserData({ ...userData, [e.target.name]: e.target.value });
    }

    async function handleSubmit(e) {
        e.preventDefault();
        axios.post("/api/user/login", userData).then(response => {
            console.log(response.data);
            if (response.data === "") {
                alert("Wrong username or password");
                return;
            }
            else {
                let user = response.data;
                console.log(user);
                localStorage.setItem("id", user.id);
                localStorage.setItem("username", user.username);
                setLoggedIn(true);
                return;
            }
        });
    }


    if (loggedIn) {
        return <Redirect to="/" />;
    }

    return (
        <div>
            <h1 style={{ paddingBottom: "20px" }}>Log in</h1>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Username</Form.Label>
                    <Form.Control type="text" name="Username" placeholder="Username" onChange={handleChange} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" name="Password" placeholder="Password" onChange={handleChange}/>
                </Form.Group>
                <Button variant="primary" type="submit">
                    Log in
                </Button>
            </Form>
        </div>
    );
}

export default Login;

