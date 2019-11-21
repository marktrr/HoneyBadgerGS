import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import axios from 'axios';
import moment from 'moment';
import './profile.component.css';
import { Alert } from 'reactstrap';


export class Profile extends Component {
    constructor() {
        super();
        this.state = {
            value: [],
            profile: [],
            profile_userName: '',
            profile_dob: '',
            profile_loaded: false,
            checked_promo: true,
            date: new Date()
        };
        //used to allow modification the form and to deal with form submissions
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleDob = this.handleDob.bind(this);
    }

    //load data if it exists
    componentDidMount() {
        let profile = document.cookie.match(new RegExp('(^| )' + 'userId' + '=([^;]+)'));

        //splits the cookie to get the login id and the userName
        profile = profile[2].split(',');
        console.log(profile[0]);
        this.setState({ profile: profile });
        this.setState({ profile_userName: profile[1] });

        //pulls in the data from the backend with the id
        fetch("https://localhost:5001/api/profiles/getprofiles/" + profile[0])
            .then(res => res.json())
            .then(data => this.setState({ value: data })).then(res => console.log(res));
        //if the value is not empty set the profile_loaded to true.
        
        if (this.state.value != null) {
            this.setState({ profile_loaded: true });
            //create the var hold the formatted date stored in the state : value.
            //store the formatted date inside date state.
            let birthDate = moment(this.state.value.dob).format('YYYY-MM-DD');
            this.setState({ date: birthDate });

            //set the state for the promo checkbox.
            if (this.state.value.Promotion === 1) {
                this.setState({ checked_promo: true });
            }
            else {
                this.setState({ checked_promo: false });
            }
        }
        else {
            this.setState({ profile_loaded: false });
        }

    }
     
    //allow modifying the data
    handleChange(event) {
        this.setState({ value: event.target.value, profile_userName: event.target.value });
    }

    //handles the changes made to the checkbox.
    handleCheck = (e) => {
        this.setState({ checked_promo: !this.state.checked_promo });
    }

    //hnadles the changes made to the date input.
    handleDob(event) {
        this.setState({
            date: event.target.value
        });
    }

    //click handler submit the update
    handleSubmit(event) {
        //prevents the default event from happening 
        event.preventDefault();

       
        //creates the profiel object.
        let profileObject = {
            //id, display name, actual name, gender, dob, email, promo
            ProfileId: this.state.profile[0],  
            gender: this.gender.value,
            email: this.email.value,
            userAddress: this.user_Address.value,
            dob: this.dob.value,
            Promotion: this.state.checked_promo,
            ActualName: this.actual_name.value,
            DisplayName: this.display_name.value,   
        };
        //if the object is null... it will create an empty object.
        if (profileObject === null) {

            let profileObject = {
                //id, display name, actual name, gender, dob, email, promo
                ProfileId: this.state.profile_id,
                DisplayName: null,
                ActualName: null,
                gender: null,
                dob: null,
                Promotion: false,
                email: null,
            };
        }
        //if the profile was not loaded successfully, create a new profile object with the fields
        if (this.state.profile_loaded != true) {
            createProfile(profileObject);
        }
        else {
            // use put to update the profile
            updateProfile(profileObject);      
        }
    }   
    render() {
        return (
            <div className="profile-form">
                <h2>User Profile</h2>
                <form method='POST' onSubmit={this.handleSubmit}>
                    <input type="text" name="id" value={this.state.value.displayid} ref={(display_id) => this.display_id = display_id} hidden></input>
                    <label for="display name">Display Name:</label>
                    <input type="text" name="display name" value={this.state.value.displayName} ref={(display_name) => this.display_name = display_name} onChange={this.handleChange} required></input>
                    <label for="actual name">Actual Name:</label>
                    <input type="text" name="actual name" value={this.state.value.actualName} onChange={this.handleChange} ref={(actual_name) => this.actual_name = actual_name} required></input>
                    <label for="gender">Gender:</label>
                    <input type="text" name="gender" value={this.state.value.gender} onChange={this.handleChange} ref={(gender) => this.gender = gender} required></input>
                    <label for="Address">Address:</label>
                    <input type="text" name="Address" value={this.state.value.userAddress} ref={(user_Address) => this.user_Address = user_Address} onChange={this.handleChange} required></input>

                    <label for="birth date">Date of Birth:</label>
                    <input type="date" name="birth date" value={this.state.date} onChange={this.handleDob} ref={(dob) => this.dob = dob} max="2019-11-17"></input>

                    <label for="email">Email:</label>
                    <input type="email" name="email" value={this.state.value.email} onChange={this.handleChange} ref={(email) => this.email = email} required></input>

                    <label for="credit-card" hidden>Credit Card</label>
                    <input type="number" name="credit-card" hidden />

                    <div id='checkbox-items'>
                        <label class="checkbox-label" for="promo">Receive Promotions from HBGS?
                            <input class="checkbox-input" type="checkbox" name="promo" DeafaultChecked={this.state.checked_promo} onChange={this.handleCheck} ref={(promo) => this.promo = promo}></input>
                        </label><br />
                        <label class="checkbox-label" for="physical-book"hidden>Physical Book<input class="checkbox-input" type="checkbox" name="physical-book" hidden /></label>
                    </div>
                    <input type="submit" value="submit" />
                </form>
            </div>
        );
    }
}

//used to add a new profile to the database(only used if an empty object is returned from the backend)
export function createProfile(data) {
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };
    axios.post("https://localhost:5001/api/profiles/add/", data, config).then(res => {
        alert('Successfully added your profile');
    });
    //redirects the view to display the games
    return window.location.replace('/');
}
//function is used to update a profile if it exists in the database.
export  function updateProfile(data) {

    const config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };
    axios.put(`https://localhost:5001/api/profiles/update/`, data, config).then(res => {
        alert('Successfully updated your profile');
    });

  

    return window.location.replace('/');
}


