////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!

import {Navigate} from 'react-router-dom';

const ProtectedRoute = () => {
    const token = localStorage.getItem('token');

    if (!token) {
        return <Navigate to="/login" replace />;
    }

    return <Navigate to="/realtor-profile" replace />;
};

export default ProtectedRoute;

////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!