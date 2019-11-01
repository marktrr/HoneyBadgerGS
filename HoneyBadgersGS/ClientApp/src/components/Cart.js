import React, { Component } from 'react';
import './Cart.scss';
import CartDetail from './CartDetail';

export class Cart extends Component {
    constructor() {
        super();
        this.state = {
            cartItems: []
        };
    }
    

    componentDidMount() {
        let items = sessionStorage.getItem("cart");
        if (items) {
            console.log(true);
            items = JSON.parse(items);
            this.setState({ cartItems: items });
        } 
    }
    render() {
        
        return (
            <div>
                <h1>Shopping Cart</h1> <br/> <br/>
                
                <div class="shopping-cart">

                    <div class="column-labels">
                        <label class="product-image">Image</label>
                        <label class="product-details">Product</label>
                        <label class="product-price">Price</label>
                        <label class="product-quantity">Quantity</label>
                        <button class="product-removal">Remove</button>
                        <label class="product-line-price">Total</label>
                    </div>

                    {this.state.cartItems && this.state.cartItems.map(item =>
                        (<CartDetail key={item.itemID} itemID={item.itemID} itemImage={item.itemImage} itemName={item.itemName} price={item.price} />))}
                   
                    <div class="totals">
                        <div class="totals-item">
                            <label>Subtotal</label>
                            <div class="totals-value" id="cart-subtotal">cart subtotal here</div>
                        </div>
                        <div class="totals-item">
                            <label>Tax (5%)</label>
                            <div class="totals-value" id="cart-tax">tax here</div>
                        </div>
                        <div class="totals-item totals-item-total">
                            <label>Grand Total</label>
                            <div class="totals-value" id="cart-total">tatal here</div>
                        </div>
                    </div>
                    <button class="checkout">Checkout</button>
                </div>
            </div>
        )
    }
}