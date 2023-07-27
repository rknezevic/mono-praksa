import React, { useState } from 'react';
import axios from 'axios';
import { HttpHeader } from '../HttpHeader';
import { useNavigate } from 'react-router-dom';
import Navbar from './Navbar';

const Form = () => {
  const [name, setName] = useState(''); 
  const navigate = useNavigate();

  const addStudyArea = async () => {
    try {
      const response = await axios.post(
        'https://localhost:44332/api/StudyArea',
        { Name: name },
        { headers: HttpHeader.get() }
      );

      if (response.status === 200) {
        console.log('Study area added:', response.data);
        setName('');
        navigate('/'); 
      }
    } catch (error) {
      console.log('Error adding study area:', error);
    }
  };

  const onSubmit = (e) => {
    e.preventDefault();
    addStudyArea();
  };

  return (
    <div>
      <Navbar/>
    <div className='form-container'>
    <form onSubmit={onSubmit}>
      <label>
        Name:
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </label>
      <button type="submit">Add Study Area</button>
    </form>
    </div>
    </div>
  );
};

export default Form;
