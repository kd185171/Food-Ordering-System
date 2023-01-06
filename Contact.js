import React, { useState } from "react";
import './Dashboard.css';
import axios from "axios";
import {
    MDBContainer,
    MDBTabs,
    MDBTabsItem,
    MDBTabsLink,
    MDBTabsContent,
    MDBTabsPane,
    MDBBtn,
    MDBIcon,
    MDBInput,
    MDBCheckbox
  }
  from 'mdb-react-ui-kit';
  import { useNavigate } from 'react-router-dom';


function Contact(){
 const [Box,setBox] = useState('');
 let navigate = useNavigate();

 const handleBoxChange =(value) => {
    setBox(value);
}

    const handleSave = () => {
        const data = {
            Box : Box,
        }
        const url='https://localhost:44305/api/Users/AddMessage';
        axios.post(url,data).then((res)=>{
          alert("Message Added Succesfully");
          console.log(res.data);
        }).catch((error)=>{
            console.log(error);
        });
        navigate('/');
    }
    return(
        <div className="mb-3">
          <div className="m1" htmlFor="message" >
            Message:
          </div>
          <textarea className="m2" id="message" onChange={(e) => handleBoxChange(e.target.value)} required />
          <div><MDBBtn className="m3" onClick = {() => handleSave()} >Add Message</MDBBtn></div>
          </div>

    );
}
export default Contact;