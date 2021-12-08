import React, { Component, useEffect, useState } from 'react';
import { ReactSession } from 'react-client-session';
import axios from "axios";




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

                    <table className='table table-striped' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Title</th>
                                <th>Extension</th>
                                <th>Source</th>
                            </tr>
                        </thead>
                        <tbody>
                            {documents.map(document =>
                                <tr key={document.id}>
                                    <td>{document.id}</td>
                                    <td>{document.title}</td>
                                    <td>{document.extension}</td>
                                    <td>{document.source}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                    </div>
            )}
        </div>
    );
}

export default DocumentList;