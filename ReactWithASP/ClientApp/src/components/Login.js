import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';
import companyLogo from '../images/daisy-logo.jpg';
import backgroundImg from '../images/LoginPageLeft.jpg';

const Login = ({ onLogin }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const navigate = useNavigate(); // ✅ Initialize navigation

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch('http://localhost:5014/api/login/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ agentUsername: username, agentPassword: password }),
            });

            if (response.ok) {
                // ✅ Save authentication state
                localStorage.setItem('isAuthenticated', 'true');
                onLogin(); // ✅ Call function to update App state

                // ✅ Redirect to home
                navigate('/home');
            } else {
                const data = await response.json();
                setErrorMessage(data.message || 'Login failed.');
            }
        } catch (error) {
            setErrorMessage('Error connecting to the server');
        }
    };

    return (
        <div className="container">
            <div className="top-side">
                <img src={backgroundImg} alt="Background" className="background-img" />
            </div>

            <div className="right-side">
                <div className="login-box">
                    <div className="logo">
                        <img src={companyLogo} alt="Company Logo" />
                    </div>
                    <div className="header">My Account – Login</div>

                    <form onSubmit={handleLogin}>
                        <div className="form-group">
                            <label htmlFor="username">Username</label>
                            <input
                                type="text"
                                id="username"
                                className="input-field"
                                required
                                value={username}
                                onChange={(e) => setUsername(e.target.value)}
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input
                                type="password"
                                id="password"
                                className="input-field"
                                required
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        </div>

                        {errorMessage && <div className="error-message">{errorMessage}</div>}

                        <div className="links">
                            <a href="/forgot-password">Forgot password?</a>
                            <a href="/create-account">Create Account</a>
                        </div>

                        <button type="submit" className="submit-btn">Sign In</button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Login;






