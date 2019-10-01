import React, { Component } from 'react';
import { GameList } from './Game-List/gameList.component';
import './home.css';

export class Home extends Component {

    constructor() {
        super();
        this.state = {
            games: []
        };
    }

    componentDidMount() {
        fetch('https://jsonplaceholder.typicode.com/users')
            .then(response => response.json())
            .then(users => this.setState({ games: users }))
    }


    render() {
        return (
            <div className='home-method'>
                <GameList games={this.state.games}></GameList>
            </div>
        )
    }
}
