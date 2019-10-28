import React, { Component } from 'react';
import './gameDetail.css';

export class GameDetails extends Component{

    constructor() {
        super();
        this.state = {
            //holds the selected game
            isAdd: false,
            gameDetails: [],
            //holds the cart  items
            cartItems:[]
        };
    }

    //talks to the api in order to get the games by the id 
    componentDidMount() {

        let gameId = this.props.location.pathname.split('/').pop();
        fetch("https://localhost:5001/api/games/getgames/" + gameId)
            .then(response => response.json())
            .then(data => this.setState({ gameDetails: data }));
        console.log(gameId);
    }

    render() {
        return (
            <div className="gameDetails">

                <div className="addtoCart">
                    <img className='card-img-top' alt= 'game image' src={this.state.gameDetails.gameArtUrl}></img>
                    <button className="btn_AddCart" onClick={() => { addElementToCart(this.state.gameDetails) }}>Add To Cart</button>
                    <button className="btn_AddWish">Add To WishList</button>
                </div>

                <div className="description">  
                    <h1>{this.state.gameDetails.gameName} Details</h1>
                    <p className="gameDescription">{this.state.gameDetails.gameDescription}</p>
                </div>
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
        price: 80.00
    };

    if (sessionStorage.getItem('cart')) {
        cartItems = JSON.parse(sessionStorage.getItem('cart'));
    }
    //add the current item onto the cart list.
    cartItems.push(item);
    //save the cart element to local storage where it can be extracted later
    sessionStorage.setItem("cart", JSON.stringify(cartItems));
}

