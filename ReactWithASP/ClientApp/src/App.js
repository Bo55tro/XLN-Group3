import { Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/Login';
import Dashboard from './components/Dashboard';
import ForgotPassword from './components/ForgotPassword';
import CreateAccount from './components/CreateAccount';

const App = () => {
    return (
        <Routes>
            {/* Define route for Login */}
            <Route path="/login" element={<Login />} />

            {/* Define route for Dashboard */}
            <Route path="/dashboard" element={<Dashboard />} />

            <Route path="/forgot-password" element={<ForgotPassword />} /> {/* Correct usage of element */}

            <Route path="/create-account" element={<CreateAccount />} />

            {/* Default route - Redirect to Login */}
            <Route path="/" element={<Navigate to="/login" />} />
        </Routes>
    );
};

export default App;


