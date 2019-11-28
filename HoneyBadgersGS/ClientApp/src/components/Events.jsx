/* eslint-disable no-undef */
import React, { Component } from 'react';
import './Events.css';
import axios from 'axios';
import { EventList } from './Event-List/eventList.component';
import { HoneyBadgerUrl } from 'C:\dev\NUNUHoney\HoneyBadgerGS\HoneyBadgersGS\ClientApp\src\Constants.jsx';


export class Event extends Component {
	constructor() {
		super();
		this.state = {
			events: []
		};
	}
	componentDidMount() {
        axios
            .get(HoneyBadgerUrl + '/api/Events/getevents')
			.then((res) => {
				const events = res.data;
				this.setState({ events });
				console.log(res.data);
			})
			.catch((error) => {
				if (error.response) {
					console.log(error.response.data);
				}
			});
	}
	render() {
		return (
			<div class="event-method">
				<EventList>events={this.state.events}</EventList>
			</div>
		);
	}
}
