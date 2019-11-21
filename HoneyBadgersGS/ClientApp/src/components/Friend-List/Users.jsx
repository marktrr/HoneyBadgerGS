import React, { Component } from 'react';

export class FriendList extends Component {
    constructor() {
        super();
        this.state = {
            //store friend list in the friendlist state.
            allUsers: [],
            friendlist: []
        };

        this.handleAdd = this.handleAdd.bind(this);
    }


    componentWillMount() {

        //get the friend list -- the user id
        //changing the db--- table to have a friend name and account id
        // fetch("http://localhost:5001/api/accounts")
        //.then(res => res.json)
        //.then(data => this.setState({ friendlist: data }));
    };

    handleAdd(event) {

      
    }


    render() {
        return (
            <div className="friend-list">
                <h2>Friend List</h2>
                <p>{this.state.friendlist.name}</p>
                <input type="button" name="Add" value="Add" />
            </div>
        );
    }
}