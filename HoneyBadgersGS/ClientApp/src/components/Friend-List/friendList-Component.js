import React, { Component } from 'react';

export class FriendList extends Component{
    constructor() {
        super();
        this.state = {
            //store friend list in the friendlist state.
            allUsers:[],
            friendlist: []
        };
     
        this.handleDelete = this.handleDelete.bind(this);
    }

    componentWillMount() {

        //get the friend list -- the user id
        //changing the db--- table to have a friend name and account id
            // fetch("http://localhost:5001/api/accounts")
            //.then(res => res.json)
        //.then(data => this.setState({ friendlist: data }));
        var object = [{ name: 'jim', age: '40' }, { name: 'Alex', age: '50' }];
        this.setState({ friendlist: JSON.stringify(object)})
        };

    //click handler to listen for the delete button
    handleDelete(event) {


       //get the id and delete the user from the friendlist.
         // fetch("http://localhost:5001/api/friendlist/delete/{id}")
            //.then(res => res.json)
        //.then(data => this.setState({ friendlist: data }))


       //it should return the new friendlist to be displayed
    }

    render() {
            return (
                <div className="friend-list">
                    <h2>Friend List</h2>
                    <p>{this.state.friendlist.name}</p>
                    <input type="button" name="delete" value="Delete"/>
                </div>
            );
        }
}


//<h3>{this.state.friendlist}</h3>
//    <input type="text" name="friendId" ref={(friend_id) => this.friend_id = friend_id}
//        hidden>{this.state.friendlist.friendId}
//    </input>
//        Delete Friend
//                    </input>