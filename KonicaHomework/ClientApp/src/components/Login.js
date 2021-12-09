import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
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
            if (response.data === "") {
                alert("Wrong username or password!");
                return;
            }
            else {
                let user = response.data;
                if (user.inactive === true) {
                    alert("Inactive user!");
                }
                else {
                    localStorage.setItem("id", user.id);
                    localStorage.setItem("username", user.username);
                    setLoggedIn(true);
                }
                return;
            }
        });
    }

    if (loggedIn) {
        return <Redirect to="/" />;
    }

    return (
        <div>
            {localStorage.getItem("id") !== null && (
                <h1>You are already logged in!</h1>
            )}
            {localStorage.getItem("id") === null && (
                <>
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
                </>

            )}
        </div>
    );
}

export default Login;

