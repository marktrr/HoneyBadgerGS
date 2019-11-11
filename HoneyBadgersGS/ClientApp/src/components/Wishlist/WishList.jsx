import React, { Component } from 'react';
import ListDetail from './ListDetail'

export class Wishlist extends Component {
    constructor() {
        super();
        this.state = {
            listItems: []
        };
    }

    componentDidMount() {
        let items = sessionStorage.getItem("wishlist");
        if (items) {
            items = JSON.parse(items);
            this.setState({ listItems: items });
        }
    }
    render() {

        return (
            <div>
                <h1>YOUR WISHLIST</h1><br /><hr />
                {this.state.listItems && this.state.listItems.map(item =>
                    (<ListDetail key={item.itemID} itemID={item.itemID} itemImage={item.itemImage} itemName={item.itemName} price={item.price} />))}
            </div>
        )
    }
}
