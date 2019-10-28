import React, { Component } from 'react';
import './Cart.scss';

function Item(props) {
    return (
        <div class="product">
            <div class="product-image">
                <img src={props.itemImage}></img>
            </div>
            <div class="product-details">
                <div class="product-title">{props.itemName}</div>
            </div>
            <div class="product-price">{props.price}</div>
            <div class="product-quantity">
                <input type="number" value="" min="1"></input>
            </div>
            <div class="product-removal">
                <button class="remove-product">Remove</button>
            </div>
            <div class="product-line-price">line price</div>
        </div>
    );
}

export class Cart extends Component {
    render() {
        let cartItems = sessionStorage.getItem("cart");
        cartItems = JSON.parse(cartItems);
        let cartComponent = cartItems.map(item => <Item itemID={item.itemID} itemImage={item.itemImage} itemName={item.itemName} price={item.price} />)
     
        return (
            <div>
                <h1>Shopping Cart</h1> <br/> <br/>
                
                <div class="shopping-cart">

                    <div class="column-labels">
                        <label class="product-image">Image</label>
                        <label class="product-details">Product</label>
                        <label class="product-price">Price</label>
                        <label class="product-quantity">Quantity</label>
                        <label class="product-removal">Remove</label>
                        <label class="product-line-price">Total</label>
                    </div>

                    <div class="product">
                        {cartComponent}
                    </div>    
                    
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