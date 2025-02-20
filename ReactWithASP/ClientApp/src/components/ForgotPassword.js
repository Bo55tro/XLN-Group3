import React, { useState } from 'react';

const ForgotPassword = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');

    const handleResetPassword = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch('http://localhost:5014/api/forgot-password', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    agentUsername: username,
                    email: email,
                }),
            });

            const data = await response.json();
            setMessage(data.message || (response.ok ? 'Password reset successful.' : 'Failed to reset password.'));
        } catch (error) {
            setMessage('Error connecting to the server');
        }
    };

    return (
        <div style={styles.container}>
            <div style={styles.formContainer}>
                <h2 style={styles.title}>Forgot Password</h2>
                <form onSubmit={handleResetPassword}>
                    <div style={styles.inputGroup}>
                        <label style={styles.label}>Username:</label>
                        <input
                            type="text"
                            style={styles.input}
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <div style={styles.inputGroup}>
                        <label style={styles.label}>Email:</label>
                        <input
                            type="email"
                            style={styles.input}
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                    </div>
                    <button type="submit" style={styles.button}>Reset Password</button>
                </form>
                {message && <div style={styles.message}>{message}</div>}
            </div>
        </div>
    );
};

const styles = {
    container: {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        height: '100vh',
        width: '50vh',
        backgroundColor: '#f0f8ff', // Light blue background
    },
    formContainer: {
        backgroundColor: '#fff',
        padding: '2rem',
        borderRadius: '8px',
        boxShadow: '0px 4px 6px rgba(0, 0, 0, 0.1)',
        width: '100%',
        maxWidth: '400px',
        textAlign: 'center',
    },
    title: {
        marginBottom: '1rem',
        color: '#007bff', // Blue text
    },
    inputGroup: {
        marginBottom: '1rem',
        textAlign: 'left',
    },
    label: {
        display: 'block',
        fontWeight: 'bold',
        marginBottom: '0.5rem',
        color: '#333',
    },
    input: {
        width: '100%',
        padding: '0.5rem',
        borderRadius: '4px',
        border: '1px solid #ccc',
    },
    button: {
        width: '100%',
        padding: '0.75rem',
        backgroundColor: '#007bff',
        color: '#fff',
        border: 'none',
        borderRadius: '4px',
        cursor: 'pointer',
        fontSize: '1rem',
    },
    message: {
        marginTop: '1rem',
        fontWeight: 'bold',
        color: '#d9534f', // Red for errors
    },
};

export default ForgotPassword;






