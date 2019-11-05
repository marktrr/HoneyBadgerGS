import React from 'react';
import { Link } from 'react-router-dom';
import './event-card.component.css';

export const eventCard = props =>{
    return (
        <div className="event-card">
            <p>{props.events.eventName}</p>
            <p>{props.events.eventDetails}</p>
        </div>
    );
};