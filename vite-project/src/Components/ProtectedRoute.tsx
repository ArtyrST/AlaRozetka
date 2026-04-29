////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!

import { Navigate } from 'react-router-dom';
import { type ReactNode } from 'react';

interface Props {
  children: ReactNode;
}

const ProtectedRoute = ({ children }: Props) => {
  const token = localStorage.getItem('token');

  // Якщо токена немає — відправляємо на логін
  if (!token) {
    return <Navigate to="/login" replace />;
  }

  // Якщо токен є — показуємо те, що "загорнуто" в цей компонент
  return <>{children}</>;
};

export default ProtectedRoute;

////ТЕСТ ХУЙНЯ!!!!!!!!!!!!!!!!!!!