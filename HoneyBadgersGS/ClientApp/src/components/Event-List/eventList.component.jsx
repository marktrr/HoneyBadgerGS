import React from 'react';
import ReactDOM from 'react-dom';
import './eventList.component.css';

function EventList(props)
{
    const events = props.events;
    const eventItems = events.map((events) =>
    <li>{events}</li>
    );
    return (
        <ul>{eventItems}</ul>
    );
    
}