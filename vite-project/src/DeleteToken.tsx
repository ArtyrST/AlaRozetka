////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!

import {Navigate} from 'react-router-dom'

const DeleteToken = () => {
    localStorage.removeItem('token'); 
    return <Navigate to="/login" replace />;
};

export default DeleteToken;

////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!