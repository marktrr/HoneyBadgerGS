import React from 'react';
import './game-card.component.css';

export const GameCard = props =>{
  return(
    <div className="game-card">
      <img className='card-img-top' alt='random images' src={`https://picsum.photos/id/${props.games.id}/200/300`}></img>
      <p>{props.games.name}</p>
    </div>
  );
};