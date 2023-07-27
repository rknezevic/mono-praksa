import React from "react";
import Button from "./Button";

const SaveData = () => {
    const handleClick = () => {
        const data = "Ovo je neki string koji cu spremit u svoj local storage";
        localStorage.Se('data', data);
        alert("Data saved!");
    }
    return (
        <Button onClick = {handleClick} label = "Save to local storage!" />
    );
};

export default SaveData;