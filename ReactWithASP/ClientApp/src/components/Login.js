import React from 'react';
import './Login.css';
import companyLogo from '../Images/daisy-logo.jpg';

const Login = () => {
    const handleLogin = (e) => {
        e.preventDefault();
        window.location.href = "/home"; // ✅ Instantly redirects to home page
    };

    return (
        <div className="login-body">
            <div className="login-container">
                <div className="login-left-side"></div>
                <div className="login-right-side">
                    <div className="login-box">
                        <div className="login-logo">
                            <img src={companyLogo} alt="Company Logo" />
                        </div>
                        <div className="login-header">My Account – Login</div>
                        <form onSubmit={handleLogin}>
                            <button type="submit" className="login-submit-btn">Sign In</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
