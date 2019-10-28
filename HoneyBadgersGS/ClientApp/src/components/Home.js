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

    //talks to the api in order to get the games from the database.
    componentDidMount() {
        fetch("https://localhost:44307/api/games/getGames")
            .then(response => response.json())
            .then(data => this.setState({ games: data }))
            console.log(this.state.games);
    }


    render() {
        return (
            <div className='home-method'>
                <GameList games={this.state.games}></GameList>
            </div>
        )
    }
}
