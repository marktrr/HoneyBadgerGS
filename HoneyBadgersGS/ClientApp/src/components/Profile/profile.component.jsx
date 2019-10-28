import React, { Component } from 'react';
import  './profile.component.css';
import { createRestTypeNode } from 'typescript';

export class Profile extends Component{
    constructor() {
        super();
        this.state = {
            value: [],
            profile: [],
            profile_userName: '',
            profile_dob: new Date(),
            isOn:true
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    //load data if it exists
    componentDidMount() {
        let profile = document.cookie.match(new RegExp('(^| )' + 'userId' + '=([^;]+)'));
        //profile[0] = id  //profile[1] = email / username

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

        //required to modify the date or the api (backend) cannot parse it properly
        var date = new Date(this.dob.value);
        var dateCal = new Date(date.getTime() - (date.getTimezoneOffset() * 60000)).toISOString();
        var promoValue = false;

        if (this.promo.value === 'on') {
            promoValue = true;
        }
        else {
            promoValue = false;
        }

        let profileObject = {
            //id, display name, actual name, gender, dob, email, promo
            ProfileId: this.state.profile_id,
            DisplayName: this.display_name.value,
            ActualName: this.actual_name.value,
            gender: this.gender.value,
            dob: dateCal,
            email: this.email.value,
            promo: promoValue
        };
        sessionStorage.setItem('myformobj', JSON.stringify(profileObject));
        createProfile(JSON.stringify(profileObject));
        event.preventDefault();
    }

    render(){
        return (
            <div className="profile-form">
                <h2>User Profile</h2>
                <form>
                    <label for="display name">Display Name:</label>
                    <input type="text" name="display name" value={this.state.value.displayName} ref={(display_name) => this.display_name = display_name} onChange={this.handleChange}></input>
                    <label for="actual name">Actual Name:</label>
                    <input type="text" name="actual name" value={this.state.value.actualName} ref={(actual_name) => this.actual_name = actual_name}></input>
                    <label for="gender">Gender:</label>
                    <input type="text" name="gender" value={this.state.value.gender} ref={(gender) => this.gender = gender}></input>
                    <label for="birth date">Date of Birth:</label>
                    <input type="date" name="birth date" value={this.state.value.dob} ref={(dob) => this.dob = dob}></input>
                    <label for="email">Email:</label>
                    <input type="text" name="email" value={this.state.value.email} ref={(email) => this.email = email}></input>
                    <div id='checkbox-items'>
                        <input type="checkbox" name="promo" ref={(promo) => this.promo = promo}></input>
                        <label for="promo">Receive Promotions from HBGS?</label>          
                    </div>
                    <input type="submit" value="submit" onClick={this.handleSubmit} />
                </form>
            </div>
        );
    }
}

export function createProfile(data) {

    return fetch("https://localhost:5001/api/Profiles/update" + this.state.profile.profileId, {
        method: 'PUT',
        headers: {'Content-Type': 'application/x-www-form-urlencoded'},
        body: data
    }).then(res => { return res }).catch(err=>err);

}