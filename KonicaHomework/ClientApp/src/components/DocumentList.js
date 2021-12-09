import React, { Component, useEffect, useState } from 'react';
import { ReactSession } from 'react-client-session';
import { Link } from "react-router-dom";
import DocumentTable from "./DocumentTable";
import SearchForm from "./SearchForm";
import axios from "axios";



const DocumentList = ({ }) => {
    const [searchTerm, setSearchTerm] = useState("");
    const [documents, setDocuments] = useState([]);

    useEffect(() => {
        axios('/api/documents')
            .then(response => {
                setDocuments(response.data);
            })
    }, [])

    const search = (searchTerm) => {
        axios(`/api/documents/search?query=${searchTerm}`)
            .then(response => {
                setDocuments(response.data);
            })
    }


    return (
        <div>
            {localStorage.getItem("id") === null && (
                <h1>Log in to view documents!</h1>
            )}
            {localStorage.getItem("id") !== null && (
                <div>
                    <div style={{display: "inline-flex", width: "100%", justifyContent: "space-between"}}>
                        <h1 style={{ paddingBottom: "20px" }}>Documents</h1>
                        <div style={{paddingTop: "10px"}}>
                            <SearchForm search={search}/>
                        </div>
                    </div>
                    <DocumentTable documents={documents}/>
                </div>
            )}
        </div>
    );
}

export default DocumentList;