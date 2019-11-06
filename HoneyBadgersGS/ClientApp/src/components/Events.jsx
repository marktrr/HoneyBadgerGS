import React, {Component} from 'react';
import './Events.css';
import {EventList} from './Event-List/eventList.component';

export class Event extends Component
{
    constructor()
    {
        super();
        this.state={
            events:[]
        };
    }
    componentDidMount()
    {
        fetch("https://localhost:5001/api/events/getEvents")
        .then(response => response.json())
        .then(data => this.setState({ events: data }))
            console.log(this.state.events);
    }
    render()
    {
        return(
            <div class = "event-method">
                <EventList>events={this.state.events}</EventList>
            </div>
        )
    }
}