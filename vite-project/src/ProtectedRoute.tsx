////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!

import {Navigate} from 'react-router-dom';

const ProtectedRoute = () => {
    const token = localStorage.getItem('token');

    if (!token) {
        return <Navigate to="/login" replace />;
    }

    return <Navigate to="/Realtor" replace />;
};

export default ProtectedRoute;

////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!