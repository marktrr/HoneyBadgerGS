import React from "react";
import './Shipment.css'

export default class Shipment extends React.Component {
    render() {
        return (
            <div className="shoppingCart">
                <h3>Enter Your Shipping Details Below. We only accept order from CA.</h3>
                <ShipmentForm/>
            </div>
        )
    }
}
//Regex for validation
const postalcodeRegex = RegExp(/^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$/i);
const emailRegex = RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);
const phoneRegex = RegExp(/^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$/i);
const cardRegex = RegExp(/^((4\d{3})|(5[1-5]\d{2}))(-?|\040?)(\d{4}(-?|\040?)){3}|^(3[4,7]\d{2})(-?|\040?)\d{6}(-?|\040?)\d{5}/i);

//valid the form.
const validateForm = (listItem, errors) => {
    let valid = true;

    if (listItem.customerName == '' || listItem.address == '' || listItem.city == '' || listItem.provinceCode == '' ||
        listItem.countyCode == '' || listItem.email == '' || listItem.phoneNumber == '' || listItem.cardNumber == '' || listItem.cvv == '') {
        valid = false;
    } 
    Object.values(errors).forEach(
        (val) => val.length > 0 && (valid = false)
    );
    return valid;
}

class ShipmentForm extends React.Component {
    //create the state that will be submitted to Pwinty
    constructor(props) {
        super(props);
        this.state = {
            customerName: "",           
            address: "",
            city: "",
            provinceCode: "",
            countyCode: "CA",
            postalCode: "",
            email: "",
            phoneNumber: "",
            cardNumber: "",
            cvv: "", 
            errors: {
                customerName: "",
                address: "",
                city: "",
                provinceCode: "",
                postalCode: "",
                email: "",
                phoneNumber: "",
                cardNumber: "",
                cvv: ""
            }
        };
        this.handleUserInput = this.handleUserInput.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);     
    }

    //show error when user change data
    handleUserInput(event) {
        const target = event.target;
        const name = target.className;
        const value = target.value;

        let errors = this.state.errors;
        this.setState({ [name]: value });

        switch (name) {
            case 'customerName':
                errors.customerName = value.length < 5 ? 'Full Name Must Be 5 Characters Long.' : '';
                break;
            case 'address':
                errors.address = value.length < 10 ? 'Full Name Must Be 10 Characters Long.' : '';
                break;
            case 'city':
                errors.city = value.length < 5 ? 'City Must Be 5 Characters Long.' : '';
                break;
            case 'provinceCode':
                errors.provinceCode = value.length != 2 ? 'Province Code Must Be Exactly 2 Characters. Example: ON.' : '';
                break;
            case 'postalCode':
                errors.postalCode = postalcodeRegex.test(value) ? '' : "Invalid Canadian Postal Code. Example: A1B1C1.";
                break;
            case 'email':
                errors.email = emailRegex.test(value) ? '': 'Invalid Email Address.';
                break;
            case 'phoneNumber':
                errors.phoneNumber = phoneRegex.test(value) ? '' : 'Invalid Phone Number Format. Example: 519-111-1111';
                break;
            case 'cardNumber':
                errors.cardNumber = cardRegex.test(value) ? '' : 'Invalid Card Number.'
                break;
            case 'cvv':
                errors.cvv = value.length != 3 ? 'Securiy Code Must Be Exactly 3 Digits' : '';
                break;
            default:
                break;
        }

        this.setState({ errors, [name]: value });
    }

    //handle submit button
    handleSubmit = (event) => {
        let checkAll = {
            customerName: this.state.customerName,
            address: this.state.address + ", " + this.state.city + ", " + this.state.provinceCode + ", " + "CA, " + this.state.postalCode,
            email: this.state.email,
            phoneNumber: this.state.phoneNumber,
            cardNumber: this.state.cardNumber,
            cvv: this.state.cvv
        }

        let toAdd = {
            customerName: this.state.customerName,
            address: this.state.address + ", " + this.state.city + ", " + this.state.provinceCode + ", " + "CA, " + this.state.postalCode,
            email: this.state.email,
            phoneNumber: this.state.phoneNumber,
        }
       
        if (validateForm(checkAll, this.state.errors)) {
            console.info('Valid Form')
            sessionStorage.setItem('shipment', JSON.stringify(toAdd))
        } else {
            console.error('Invalid Form')
            event.preventDefault();
        }
    }

    //display form
    render() {
        const { errors } = this.state;
        return (
            <div className="formShipment">
                <form action="/OrderCompleted" onSubmit={this.handleSubmit}>
                    <fieldset className="cusInfo">
                        <legend>Customer Information:</legend>
                        <label id="recipientName">Customer Name:</label>
                        <input type="text" className="customerName" value={this.state.customerName} onChange={event => this.handleUserInput(event)} />
                        {errors.customerName.length > 0 && <span className='error'>{errors.customerName}</span>}<br />

                        <label>Address:</label>
                        <input type="text" className="address" value={this.state.address} onChange={event => this.handleUserInput(event)} />
                        {errors.address.length > 0 && <span className='error'>{errors.address}</span>}<br />

                        <label>City:</label>
                        <input type="text" className="city" value={this.state.city} onChange={event => this.handleUserInput(event)} />
                        {errors.city.length > 0 && <span className='error'>{errors.city}</span>}<br />

                        <label>Province:</label>
                        <input type="text" className="provinceCode" value={this.state.provinceCode} onChange={event => this.handleUserInput(event)} />
                        {errors.provinceCode.length > 0 && <span className='error'>{errors.provinceCode}</span>}<br />

                        <label>Country:</label>
                        <input type="text" className="countryCode" value={this.state.countyCode} disabled /><br />

                        <label>Postal Code:</label>
                        <input type="text" className="postalCode" value={this.state.postalCode} onChange={event => this.handleUserInput(event)} />
                        {errors.postalCode.length > 0 && <span className='error'>{errors.postalCode}</span>}<br />

                        <label>Email:</label>
                        <input type="text" className="email" value={this.state.email} onChange={event => this.handleUserInput(event)} />
                        {errors.email.length > 0 && <span className='error'>{errors.email}</span>}<br />

                        <label>Phone:</label>
                        <input type="text" className="phoneNumber" value={this.state.phoneNumber} onChange={event => this.handleUserInput(event)} />
                        {errors.phoneNumber.length > 0 && <span className='error'>{errors.phoneNumber}</span>}<br /> <hr />
                        </fieldset>

                    <fieldset className="payment">
                        <legend>Payment information:</legend>
                        <label>Card Number</label>
                        <input type="number" className="cardNumber" value={this.state.cardNumber} onChange={event => this.handleUserInput(event)} />
                        {errors.cardNumber.length > 0 && <span className='error'>{errors.cardNumber}</span>}<br /> <hr />

                        <label>Security Code</label>
                        <input type="number" className="cvv" value={this.state.cvv} onChange={event => this.handleUserInput(event)} />
                        {errors.cvv.length > 0 && <span className='error'>{errors.cvv}</span>}<br /> <hr />
                    </fieldset>
                    <button className="btn-submit">Next</button>
                </form>
            </div>
           
        );
    }
}