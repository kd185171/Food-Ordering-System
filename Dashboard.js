import React, { Component,useState } from 'react';  
 
import 'react-datepicker/dist/react-datepicker.css'; 
 
import "react-datepicker/dist/react-datepicker.css";  
import 'bootstrap/dist/css/bootstrap.min.css';  
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
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Dashboard.css';
import moment from 'react-moment';


import DatePicker from 'react-datepicker';

import DateTimePicker from 'react-datetime-picker';

function Dashboard() {

  let navigate = useNavigate();

  const [UserName, setUserName] = useState('');
  const [OrderName, setOrderName] = useState('');
  const [Comments, setComments] = useState('');
  const [date, setDate] = useState(new Date());

  const handleCalendarClose = () => console.log("Calendar closed");
  const handleCalendarOpen = () => console.log("Calendar opened");

  const handleOrderNameChange =(value) => {
    setOrderName(value);
}
  
const handleUserNameChange =(value) => {
  setUserName(value);
}

const handleCommentsChange =(value) => {
  setComments(value);
}

const handleSave1 = () => {
  const p = parseInt(date.getMonth());
  const x = p+1;
  const dae = date.getDate()+'-'+x.toString()+'-'+date.getFullYear();
  const data = {
      Dtime : dae,
      UserName : UserName,
      OrderName : OrderName,
      Comments : Comments
  }
  console.log(data);
  const url= 'https://localhost:44305/api/Users/AddUser';
  axios.post(url,data).then((res)=>{
    alert("Order Added Succesfully");
    console.log(res.data);
  }).catch((error)=>{
      console.log(error);
  });
  navigate('/');
}







  return (
    <div class="pick">
      <div class="d1">Enter Username : </div>
      <MDBInput wrapperClass='mb-4' id='form1' type='text' onChange={(e) => handleUserNameChange(e.target.value)}/>
      <div class="d1">Enter Date and Time : </div>
      <DatePicker
      selected={date}
      onChange={(date) => setDate(date)}
      onCalendarClose={handleCalendarClose}
      onCalendarOpen={handleCalendarOpen}
      />
      <div class="d3">Enter Order Name : </div>
      <MDBInput wrapperClass='mb-4' id='form1' type='text' onChange={(e) => handleOrderNameChange(e.target.value)}/>
      <div >Comments : </div>
      <MDBInput wrapperClass='mb-4' id='form1' type='text' onChange={(e) => handleCommentsChange(e.target.value)}/>
      <MDBBtn onClick = {() => handleSave1()} className="mb-4 w-100">Add Order</MDBBtn>

    </div>
  );
}


export default Dashboard;