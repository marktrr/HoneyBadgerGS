import React from 'react';
import { Link } from 'react-router-dom';
import './event-card.component.css';

export const EventCard = (props) => {
	return (
		<Link to={'/Details/' + props.events.eventId}>
			<div className="event-card">
				<p>{props.events.eventName}</p>
			</div>
		</Link>
	);
};
