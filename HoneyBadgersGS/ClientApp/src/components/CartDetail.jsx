import React, {Component} from 'react';

export default class CartDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            itemID: props.itemID,
            itemImage: props.itemImage,
            itemName: props.itemName,
            price: props.price,
            total: props.price
        }
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
                    <Quantity quantity={this.state.quantity} />
                </div>
                <div class="product-removal">
                    <button class="remove-product">Remove</button>
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
    }

    render() {
        return (
            <td>
                <input
                    name="number"
                    type="number"
                    value={this.state.quantity}
                    onChange={this.handleQuantityChange}
                    max="10"
                    min="1" />
            </td>
        )
    }
}