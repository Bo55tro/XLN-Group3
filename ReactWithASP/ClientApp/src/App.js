import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes'; // Your routes configuration
import { Layout } from './components/Layout';
import CaseCreationpage from './components/CaseCreationpage'; // Import the CaseCreationpage component
import './custom.css';
import Login from './components/Login'; // Import the Login component
import Dashboard from './components/Dashboard'; // Import the Dashboard component
import ForgotPassword from './components/ForgotPassword'; // Import the ForgotPassword component
import Home from './components/Home'; // Import the Home component

export default class App extends Component {
    static displayName = App.name;

    render() {
        // Adding the "Create Case" path to the routes configuration
        const appRoutesWithCreateCase = [
            ...AppRoutes,
            {
                path: '/create-case',
                element: <CaseCreationpage /> // Adding the Create Case route here
            }
        ];

        return (
            <Layout>
                <Routes>
                    {appRoutesWithCreateCase.map((route, index) => {
                        const { element, ...rest } = route;
                        return <Route key={index} {...rest} element={element} />;
                    })}
                    {/* Define route for Login */}
                    <Route path="/login" element={<Login />} />

                    {/* Define route for Dashboard */}
                    <Route path="/dashboard" element={<Dashboard />} />

                    <Route path="/forgot-password" element={<ForgotPassword />} /> {/* Correct usage of element */}

                    {/* Default route - Redirect to Login */}
                    <Route path="/" element={<Home/>} />
                </Routes>
            </Layout>
        );
    }
}
