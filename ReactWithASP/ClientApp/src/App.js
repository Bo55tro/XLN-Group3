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
