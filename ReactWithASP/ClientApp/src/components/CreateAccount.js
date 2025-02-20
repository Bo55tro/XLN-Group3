import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './CreateAccount.css';

const CreateAccount = () => {
    const [agentName, setAgentName] = useState('');
    const [agentUsername, setAgentUsername] = useState('');
    const [agentPassword, setAgentPassword] = useState('');
    const [message, setMessage] = useState('');
    const navigate = useNavigate();

    const handleCreateAccount = async (e) => {
        e.preventDefault();
        setMessage('');

        try {
            const response = await fetch('http://localhost:5014/api/create-account', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    agentName,
                    agentUsername,
                    agentPassword,
                }),
            });

            const data = await response.json();

            if (response.ok) {
                setMessage(data.message);
                setTimeout(() => {
                    navigate('/login'); // Redirect to login after success
                }, 2000);
            } else {
                setMessage(data.message || 'Failed to create account.');
            }
        } catch (error) {
            setMessage('Error connecting to the server.');
        }
    };

    return (
        <div className="container">
            <div className="form-box">
                <h2>Create Account</h2>
                <form onSubmit={handleCreateAccount}>
                    <div>
                        <label>Full Name:</label>
                        <input
                            type="text"
                            value={agentName}
                            onChange={(e) => setAgentName(e.target.value)}
                            required
                        />
                    </div>
                    <div>
                        <label>Username:</label>
                        <input
                            type="text"
                            value={agentUsername}
                            onChange={(e) => setAgentUsername(e.target.value)}
                            required
                        />
                    </div>
                    <div>
                        <label>Password:</label>
                        <input
                            type="password"
                            value={agentPassword}
                            onChange={(e) => setAgentPassword(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit">Create Account</button>
                </form>
                {message && <div className="message">{message}</div>}
            </div>
        </div>
    );
};

export default CreateAccount;
