import {useState} from "react";

const Textbox = () => {

    const[inputValue, setInputValue] = useState('');

    const handleInputChange = (event) =>{
        setInputValue(event.target.value);
    };

    const handleClick = () => {
        localStorage.setItem('inputValue', inputValue);
        setInputValue("");
        
    }

    return(
        <div>
            <input
            type = "text"
            value = {inputValue}
            onChange={handleInputChange}
            placeholder="Enter your text..."
            />
            <button onClick = {handleClick}>Save to local storage</button>
        </div>
    );
};

export default Textbox;