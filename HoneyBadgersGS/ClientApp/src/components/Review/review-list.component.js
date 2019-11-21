import React from 'react';
import './reviewStyle.css';

export const ReviewList = props => {
    return (
        <div className="review-list">
            <div id="rating-list-heading">
                <p>User: {props.reviews.accountId}</p>
                <p id="rating">Rating: {props.reviews.ratingValue}/5</p>
            </div>
            <div id='rating-list-body'>
                <p id="review">{props.reviews.reviewInfo}</p>
            </div>
        </div>
    );
};