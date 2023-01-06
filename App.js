import React, { Component } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import LoginRegister from './components/users/LoginRegister';
import Orders from './components/users/Orders';
import Dashboard from './components/users/Dashboard';
import Profile from './components/users/Profile';
import Contact from './components/users/Contact';
import BarChart from './components/users/BarChart';
import './App.css';
import LineChart from './components/users/LineChart';
import PieChart from './components/users/PieChart';
import Registeranalytics from './components/users/Registeranalytics';


class App extends Component {
  render() {
    return (
      <Router>
      <div>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <ul className="navbar-nav mr-auto">
            <div class="logo-holder logo">
            <Link to={'/'} className="nav-link"><h3>Online<span>Shopper</span></h3></Link>
            </div>
            <li><Link to={'/'} className="nav-link"><h4>Home</h4></Link></li>
            <li><Link to={'/Profile'} className="nav-link"> <h4>Profile</h4> </Link></li>       
            <li><Link to={'/Login'} className="nav-link"> <h4>Login</h4> </Link></li>
            <li><Link to={'/contact'} className="nav-link"><h4>contact</h4></Link></li>
            <li><Link to={'/Orders'} className="nav-link"><h4>Orders</h4></Link></li>
            <li><Link to={'/BarChart'} className="nav-link"><h4>Bar-Chart</h4></Link></li>
            <li><Link to={'/LineChart'} className="nav-link"><h4>Line-Chart</h4></Link></li>
            <li><Link to={'/PieChart'} className="nav-link"><h4>Pie-Chart</h4></Link></li>
            <li><Link to={'/Registeranalytics'} className="nav-link"><h4>Registrations</h4></Link></li>
          </ul>
          </nav>
          <hr />
          <Routes>
              <Route exact path='/' element={<Dashboard />} />
              <Route exact path='/Login' element={<LoginRegister />} />
              <Route exact path='/Orders' element={<Orders/> } />
              <Route exact path='/Profile' element={<Profile/> } />    
              <Route exact path='/Contact' element={<Contact />} />
              <Route exact path='/BarChart' element={<BarChart />} />
              <Route exact path='/LineChart' element={<LineChart />} />
              <Route exact path='/PieChart' element={<PieChart />} />
              <Route exact path='/Registeranalytics' element={<Registeranalytics />} />
          </Routes>
          </div>
      </Router>
    );
  }
}

export default App;