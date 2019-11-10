import React, { Component } from 'react';

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
                <div className="item-details">
                    <div className="item-image">
                        <img src={this.state.itemImage}></img>
                    </div>
                    <div className="item-title">{this.state.itemName}</div>
                    <div className="item-price">Price: {this.state.price}</div>
                    <button className="remove-item" onClick={() => { removeItem(this.state.itemID) }}>Remove</button>
                </div>
            </div>
        );
    }
}

function removeItem(gameId) {
    var retrieveArray = JSON.parse(sessionStorage.getItem('wishlist'));

    for (var i = 0; i < retrieveArray.length; i++) {
        if (retrieveArray[i].itemID == gameId) {
            retrieveArray.splice(i, 1);
        }
    }
    sessionStorage.setItem('wishlist', JSON.stringify(retrieveArray));
    //console.log(JSON.parse(sessionStorage.getItem('wishlist')).length);
    window.location.reload();
}