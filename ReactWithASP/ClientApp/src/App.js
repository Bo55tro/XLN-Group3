import React, { useState, useEffect } from 'react';
import { Route, Routes, Navigate, useNavigate } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import CaseCreationpage from './components/CaseCreationpage';
import './custom.css';
import Login from './components/Login';
import ForgotPassword from './components/ForgotPassword';
import { Home } from './components/Home';
import { CategoriesGrid } from "./components/Home";
import CategoryDetailsPage from './components/CategoryDetailsPage';


function App() {
    const [isAuthenticated, setIsAuthenticated] = useState(true); // Always treat user as authenicated TEMP!
    const navigate = useNavigate();

    useEffect(() => {
        setIsAuthenticated(true); // Always treat user as authenicated TEMP!
    }, []);

    const handleLogin = (e) => {
        e.preventDefault();
        window.location.href = "/home"; // Redirect directly to home
    };

    const handleLogout = () => {
        setIsAuthenticated(false);
        localStorage.removeItem('isAuthenticated');
        navigate('/login'); // Redirect to login after logout
    };
    
    return (
        <div>
            <Layout onLogout={handleLogout} />

            <Routes>
                <Route path="/" element={<Navigate to="/home" />} />
                <Route path="/login" element={<Login onLogin={handleLogin} />} />
                <Route path="/home" element={<Home />} />
                <Route path="/create-case" element={<CaseCreationpage />} />
                <Route path="/forgot-password" element={<ForgotPassword />} />
                <Route path="/category/:categoryId" element={<CategoryDetailsPage />} />

                {AppRoutes.map((route, index) => {
                    return <Route key={index} {...route} />;
                })}
            </Routes>
        </div>
    );
}


export default App;
