import React from 'react';
import './game-card.component.css';

export const GameCard = props =>{
  return(
    <div className="game-card">
      <img className='card-img-top' alt='random images' src={props.games.gameArtUrl}></img>
      <p>{props.games.gameName}</p>
    </div>
  );
};