import React from 'react';
import './event-card.component.css';

export const EventCard = props =>{
    return (
        <div className="event-card">
            <p>{props.events.eventId}</p>
            <p>{props.events.eventName}</p>
            <p>{props.events.eventDate}</p>
            <p>{props.events.eventDescription}</p>
            <p>{props.events.eventLocation}</p>
        </div>
    );
};
