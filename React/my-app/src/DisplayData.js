import React from 'react';
import Button from './Button';

class DisplayData extends React.Component {
    handleClick = () => {
        const data = localStorage.getItem('inputValue');
        alert(data);
    };
    render(){
        return(
            <Button onClick = {this.handleClick} label = "Get data from local storage"/>
        );
    } 
}

export default DisplayData;