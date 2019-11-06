import React, {Component} from 'react';

export default class CartDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            itemID: this.props.itemID,
            itemImage: this.props.itemImage,
            itemName: this.props.itemName,
            price: this.props.price,
            quantity: 1,
            total: this.props.price
        }

        this.quantityCallBack = this.quantityCallBack.bind(this);
    }

    quantityCallBack = (changedQuantity) => {
        this.setState({
            quantity: changedQuantity,
            total: this.state.price * changedQuantity
        })
    }

    render() {
        return(
            <div class="product">
                <div class="product-image">
                    <img src={this.state.itemImage}></img>
                </div>
                <div class="product-details">
                    <div class="product-title">{this.state.itemName}</div>
                </div>
                <div class="product-price">{this.state.price}</div>
                <div class="product-quantity">
                    <Quantity quantityCallBack={this.quantityCallBack} quantity={this.state.quantity} />
                </div>
                <div class="product-removal">
                    <button onClick={() => { removeItem(this.state.itemID) }} class="remove-product">Remove</button>
                </div>
                <div class="product-line-price">{this.state.total}</div>
            </div>
        );
    }
}

class Quantity extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            quantity: this.props.quantity
        }
        this.handleQuantityChange = this.handleQuantityChange.bind(this);
    }

    handleQuantityChange = async (e) => {
        const userInput = e.target.value;
        await this.setState({ quantity: userInput })
        this.props.quantityCallBack(this.state.quantity)
    }

    render() {
        return (
            <td>
                <input
                    name="number"
                    type="number"
                    value={this.state.quantity}
                    onChange={this.handleQuantityChange}
                    max="3"
                    min="1" />
            </td>
        )
    }
}

function removeItem(gameId) {
    var retrieveArray = JSON.parse(sessionStorage.getItem('cart'));

    for (var i = 0; i < retrieveArray.length; i++) {
        if (retrieveArray[i].itemID == gameId) {
            retrieveArray.splice(i, 1);
        }
    }
    sessionStorage.setItem('cart', JSON.stringify(retrieveArray));
    window.location.reload();
}