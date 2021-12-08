import React, { Component, useEffect, useState } from 'react';
import { ReactSession } from 'react-client-session';
import { Link, useParams } from "react-router-dom";
import DocumentTable from "./DocumentTable";
import EventTable from "./EventTable";
import axios from "axios";



const Document = ({ }) => {
    const { id }= useParams();
    const [document, setDocument] = useState({});
    const [children, setChildren] = useState([]);
    const [events, setEvents] = useState([]);

    useEffect(() => {
        axios(`/api/documents/${id}`)
            .then(response => {
                setDocument(response.data);
            })
        axios(`/api/documents/children/${id}`)
            .then(response => {
                setChildren(response.data);
            })

        axios(`/api/event/${id}`)
            .then(response => {
                setEvents(response.data);
            })
    }, [id])

    console.log(document);
    console.log(children);
    console.log(events);


    return (
        <div>
            <h1 style={{ paddingBottom: "20px" }}>{document.title}.{document.extension}</h1>
            {children.length != 0 && (
                <div>
                    <h2>Children</h2>
                    <DocumentTable documents={children}/>
                </div>
                )
            }
            <div>
                <h2>Events</h2>
                <EventTable events={events} />
            </div>
        </div>
    );
}

export default Document;