import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';
import companyLogo from '../Images/daisy-logo.jpg';

const Login = ({ onLogin }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        if (username === 'admin' && password === 'password') {
            onLogin(); // Calls login function from `App.js`
            navigate('/home'); // Redirect to Home
        } else {
            alert('Invalid username or password');
        }
    };

    return (
        <div className="login-body"> {/* Changed from <body> to <div> */}
            <div className="login-container">
                {/* Left Side */}
                <div className="login-left-side"></div>

                {/* Right Side (Login Form and Logo) */}
                <div className="login-right-side">
                    <div className="login-box">
                        {/* Logo */}
                        <div className="login-logo">
                            <img src={companyLogo} alt="Company Logo" />
                        </div>

                        {/* Header */}
                        <div className="login-header">My Account – Login</div>

                        {/* Login Form */}
                        <form onSubmit={handleLogin}>
                            {/* Username Input */}
                            <div className="form-group">
                                <label htmlFor="username">Username</label>
                                <input 
                                    type="text" 
                                    id="username" 
                                    name="username" 
                                    className="login-input-field" 
                                    value={username}
                                    onChange={(e) => setUsername(e.target.value)}
                                    required 
                                />
                            </div>

                            {/* Password Input */}
                            <div className="form-group">
                                <label htmlFor="password">Password</label>
                                <input 
                                    type="password" 
                                    id="password" 
                                    name="password" 
                                    className="login-input-field" 
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    required 
                                />
                            </div>

                            {/* Links */}
                            <div className="login-links">
                                <a href="/forgot-password">Forgot password?</a>
                            </div>

                            {/* Submit Button */}
                            <button type="submit" className="login-submit-btn">Sign In</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
