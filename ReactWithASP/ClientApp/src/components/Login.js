import React from 'react';
import './Login.css';
import companyLogo from '../Images/daisy-logo.jpg';


const Login = () => {
    return (
        <body className="login-body">
            <div className="login-container">
                <div className="login-left-side"></div>

                {/* Right Side (Login Form and Logo) */}
                <div className="login-right-side">
                    <div className="login-box">
                        {/* Logo at the top of the right side */}
                        <div className="login-logo">
                            <img src={companyLogo} alt="Company Logo" />
                        </div>
                        {/* Header: My Account - Login */}
                        <div className="login-header">My Account – Login</div>

                        <form>
                            {/* Username Input */}
                            <div className="form-group">
                                <label htmlFor="username">Username</label>
                                <input type="text" id="username" name="username" className="login-input-field" required />
                            </div>

                            {/* Password Input */}
                            <div className="form-group">
                                <label htmlFor="password">Password</label>
                                <input type="password" id="password" name="password" className="login-input-field" required />
                            </div>

                            {/* Links for Forgot Password and Create Account */}
                            <div className="login-links">
                                <a href="/forgot-password">Forgot password?</a>
                                <a href="/forgot-password">Create Account</a>
                            </div>

                            {/* Submit Button */}
                            <button type="submit" className="login-submit-btn">Sign In</button>
                        </form>
                    </div>
                </div>
            </div>
        </body>
    );
};

export default Login;



