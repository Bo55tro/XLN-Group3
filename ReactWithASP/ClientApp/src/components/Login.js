import React from 'react';
import './Login.css';
import companyLogo from '../Images/daisy-logo.jpg'; // Adjust the path as necessary
import backgroundImg from '../Images/LoginPageLeft.jpg'; // Adjust the path as necessary


const Login = () => {
    return (
        <div className="container">
            <div className="top-side">
                <img src={backgroundImg} alt="Background" className="background-img" />
            </div>


            {/* Right Side (Login Form and Logo) */}
            <div className="right-side">
                <div className="login-box">
                    {/* Logo at the top of the right side */}
                    <div className="logo">
                        <img src={companyLogo} alt="Company Logo" />
                    </div>
                    {/* Header: My Account - Login */}
                    <div className="header">My Account – Login</div>

                    <form>
                        {/* Username Input */}
                        <div className="form-group">
                            <label htmlFor="username">Username</label>
                            <input type="text" id="username" name="username" className="input-field" required />
                        </div>

                        {/* Password Input */}
                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input type="password" id="password" name="password" className="input-field" required />
                        </div>

                        {/* Links for Forgot Password and Create Account */}
                        <div className="links">
                            <a href="/forgot-password">Forgot password?</a>
                            <a href="/forgot-password">Create Account</a>
                        </div>

                        {/* Submit Button */}
                        <button type="submit" className="submit-btn">Sign In</button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Login;



