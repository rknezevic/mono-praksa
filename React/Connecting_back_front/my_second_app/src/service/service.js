import axios from "axios";
import { HttpHeader } from "../HttpHeader";

export const getStudyAreaById = async (id) => {
    const response = await axios.get(`https://localhost:44332/api/StudyArea/${id}`, {headers: HttpHeader.get()})
    if(response.data){
      return response.data;
    }
    else return null;
    };