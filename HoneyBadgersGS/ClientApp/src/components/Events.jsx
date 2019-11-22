/* eslint-disable no-undef */
import React, { Component } from 'react';
import './Events.css';
import { EventList } from './Event-List/eventList.component';

export class Event extends Component {
	constructor() {
		super();
		this.state = {
			events: []
		};
	}
	componentDidMount() {
		axios
			.get('https://localhost:5001/api/Events/getevents')
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
