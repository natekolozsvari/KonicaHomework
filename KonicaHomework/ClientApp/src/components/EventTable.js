import React, { Component, useEffect, useState } from 'react';

const EventTable = ({ events }) => {
    return (
        <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    {events.map(event =>
                        <tr key={event.eventId}>
                            <td>{event.title}</td>
                            <td>{new Date(event.happenedAt).toLocaleString()}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}

export default EventTable;