import React, { Component } from 'react';
import axios from 'axios';
import './WishList.css';

export default class ListDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            itemID: props.itemID,
            itemImage: props.itemImage,
            itemName: props.itemName,
            price: props.price,
        }
    }

    render() {
        return (
            <div className="wishlist">              
                <img className="item-image" src={this.state.itemImage}></img>
                <p className="item-title">{this.state.itemName}</p>
                <p className="item-price">Price: {this.state.price}</p>
                <button className="remove-item" onClick={() => { removeItem(this.state.itemID) }}>Remove</button>       
            </div>
        );
    }
}

function removeItem(gameId) {
    var retrieveArray = JSON.parse(sessionStorage.getItem('wishlist'));

    for (var i = 0; i < retrieveArray.length; i++) {
        if (retrieveArray[i].itemID == gameId) {
            var id = parseInt(retrieveArray[i].wishlistId);
            removeFromDB(id); // remove item from DB
            retrieveArray.splice(i, 1); // remove item from sessionStorage
        }
    }
    sessionStorage.setItem('wishlist', JSON.stringify(retrieveArray));

    //if wishlist empty, remove from sessionStorage.
    if (JSON.parse(sessionStorage.getItem('wishlist')).length == 0) {
        sessionStorage.removeItem('wishlist');
    }
    window.location.reload();
  
}

export function removeFromDB(id) {
    //remove from db
    axios.delete("https://localhost:5001/api/Wishlists/" + id).then(res => {
        console.log(res);
        console.log(res.data);
    });
}