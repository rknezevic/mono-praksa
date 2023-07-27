import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { HttpHeader } from '../HttpHeader';
import { getStudyAreaById } from '../service/service';
import { useParams } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import Navbar from './Navbar';

const EditForm = () => {
  const {id} = useParams();
  const [inputData, setInputData] = useState({Name : ''}); 
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async (id) => {
      try {
        const data = await getStudyAreaById(id);
        console.log(data)
      } catch (error) {
        console.error(error);
      }
    };
  
    fetchData(id);
  }, []);


  const handleUpdate = async () => {
    try {
      
      const response = await axios.put(
        'https://localhost:44332/api/StudyArea/' + id,
        { Name: inputData.Name },
        { headers: HttpHeader.get() }
      );

      if (response.status === 200) {
        console.log('Study area updated:', response.data);
        setInputData.Name('');
        navigate('/')
      }
    } catch (error) {
      console.log('Error adding study area:', error);
    }
  };


  return (
    <div> 
      <Navbar/>
    <div className='updateDiv'>
    <form onSubmit={handleUpdate}>
      <div className='form-group'>
        <label htmlFor="id"> ID: </label>
        <input type = "text" disabled name = 'id' className='form-control' value = {id}></input>
      </div>
      <div className='form-group'>
      <label>
        Name:
        <input
          type="text"
          value={inputData.Name}
          onChange={(e) => setInputData({...inputData, Name : e.target.value})}
        />
      </label>
      </div>
      <button type="submit">Update Study Area</button>
    </form>
    </div>
    </div>
  );
}

export default EditForm;


/*
const EditForm = ({ studyArea, onUpdate }) => {
  const [name, setName] = useState(studyArea.Name);

  const handleUpdate = async (id, updatedStudyArea) => {
    try {
      const response = await axios.put(
        `https://localhost:44332/api/StudyArea/${id}`,
        { Name: updatedStudyArea.Name },
        { headers: HttpHeader.get() }
      );

      if (response.status === 200) {
        onUpdate(id, updatedStudyArea);
        console.log('StudyArea updated successfully!');
      }
    } catch (error) {
      console.log('Error updating study area: ', error);
    }
  };

  const onSubmit = (e) => {
    e.preventDefault();
    handleUpdate(studyArea.Id, { Name: name });
  };

  return (
    <form onSubmit={onSubmit}>
      <label>
        Name:
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </label>
      <button type="submit">Update Study Area</button>
    </form>
  );
};
*//*
export default function EditForm(){
  const [loading, setLoading] = useState(true);
  const [studyArea, setStudyArea] = useState({});
  const navigate = useNavigate();
  const params = useParams();
  
  async function getStudyArea(){
    getStudyAreaById(params.Id).then((studyArea) => {
      setLoading(false);
      setStudyArea(studyArea);
    });
  }

  useEffect( () => {
    getStudyArea();
  }, []);

  return(
    <form className='editForm'
      onSubmit={async (e) => {
        var newStudyArea = new Study
      }}
  )




}
*/

