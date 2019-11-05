import React from 'react';

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