import React, { useState } from 'react';
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
import DatePicker from 'react-datepicker';

function LoginRegister() {
  let navigate = useNavigate();

  

    const [FirstName, setFirstName] = useState('');
    const [LastName, setLastName] = useState('');
    const [Email, setEmail] = useState('');
    const [Password, setPassword] = useState('');
    const [date, setDate] = useState(new Date());

   const handleCalendarClose = () => console.log("Calendar closed");
   const handleCalendarOpen = () => console.log("Calendar opened");


    const handleFirstNameChange =(value) => {
        setFirstName(value);
    }
    const handleLastNameChange =(value) => {
        setLastName(value);
    }
    const handleEmailChange =(value) => {
        setEmail(value);
    }
    const handlePasswordChange =(value) => {
        setPassword(value);
    }




    const handleSave = () => {
      const p = parseInt(date.getMonth());
      const x = p+1;
      const dae = date.getDate()+'-'+x.toString()+'-'+date.getFullYear();
        const data = {
            FirstName : FirstName,
            LastName :LastName,
            Email : Email,
            Password : Password,
            CreatedOn:dae
        }
        const url='https://localhost:44305/api/Users/Registration';
        axios.post(url,data).then((res)=>{
          alert("User Registered Succesfully");
          console.log(res.data);
        }).catch((error)=>{
            console.log(error);
        });
        navigate('/Login');
    }

    const handleSave1 = () => {
        const data = {
            Email : Email,
            Password : Password
        }
        const url= 'https://localhost:44305/api/Users/Login';
        axios.post(url,data).then((res)=>{
            var pw = res.data.Password;
            if(pw = Password){
              localStorage.setItem('user',res.data.Email);
              navigate('/Navbar');
            }else{
              alert("Invalid Username or Password");
            }
        }).catch((error)=>{
            console.log(error);
        });
    }


  const [justifyActive, setJustifyActive] = useState('tab1');;

  const handleJustifyClick = (value) => {
    if (value === justifyActive) {
      return;
    }

    setJustifyActive(value);
  };




  return (
    <MDBContainer className="p-3 my-5 d-flex flex-column w-50">
      

      <MDBTabs pills justify className='mb-3 d-flex flex-row justify-content-between'>
        <MDBTabsItem>
          <MDBTabsLink onClick={() => handleJustifyClick('tab1')} active={justifyActive === 'tab1'}>
            Login
          </MDBTabsLink>
        </MDBTabsItem>
        <MDBTabsItem>
          <MDBTabsLink onClick={() => handleJustifyClick('tab2')} active={justifyActive === 'tab2'}>
            Register
          </MDBTabsLink>
        </MDBTabsItem>
      </MDBTabs>

      <MDBTabsContent>

        <MDBTabsPane show={justifyActive === 'tab1'}>

          <div className="text-center mb-3">
            <p>Sign in with:</p>

            <div className='d-flex justify-content-between mx-auto' style={{width: '40%'}}>
              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='facebook-f' size="sm"/>
              </MDBBtn>

              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='twitter' size="sm"/>
              </MDBBtn>

              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='google' size="sm"/>
              </MDBBtn>

              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='github' size="sm"/>
              </MDBBtn>
            </div>

            <p className="text-center mt-3">or:</p>
          </div>

          <MDBInput wrapperClass='mb-4' label='Email address' id='form3' type='email' onChange={(e) => handleEmailChange(e.target.value)}/>
          <MDBInput wrapperClass='mb-4' label='Password' id='form2' type='password' onChange={(e) => handlePasswordChange(e.target.value)}/>


          <MDBBtn onClick = {() => handleSave1()} className="mb-4 w-100">Sign in</MDBBtn>


        </MDBTabsPane>

        <MDBTabsPane show={justifyActive === 'tab2'}>

          <div className="text-center mb-3">
            <p>Sign in with:</p>

            <div className='d-flex justify-content-between mx-auto' style={{width: '40%'}}>
              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='facebook-f' size="sm"/>
              </MDBBtn>

              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='twitter' size="sm"/>
              </MDBBtn>

              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='google' size="sm"/>
              </MDBBtn>

              <MDBBtn tag='a' color='none' className='m-1' style={{ color: '#1266f1' }}>
                <MDBIcon fab icon='github' size="sm"/>
              </MDBBtn>
            </div>

            <p className="text-center mt-3">or:</p>
          </div>

          <MDBInput wrapperClass='mb-4' placeholder='FirstName' id='form1' type='text' onChange={(e) => handleFirstNameChange(e.target.value)}/>
          <MDBInput wrapperClass='mb-4' placeholder='LastName' id='form4' type='text' onChange={(e) => handleLastNameChange(e.target.value)}/>
          <MDBInput wrapperClass='mb-4' placeholder='Email' id='form5' type='Email' onChange={(e) => handleEmailChange(e.target.value)}/>
          <MDBInput wrapperClass='mb-4' placeholder='Password' id='form6' type='Password' onChange={(e) => handlePasswordChange(e.target.value)}/>
          <DatePicker
          selected={date}
          onChange={(date) => setDate(date)}
          onCalendarClose={handleCalendarClose}
          onCalendarOpen={handleCalendarOpen}
          />
          
    

          <div className='d-flex justify-content-center mb-4'>
            <MDBCheckbox name='flexCheck' id='flexCheckDefault' label='I have read and agree to the terms' />
          </div>

          <MDBBtn onClick = {() => handleSave()} className="mb-4 w-100">Sign up</MDBBtn>

        </MDBTabsPane>

      </MDBTabsContent>
           
    </MDBContainer>



  );
}

export default LoginRegister;