import { useState } from "react";
import Button from "../Button";

const AddUser = ({ onAddUser }) => {
    const[id, setId] = useState("")
    const[firstName, setFirstName] = useState("")
    const[lastName, setLastName] = useState("");

    const handleAddUser = () => {
        const newUser = {
          id : id,
          firstName: firstName,
          lastName: lastName,
        };
        
       onAddUser(newUser);
        
        setFirstName("");
        setLastName("");
        setId("");

      };

    return(
        <form>
            <label>
                ID:
                <input 
                    type = "text"
                    value = {id}
                    onChange={(e) => setId(e.target.value)}
                />
            </label>

            <label>
                First Name: 
                <input
                    type = "text"
                    value = {firstName}
                    onChange = {(e) => setFirstName(e.target.value)}
                />
            </label>

            <label>
                Last Name:
                <input 
                    type = "text"
                    value = {lastName}
                    onChange={(e) => setLastName(e.target.value)}
                />
            </label>
            
            <Button label = {"Add User"} onClick = {handleAddUser}></Button>
        </form>
        
    )
}

export default AddUser