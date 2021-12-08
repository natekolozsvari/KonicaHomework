import React, { Component, useEffect, useState } from 'react';
import { ReactSession } from 'react-client-session';
import { Link } from "react-router-dom";
import DocumentTable from "./DocumentTable"
import axios from "axios";


ReactSession.set("id", 1);

const DocumentList = ({}) => {
    const [documents, setDocuments] = useState([]);

    useEffect(() => {
        axios('/api/documents')
            .then(response => {
                setDocuments(response.data);
            })
    }, [])

    console.log(documents);


    return (
        <div>
            {ReactSession.get("id") == null && (
                <h1>Log in to view documents!</h1>
            )}
            {ReactSession.get("id") != null && (
                <div>
            <h1>Documents</h1>

                    <DocumentTable documents={documents}/>
                    </div>
            )}
        </div>
    );
}

export default DocumentList;