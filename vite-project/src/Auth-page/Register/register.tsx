import React, { useState } from 'react';
import { Link , useNavigate} from 'react-router-dom';

import './register.scss';

import logo from '../../assets/Group 3.svg';
import sideImage from '../../assets/Rectangle 53.png';



export default function Register() {
  const navigate = useNavigate();

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [formData, setFormData] = useState({
    name: '',
    surname: '',
    email: '',
    login: '',
    password: '',
    confirmPassword: '',
  });


const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    setFormData(prev => ({
      ...prev,
      [name]: value,
    }));
  };



  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
  e.preventDefault();
  setError(null);


  if (formData.password !== formData.confirmPassword) {
    setError('Паролі не збігаються');
    return;
  }

  setLoading(true);

  try {
    // Створюємо об'єкт параметрів відповідно до RegisterUserDto
    const params = new URLSearchParams();
    params.append('FirstName', formData.name);     
    params.append('SecondName', formData.surname);  
    params.append('Email', formData.email);         
    params.append('Login', formData.login);        
    params.append('Password', formData.password);   

    const response = await fetch('https://localhost:7147/api/user/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded',
      },
      body: params,
    });

    
    const result = await response.text();

    navigate('/login');
    
  } catch (err: any) {
    setError(err.message);
  } finally {
    setLoading(false);
  }
};

  return (
    <div className="register-wrapper">
      <div className="register-card">
        <img src={logo} alt="Logo" className="register-logo" />
        <h1>Відкривай цікаві місця з нами</h1>

        {/* Вивід помилки */}
        {error && <p className="error-text" style={{color: 'red'}}>{error}</p>}

        <form onSubmit={handleSubmit}>
          <div className="form-field">
            <label>Ім&apos;я</label>
            <input type="text" name="name" value={formData.name} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label>Прізвище</label>
            <input type="text" name="surname" value={formData.surname} onChange={handleChange} />
          </div>

          <div className="form-field">
            <label>Пошта</label>
            <input type="email" name="email" value={formData.email} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label>Логін</label>
            <input type="text" name="login" value={formData.login} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label>Пароль</label>
            <input type="password" name="password" value={formData.password} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label>Підтвердження паролю</label>
            <input type="password" name="confirmPassword" value={formData.confirmPassword} onChange={handleChange} required />
          </div>

          <div className="register-cta">
            <button type="submit" disabled={loading}>
              {loading ? 'Реєстрація...' : 'Зареєструватись'}
            </button>
          </div>
        </form>
        <p>У вас вже є акаунт? <Link to="/login">Увійти</Link></p>
      </div>

      <div className="side-image" style={{ backgroundImage: `url(${sideImage})` }}></div>
    </div>
  );
}