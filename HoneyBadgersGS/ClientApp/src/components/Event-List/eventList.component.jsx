import React from 'react';
import './eventList.component.css';
import { EventCard } from '../Event-Card/event-card.component';

//Creates event list using cards
export const EventList = props =>(
    <div className='card-list'>
        {props.events.map(events=>(
            <EventCard key={events.id} events={events}/>
        ))}
    </div>
);