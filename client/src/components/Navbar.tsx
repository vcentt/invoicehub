import React from 'react';
import { Link } from 'react-router-dom';
import logo from '../logo.png'

const Navbar: React.FC = () => {
    return (
        <nav className="navbar navbar-light bg-dark">
          <div className="container">
            <Link to="/" className="navbar-brand">
              <img src={logo} width={55} alt="Logo" className="navbar-logo" />
                I N V O C E H U B
            </Link>
          </div>
        </nav>
      );
};

export default Navbar