import React, { useState } from 'react';
import './Login.css';
import companyLogo from '../Images/daisy-logo.jpg'; 

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();

        const loginData = {
            agentUsername: username,
            agentPassword: password,
        };

        try {
            const response = await fetch('https://localhost:5001/api/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(loginData),
            });

            const result = await response.json();

            // If login is successful, redirect to the dashboard
            if (response.ok) {
                window.location.href = '/home'; // Replace with the path to your dashboard page
            } else {
                setError(result.message || 'Invalid username or password');
            }
        } catch (err) {
            setError('Something went wrong, please try again later.');
        }
    };

    return (
        <div className="login-body">
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

                            {/* Error Message */}
                            {error && <div className="error-message">{error}</div>}

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