import React, { Component } from 'react';
import axios from 'axios';
import { ReviewForm } from '../Review/review_write';
import './gameDetail.css';

export class GameDetails extends Component{

    constructor() {
        super();
        this.state = {
            //holds the selected game
            isAdd: false,
            gameDetails: [],
            //holds the cart  items
            cartItems: []
        };
    }

    //talks to the api in order to get the games by the id 
    componentDidMount() {

        let gameId = this.props.location.pathname.split('/').pop();
        fetch("https://localhost:5001/api/games/getgames/" + gameId)
            .then(response => response.json())
            .then(data => this.setState({ gameDetails: data }));
    }

    render() {
        return (
            <div className="gameDetails_TopWrapper">
                <div className="gameDetails">

                    <div className="addtoCart">
                        <img className='card-img-top' alt='game image' src={this.state.gameDetails.gameArtUrl}></img>
                        <p className="game-price">${this.state.gameDetails.price}</p>
                        <button className="btn_AddCart" onClick={() => { addElementToCart(this.state.gameDetails) }}>Add To Cart</button>
                        <button className="btn_AddWish" onClick={() => { addElementToWishlist(this.state.gameDetails) }}>Add To WishList</button>
                    </div>

                    <div className="description">
                        <h1>{this.state.gameDetails.gameName} Details</h1>
                        <p className="gameDescription">{this.state.gameDetails.gameDescription}</p>
                    </div>
                </div>
                <ReviewForm game={this.state.gameDetails} />
            </div>
        );
    }
}

function addElementToCart(stuff) {
    //create the cart item 
    let cartItems = [];
    var item = {
        itemID: stuff.gameId,
        itemImage: stuff.gameArtUrl,
        itemName: stuff.gameName,
        price: stuff.price,
        quantity: 1,
        total: stuff.price
    };

    var exist = false;

    if (sessionStorage.getItem('cart')) {
        cartItems = JSON.parse(sessionStorage.getItem('cart'));

        for (var i = 0; i < cartItems.length; i++) {
            if (cartItems[i].itemID == stuff.gameId) {
                exist = true;
                break;
            }
        }

        if (exist) {
            alert("You already added this item on the list, please do modify your Wishlist!");
        }
        else {
            //add the current item onto the cart list.
            cartItems.push(item);
            //save the cart element to local storage where it can be extracted later
            sessionStorage.setItem("cart", JSON.stringify(cartItems));
        }
    }
    else {
        //add the current item onto the cart list.
        cartItems.push(item);
        //save the cart element to local storage where it can be extracted later
        sessionStorage.setItem("cart", JSON.stringify(cartItems));
    }
}

function addElementToWishlist(stuff) {
    //create the cart item 
    let wishlist = [];
    var item = {
        wishlistId: getRandomInt(10000),
        itemID: stuff.gameId,
        itemImage: stuff.gameArtUrl,
        itemName: stuff.gameName,
        price: stuff.price
    };

    let identityAccount = document.cookie.match(new RegExp('(^| )' + 'userId' + '=([^;]+)'));
    if (identityAccount == null) {
        identityAccount = "anonymous";
    }
    else {
        identityAccount = identityAccount[2].split(',');
        identityAccount = identityAccount[0];
    } 

    var stringjson = JSON.stringify(item);

    var Object = {
        wishlistID: item.wishlistId,
        accountID: identityAccount,
        itemInfo: stringjson
    }
    var exist = false;

    if (sessionStorage.getItem('wishlist')) {
        wishlist = JSON.parse(sessionStorage.getItem('wishlist'));

        for (var i = 0; i < wishlist.length; i++) {
            if (wishlist[i].itemID == stuff.gameId) {
                exist = true;
                break;
            }
        }

        if (exist) {
            alert("You already added this item on the list, please do modify your Wishlist!");
        }
        else {
            //add the current item onto the cart list.
            wishlist.push(item);
            //save the cart element to local storage where it can be extracted later
            sessionStorage.setItem("wishlist", JSON.stringify(wishlist));
            //Add to database
            addToDB(Object);
        }
    }
    else {
        //add the current item onto the cart list.
        wishlist.push(item);
        //save the cart element to local storage where it can be extracted later
        sessionStorage.setItem("wishlist", JSON.stringify(wishlist));
        //Add to database
        addToDB(Object);
    }
}

export function addToDB(data) {
    //add to db
    axios.post("https://localhost:5001/api/Wishlists/add/", data).then(res => {
        console.log(res);
        console.log(res.data);
    });
}

//get random number
function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}


