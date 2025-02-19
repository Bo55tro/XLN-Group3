import React, { useState } from 'react';

const ForgotPassword = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        // Basic input validation
        if (!username || !email) {
            setMessage("Please fill in both username and email.");
            return;
        }

        // Call backend API to handle the forgot password logic
        fetch('/api/forgot-password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, email }),
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.message) {
                    setMessage(data.message); // Show success or failure message
                }
            })
            .catch((error) => {
                console.error("Error:", error);
                setMessage("Error sending email. Please try again.");
            });
    };

    return (
        <div className="forgot-password">
            <h2>Forgot Password</h2>
            {message && <p>{message}</p>}
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="username">Username</label>
                    <input
                        type="text"
                        id="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        placeholder="Enter username"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input
                        type="email"
                        id="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        placeholder="Enter email"
                    />
                </div>
                <button type="submit">Send Password</button>
            </form>
        </div>
    );
};

export default ForgotPassword;


