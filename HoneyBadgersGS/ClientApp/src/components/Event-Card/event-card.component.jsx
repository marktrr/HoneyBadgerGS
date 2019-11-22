import React from 'react';
import { Link } from 'react-router-dom';
import './event-card.component.css';

export const EventCard = props =>{
    return (
        <div className="event-card">
            <p>{props.events.eventId}</p>
            <p>{props.events.eventName}</p>
            <p>{props.events.eventDetails}</p>
        </div>
    );
};
