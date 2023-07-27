import React from 'react';

export default function Navbar (){
  return <nav className='navbar'>
    <a href = "/" className='site-title'> InternHub </a>
    <ul>
      <li>
        <a href = "/add"> Add </a>
      </li>
      
    </ul>
  </nav>
}