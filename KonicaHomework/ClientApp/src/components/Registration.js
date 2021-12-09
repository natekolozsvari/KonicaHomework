import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from "axios";
import { Redirect } from "react-router";

const Registration = () => {
    const [userData, setUserData] = useState({
        Username: "",
        Password: ""
    });
    const [newUser, setNewUser] = useState(false);

    const handleChange = (e) => {
        setUserData({ ...userData, [e.target.name]: e.target.value });
    } 

    async function handleSubmit(e) {
        e.preventDefault();
        const exists = await checkIfExists();
        if (exists) {
            alert("Username already exists.");
        } else {
            axios.post('/api/user', userData);
            alert("Successfully registered.");
            setNewUser(true);
        }
    }

    async function checkIfExists() {
        return axios(`/api/user/exists/${userData.Username}`)
            .then(response => {
                return response.data;
            })
    }

    if (newUser) {
        return <Redirect to="/" />;
    }

    return (
        <div>
            {localStorage.getItem("id") !== null && (
                <h1>You are already logged in!</h1>
            )}
            {localStorage.getItem("id") === null && (
                <>
                    <h1 style={{ paddingBottom: "20px" }}>Registration</h1>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Username</Form.Label>
                            <Form.Control type="text" name="Username" placeholder="Username" onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" name="Password" placeholder="Password" onChange={handleChange} />
                        </Form.Group>
                        <Button variant="primary" type="submit">
                            Register
                </Button>
                    </Form>
                </>
            )}
        </div>
    );
}

export default Registration;

