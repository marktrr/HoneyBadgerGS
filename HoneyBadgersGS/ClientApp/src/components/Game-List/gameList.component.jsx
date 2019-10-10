import React from 'react';
import './gameList.compnent.css';
import {GameCard} from '../Game-Card/game-card.component';

//creates the game list using card element
export const GameList = props =>(
    <div className='card-list'>
        {props.games.map(games=>(
            <GameCard key={games.id} games={games}/>
        ))}
    </div>
);