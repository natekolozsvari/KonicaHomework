import React, { Component, useEffect, useState } from 'react';
import { Link } from "react-router-dom";




const DocumentTable = ({ documents }) => {

    return (
        <div>
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
                            <td><Link to={`/document/${document.id}`}>{document.title}</Link></td>
                            <td>{document.extension}</td>
                            <td>{document.source}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}

export default DocumentTable;