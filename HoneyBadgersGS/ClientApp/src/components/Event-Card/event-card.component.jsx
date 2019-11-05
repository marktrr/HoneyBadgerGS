import React from 'react';
import './event-card.component.css';

export const eventCard = props =>{
    return (
        <div className="event-card">
            <p>{props.event.eventId}</p>
            <p>{props.events.eventName}</p>
            <p>{props.events.eventDetails}</p>
        </div>
    );
};