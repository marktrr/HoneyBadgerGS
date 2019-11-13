import React from 'react';
import { Link } from 'react-router-dom';

//create a stateless component to display the shopping cart items
class Checkout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            cartItems: JSON.parse(sessionStorage.getItem("cart"))
        }
    }  

    //calcute subtotal
    subtotal = () => {
        let tempSubtotal = 0
        this.state.cartItems.map((item) => {
            tempSubtotal += item.total;
        })
        return tempSubtotal.toFixed(2); // format decimal
    }

    totalTax = () => {
        var subtotal = this.subtotal();
        var tax = subtotal * 0.05;
        return tax.toFixed(2);
    }

    grandTotal = () => {
        var subtotal = this.subtotal();
        var total = subtotal * 1.05;
        return total.toFixed(2);
    }
   
    render() {
        // calculate total and taxes
        var subtotal = this.subtotal();
        var totalTax = this.totalTax();
        var totalGrand = this.grandTotal();
        return (
            <div>
                <div className="shoppingCart">
                    <h3>Please Confirm Your Order!</h3>
                    <div class="column-labels">
                        <label className="product-image">Image</label>
                        <label className="product-details">Product</label>
                        <label className="product-price">Price</label>
                        <label className="product-quantity">Quantity</label>
                        <label className="product-line-price">Total</label>
                    </div>

                    {this.state.cartItems && this.state.cartItems.map(item =>
                        (<CheckoutDetail key={item.itemID} itemID={item.itemID} itemImage={item.itemImage} itemName={item.itemName} price={item.price} quantity={item.quantity} total={item.total} />))}
                </div>

                <div className="totals">
                    <div className="totals-item">
                        <label>Subtotal</label>
                        <div className="totals-value" id="cart-subtotal">{subtotal}</div>
                    </div>
                    <div className="totals-item">
                        <label>Tax (5%)</label>
                        <div className="totals-value" id="cart-tax">{totalTax} </div>
                    </div>
                    <div className="totals-item totals-item-total">
                        <label>Grand Total</label>
                        <div className="totals-value" id="cart-total">{totalGrand}</div>
                    </div>
                    <Link to="/Shipment">
                        <button onClick={() => { saveState(subtotal, totalTax, totalGrand) }} className="shipment">Confirm Order</button>
                    </Link>
                    <button onClick={() => { this.props.history.goBack()}} className="shipment">Back To Order</button>
                </div>
            </div>
        )
    }
}

function saveState(subtotal, tax, total) {
    let totalList = [];
    var newItem = {
        subTotal: subtotal,
        totalTax: tax,
        totalGrand: total
    }
    totalList.push(newItem);
    sessionStorage.setItem('cartTotal', JSON.stringify(totalList));
}

class CheckoutDetail extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            itemID: this.props.itemID,
            itemImage: this.props.itemImage,
            itemName: this.props.itemName,
            price: this.props.price,
            quantity: this.props.quantity,
            total: this.props.price * this.props.quantity
        }
    }

    render() {
        return (
            <div class="product">
                <div class="product-image">
                    <img src={this.state.itemImage}></img>
                </div>
                <div class="product-details">
                    <div class="product-title">{this.state.itemName}</div>
                </div>
                <div class="product-price">{this.state.price}</div>
                <div class="product-quantity">{this.state.quantity}</div>
                <div class="product-line-price">{this.state.total}</div>
            </div>
        );
    }
}
export default Checkout;