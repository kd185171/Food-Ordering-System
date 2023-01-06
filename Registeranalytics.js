import { useEffect, useState } from "react";

import { Bar} from "react-chartjs-2";

import { Chart,LinearScale,CategoryScale,BarElement,Tooltip} from "chart.js";

import axios from "axios";

Chart.register(LinearScale,CategoryScale,BarElement,Tooltip)

 

function Registeranalytics(){

const [loggeddate,setloggeddate]=useState([]);

const [noofpersons,setnoofpersons]=useState([]);

const data={

    labels:loggeddate,

    datasets:[

        {

            label:"No Of Registations",

            data:noofpersons,

            BackGroundColor:"pink"

        }

    ]

};

const options={

   

    Plugins:{

        legend:{

            position:"top"

        },

    }

};

const url="https://localhost:44305/api/Users/Getregisters";
useEffect(()=>{
axios.get(url).then(res=>{

    console.log(res.data)

    setloggeddate(res.data.loggeddatearray);

    setnoofpersons(res.data.noofpersonsarray);

})},[])

 

return(<div><nav className="nav"><h5>No of Registations Per Day</h5></nav>

<div className="container" style={{height:500,width:1000,responsive:"true",maintainAspectRatio:"true"}}><Bar data={data} options={options}/></div></div>)

}

export default Registeranalytics;