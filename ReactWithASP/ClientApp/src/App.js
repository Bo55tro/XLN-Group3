import React, { useState, useEffect } from 'react';
import { Route, Routes, Navigate, useNavigate } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import CaseCreationpage from './components/CaseCreationpage';
import './custom.css';
import Login from './components/Login';
import ForgotPassword from './components/ForgotPassword';
import { Home } from './components/Home';

function App() {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        // Check if user is already logged in (stored in localStorage)
        const authStatus = localStorage.getItem('isAuthenticated') === 'true';
        setIsAuthenticated(authStatus);
    }, []);

    const handleLogin = () => {
        setIsAuthenticated(true);
        localStorage.setItem('isAuthenticated', 'true');
        navigate('/home'); // Redirect to home after login
    };

    const handleLogout = () => {
        setIsAuthenticated(false);
        localStorage.removeItem('isAuthenticated');
        navigate('/login'); // Redirect to login after logout
    };

    // Routes configuration with authentication protection
    const appRoutesWithCreateCase = [
        ...AppRoutes,
        { path: '/create-case', element: <CaseCreationpage /> },
    ];

    return (
        <div>
            {/* Show Layout (Navbar) only if authenticated */}
            {isAuthenticated && <Layout onLogout={handleLogout} />}

            <Routes>
                {/* Default route - Redirect to Login if not authenticated */}
                <Route path="/" element={!isAuthenticated ? <Navigate to="/login" /> : <Navigate to="/home" />} />

                {/* Login Route (Pass handleLogin function to Login component) */}
                <Route path="/login" element={<Login onLogin={handleLogin} />} />

                {/* Home Route (Only accessible if authenticated) */}
                <Route path="/home" element={isAuthenticated ? <Home /> : <Navigate to="/login" />} />

                {/* Forgot Password Route */}
                <Route path="/forgot-password" element={<ForgotPassword />} />

                {/* Protected routes */}
                {appRoutesWithCreateCase.map((route, index) => {
                    const { element, ...rest } = route;
                    return (
                        <Route
                            key={index}
                            {...rest}
                            element={isAuthenticated ? element : <Navigate to="/login" />}
                        />
                    );
                })}
            </Routes>
        </div>
    );
}

export default App;
