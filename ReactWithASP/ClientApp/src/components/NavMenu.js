import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import logo from '../Images/Daisy-logo.png';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.handleLogout = this.handleLogout.bind(this);
    
    this.state = {
      collapsed: true,
      isAuthenticated: true // Always show navbar - TEMPORARY!
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  handleLogout() {
    localStorage.removeItem('isAuthenticated');
    this.setState({ isAuthenticated: false });
    window.location.href = '/login'; 
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm custom-navbar navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">
            <img src={logo} alt="Daisy Project Logo" className="nav-logo" />
          </NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="btn navbar-btn" to="/">Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="btn navbar-btn" to="/create-case">Open a Case</NavLink>
              </NavItem>

              {/* Always Show Logout - TEMPORARY! */}
              <NavItem>
                <button className="btn navbar-btn" onClick={this.handleLogout}>Logout</button>
              </NavItem>
            </ul>
          </Collapse>
        </Navbar>
      </header>
    );
  }
}

export default NavMenu;
