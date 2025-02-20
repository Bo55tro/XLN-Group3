import React, { useState, useEffect } from 'react';
import { Route, Routes, Navigate, useNavigate } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import CaseCreationPage from './components/CaseCreationPage';
import './custom.css';
import Login from './components/Login';
import ForgotPassword from './components/ForgotPassword';
import CreateAccount from './components/CreateAccount';
import { Home } from './components/Home';

function App() {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        // ✅ Check if user is already logged in (stored in localStorage)
        const authStatus = localStorage.getItem('isAuthenticated') === 'true';
        setIsAuthenticated(authStatus);
    }, []);

    const handleLogin = () => {
        setIsAuthenticated(true);
        localStorage.setItem('isAuthenticated', 'true');
        navigate('/home'); // ✅ Redirect to home after login
    };

    const handleLogout = () => {
        setIsAuthenticated(false);
        localStorage.removeItem('isAuthenticated');
        navigate('/login'); // ✅ Redirect to login after logout
    };

    return (
        <div>
            {/* ✅ Show Navbar only when authenticated */}
            {isAuthenticated && <Layout onLogout={handleLogout} />}

            <Routes>
                {/* ✅ Default Route - Redirect to Login if not authenticated */}
                <Route path="/" element={!isAuthenticated ? <Navigate to="/login" /> : <Navigate to="/home" />} />

                {/* ✅ Login Route - Pass onLogin function */}
                <Route path="/login" element={<Login onLogin={handleLogin} />} />

                {/* ✅ Home Route (Protected) */}
                <Route path="/home" element={isAuthenticated ? <Home /> : <Navigate to="/login" />} />

                {/* ✅ Other Routes */}
                <Route path="/forgot-password" element={<ForgotPassword />} />
                <Route path="/create-account" element={<CreateAccount />} />
                <Route path="/create-case" element={isAuthenticated ? <CaseCreationPage /> : <Navigate to="/login" />} />

                {/* ✅ Dynamic Routes from AppRoutes (Protected) */}
                {AppRoutes.map((route, index) => (
                    <Route
                        key={index}
                        path={route.path}
                        element={isAuthenticated ? route.element : <Navigate to="/login" />}
                    />
                ))}
            </Routes>
        </div>
    );
}

export default App;




