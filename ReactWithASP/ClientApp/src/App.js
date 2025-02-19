<<<<<<< Updated upstream
import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes'; // Your routes configuration
import { Layout } from './components/Layout';
import CaseCreationpage from './components/CaseCreationpage'; // Import the CaseCreationpage component
import './custom.css';

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
                </Routes>
            </Layout>
        );
    }
}
=======
import { Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/Login';
import Dashboard from './components/Dashboard';
import ForgotPassword from './components/ForgotPassword';

const App = () => {
    return (
        <Routes>
            {/* Define route for Login */}
            <Route path="/login" element={<Login />} />

            {/* Define route for Dashboard */}
            <Route path="/dashboard" element={<Dashboard />} />

            <Route path="/forgot-password" element={<ForgotPassword />} /> {/* Correct usage of element */}

            {/* Default route - Redirect to Login */}
            <Route path="/" element={<Navigate to="/login" />} />
        </Routes>
    );
};

export default App;


>>>>>>> Stashed changes
