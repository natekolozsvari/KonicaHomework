import React, { useEffect, useState } from 'react';
import { useParams } from "react-router-dom";
import DocumentTable from "./DocumentTable";
import EventTable from "./EventTable";
import axios from "axios";



const Document = () => {
    const { id } = useParams();
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

    return (
        <div>
            {localStorage.getItem("id") === null && (
                <h1>Log in to view the documents!</h1>
            )}
            {localStorage.getItem("id") !== null && (
                <div>
                    <h1 style={{ paddingBottom: "20px" }}>{document.title}.{document.extension}</h1>
                    {children.length !== 0 && (
                        <div>
                            <h2>Children</h2>
                            <DocumentTable documents={children} />
                        </div>
                    )}
                    <div>
                        <h2>Events</h2>
                        <EventTable events={events} />
                    </div>
                </div>
            )}
        </div>
    );
}

export default Document;