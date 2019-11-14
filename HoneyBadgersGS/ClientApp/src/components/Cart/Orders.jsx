import React from 'react';

export default class Order extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            itemInfo: JSON.parse(sessionStorage.getItem("cart")),
            totalInfo: JSON.parse(sessionStorage.getItem("cartTotal"))
        }
    }

    render() {
        return (
            <div>
                <h1>Thank you for your order</h1>
                <div className="order-form">
                    <div class="column-labels">
                        <label className="product-image">Image</label>
                        <label className="product-details">Product</label>
                        <label className="product-price">Price</label>
                        <label className="product-quantity">Quantity</label>
                    </div>
                    {this.state.itemInfo && this.state.itemInfo.map(item =>
                        (<OrderItem key={item.itemID} itemID={item.itemID} itemImage={item.itemImage} itemName={item.itemName} price={item.price} quantity={item.quantity} />))}
                    {this.state.totalInfo && this.state.totalInfo.map(item =>
                        (<Total subTotal={item.subTotal} totalTax={item.totalTax} totalGrand={item.totalGrand} />))}
                   
                    <Payment/>

                    
                </div>
            </div>          
            )
    }
}

class OrderItem extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            itemID: this.props.itemID,
            itemImage: this.props.itemImage,
            itemName: this.props.itemName,
            price: this.props.price,
            quantity: this.props.quantity
        }
    }

    render() {
        return (
            <div className="product">
                <div className="product-image">
                    <img src={this.state.itemImage}></img>
                </div>
                <div className="product-details">
                    <div className="product-title">{this.state.itemName}</div>
                </div>
                <div className="product-price">{this.state.price}</div>
                <div className="product-quantity">{this.state.quantity}</div>
            </div>
        );
    }
}

class Total extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            subTotal: this.props.subTotal,
            totalTax: this.props.totalTax,
            totalGrand: this.props.totalGrand
        }
    }

    render() {
        return (
            <div className="totals">
                <div className="totals-item">
                    <label>Subtotal</label>
                    <div className="totals-value" id="cart-subtotal">{this.state.subTotal}</div>
                </div>
                <div className="totals-item">
                    <label>Tax (5%)</label>
                    <div className="totals-value" id="cart-tax">{this.state.totalTax} </div>
                </div>
                <div className="totals-item totals-item-total">
                    <label>Grand Total</label>
                    <div className="totals-value" id="cart-total">{this.state.totalGrand}</div>
                </div>
            </div>
            )
    }
}

class Payment extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            shipmentInfo: JSON.parse(sessionStorage.getItem("shipment"))
        }
    }

    render() {
        return (
            <div>
                <h2>Customer Information</h2>
                <div>Name: {this.state.shipmentInfo.customerName}</div>
                <div>Address: {this.state.shipmentInfo.address}</div>
                <div>Email: {this.state.shipmentInfo.email}</div>
                <div>Phone Number: {this.state.shipmentInfo.phoneNumber}</div>              
            </div>
            
            )
    }
}