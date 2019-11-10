import React, { Component } from 'react';
import './profile.component.css';

export class Profile extends Component {
    constructor() {
        super();
        this.state = {
            value: [],
            profile: [],
            profile_userName: '',
            profile_dob: new Date(),
            isOn: true
        };
        //used to allow modification the form and to deal with form submissions
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }
    //load data if it exists
    componentDidMount() {
        let profile = document.cookie.match(new RegExp('(^| )' + 'userId' + '=([^;]+)'));

        profile = profile[2].split(',');
        this.setState({ profile: profile });
        this.setState({ profile_userName: profile[1] })

        fetch("https://localhost:5001/api/profiles/getprofiles/" + profile[0])
            .then(response => response.json())
            .then(data => this.setState({ value: data })).then(res => console.log(this.state.value));
    }
    //allow modifying the data
    handleChange(event) {
        this.setState({ value: event.target.value, profile_userName: event.target.value });
    }
    //click handler submit the update
    handleSubmit(event) {
        //prevents the default event from happening 
        event.preventDefault();

        var date = new Date(this.dob.value);
        var promoValue = false;

        if (this.promo.value === 'on') {
            promoValue = true;
        }
        else {
            promoValue = false;
        }

        const profileObject = {
            //id, display name, actual name, gender, dob, email, promo
            ProfileId: this.state.profile_id,
            DisplayName: this.display_name.value,
            ActualName: this.actual_name.value,
            gender: this.gender.value,
            dob: this.dob.value,
            email: this.email.value,
        };
        var myObject = JSON.stringify(myObject);
        createProfile(myObject);
    }

    render() {
        return (
            <div className="profile-form">
                <h2>User Profile</h2>
                <form method='POST' onSubmit={this.handleSubmit}>
                    <input type="text" name="id" value={this.state.value.displayid} ref={(display_id) => this.display_id = display_id} hidden></input>
                    <label for="display name">Display Name:</label>
                    <input type="text" name="display name" value={this.state.value.displayName} ref={(display_name) => this.display_name = display_name} onChange={this.handleChange}></input>
                    <label for="actual name">Actual Name:</label>
                    <input type="text" name="actual name" value={this.state.value.actualName} onChange={this.handleChange} ref={(actual_name) => this.actual_name = actual_name}></input>
                    <label for="gender">Gender:</label>
                    <input type="text" name="gender" value={this.state.value.gender} onChange={this.handleChange} ref={(gender) => this.gender = gender}></input>
                    <label for="birth date">Date of Birth:</label>
                    <input type="date" name="birth date" value={this.state.value.dob} onChange={this.handleChange} ref={(dob) => this.dob = dob}></input>
                    <label for="email">Email:</label>
                    <input type="text" name="email" value={this.state.value.email} onChange={this.handleChange} ref={(email) => this.email = email}></input>
                    <label for="credit-card">Credit Card</label>
                    <input type="number" name="credit-card" />

                    <div id='checkbox-items'>
                        <label class="checkbox-label" for="promo">Receive Promotions from HBGS?
                            <input class="checkbox-input" type="checkbox" name="promo" value={this.state.value.promo} onChange={this.handleChange} ref={(promo) => this.promo = promo}>
                            </input>
                        </label><br/>
                        <label class="checkbox-label" for="physical-book">Physical Book<input class="checkbox-input" type="checkbox" name="physical-book" /></label>
                    </div>
                    <input type="submit" value="submit" />
                </form>
            </div>
        );
    }
}

//used to search for an id to update the database record, but currently don't know how to capture an object in the controller.
export function createProfile(data) {
    fetch("https://localhost:5001/api/Profiles/Add", {
        method: 'POST',
        header: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8'
        },
        body: data
    });
}


//export function createProfile(data) {
//    var http = new XMLHttpRequest();
//    http.open('POST', "https://localhost:5001/api/Profile/Add", true);
//    http.setRequestHeader('Content-type', 'application/json');
//    http.send(JSON.stringify(data));
//    http.onload = function () {
//        alert(http.requestText)
//    }

//}