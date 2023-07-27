
import './App.css';
import React, { useEffect, useState} from "react"
import axios from 'axios';
import Form from './components/Form';
import {HttpHeader} from './HttpHeader';
import Table from "./components/Table";
import Navbar from './components/Navbar';
import { useNavigate, useParams } from 'react-router-dom';
import { getStudyAreaById } from './service/service';


const StudyAreaComponent = () => {
  const[studyAreas, setStudyAreas] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchStudyAreas();
  }, []);

  const fetchStudyAreas = () =>{
    axios
    .get("https://localhost:44332/api/StudyArea", {headers: HttpHeader.get()})
    .then(response => {
      setStudyAreas(response.data);
    })
    .catch(error => {
      console.log("Error fetching study areas: ", error);
    });
  };

  

  
  const handleDelete = async (id) => {
    const temp = await getStudyAreaById(id);
    let answer = window.confirm("Are you sure you want to delete this Study Area?");
    if(temp != null && answer){
      const response = await axios.delete(`https://localhost:44332/api/StudyArea/${temp.Id}`, {headers: HttpHeader.get()})
    if(response.status === 200) {
        fetchStudyAreas()
      
    }
    }else return null;
  };

  const handleUpdate = async (id) => {
    navigate(`/edit/${id}`); 
  }


  return (
    <div>
      <Navbar/>
      <h2>Study Areas</h2>
      <Table studyAreas = {studyAreas} onDelete = {handleDelete} onUpdate={handleUpdate}/>
      
    </div>
    
  );

};
export default StudyAreaComponent;
