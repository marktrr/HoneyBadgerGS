import React from 'react';
import { Link } from 'react-router-dom';
import './game-card.component.css';

export const GameCard = props =>{
    return (
        <Link to={"/Details/" + props.games.gameId}>
            <div className="game-card">
                <img className='card-img-top' alt='random images' src={props.games.gameArtUrl}></img>
                <p>{props.games.gameName}</p>
            </div>
        </Link>
  );
};