import React, { Component } from 'react';
import axios from 'axios';
import './reviewStyle.css';
import { ReviewList } from './review-list.component';
//import '../Game-Detail/gameDetail.css';

export class ReviewForm extends Component {

    constructor(props) {
        super(props);
        this.state = {
           Rating: 1,
            Review: '',
           ReviewList:[]
        };

        //click handlers.
        this.handleSubmission = this.handleSubmission.bind(this);
        this.ReviewChangeHandler = this.ReviewChangeHandler.bind(this);
        this.RatingHandler = this.RatingHandler.bind(this);
    }

    //get the review from the database and save in the state.

    componentDidMount() {
        let gameId = window.location.href.split('/')[4];
        
        fetch("https://localhost:5001/api/Reviews/getreviews")
            .then(response => response.json())
            .then(data => this.setState({
                ReviewList: data.filter(item => item.gameId == gameId)
            }));
    }

    RatingHandler(event) {
        this.setState({
            Rating: event.target.value
        });
    }

    ReviewChangeHandler(event) {
        this.setState({
            Review: event.target.value
        });
    }

    handleSubmission(event) {
        event.preventDefault();

        //get the login user from the cookie...
        let profile = document.cookie.match(new RegExp('(^| )' + 'userId' + '=([^;]+)'));
        let data = {};

        //data being saved
        if (profile != null) {

            profile = profile[2].split(',');

             data = {
                AccountId: profile[0],
                GameId: this.props.game.gameId,
                ReviewInfo: this.state.Review,
                RatingValue: parseInt(this.state.Rating)
            };
        }
        else {
            data = {
              
                AccountId: 'Guest',
                GameId: this.props.game.gameId,
                ReviewInfo: this.state.Review,
                RatingValue: parseInt(this.state.Rating)
            };
            console.log(data);
        }
        //config the header
        const config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };

        ////post request to the backend----
        axios.post("https://localhost:5001/api/Reviews/", JSON.stringify(data), config).then(res => {
        alert('Your review has successfully been added.');
        });

    }

    calculateAverage() {
        let reviewList = this.state.ReviewList;
        var result = 0;

        for (var i = 0; i < reviewList.length; i++) {
            result += reviewList[i].ratingValue;
        }
        return (result / reviewList.length).toFixed(2);
    }

    render() {        
        return (
                <div id="Review_Wrapper">
                    <div id="Written_Review">
                        <h3>Write A Review</h3>
                        <form method='POST' onSubmit={this.handleSubmission}>
                            <div>
                                <select id='rating_value' onChange={this.RatingHandler} onSubmit={this.handleSubmission}>
                                    <option selected value="1">1 Stars</option>
                                    <option value="2">2 Stars</option>
                                    <option value="3">3 Stars</option>
                                    <option value="4">4 Stars</option>
                                    <option value="5">5 Starts</option>
                                 </select>
                            </div>
                            <textarea name="review-comment" value={this.state.Review} onChange={this.ReviewChangeHandler} rows='5' required></textarea>
                            <input type="submit" name="submit" value="submit review"/>
                        </form>
                        
                    </div>
                <div id="review-list-main-page">
                    <div id="review-title-average">
                        <h3>Review</h3>
                        <h4>{this.calculateAverage()} out of 5</h4>
                    </div>
                        {this.state.ReviewList.map(reviews => (
                            <ReviewList key={reviews.reviewId} reviews={reviews} />
                        ))}
                    </div>
               </div>
            );
    }
}