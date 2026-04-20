import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './register.scss';

import logo from '../../assets/Group 3.svg';
import sideImage from '../../assets/Rectangle 53.png';

type Role = 'client' | 'agent';

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
    role: 'client' as Role,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value, type } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === 'radio' ? value as Role : value,
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
    // 1. Готуємо дані у форматі x-www-form-urlencoded
    const params = new URLSearchParams();
    params.append('FirstName', formData.name);
    params.append('SecondName', formData.surname);
    params.append('Email', formData.email);
    params.append('Login', formData.login);
    params.append('Password', formData.password);


    // 2. Робимо запит
    const response = await fetch('https://localhost:7147/api/user/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded',
      },
      body: params, // Fetch автоматично перетворить URLSearchParams у потрібний рядок
    });

    const body = await response.text(); // ASP.NET часто повертає текст або JSON

    if (!response.ok) {
      throw new Error(body || 'Помилка реєстрації');
    }

    console.log('Відповідь сервера:', body);
    
    // Якщо сервер повертає токен у відповіді, зберігаємо його
    // Наприклад, якщо body - це JSON рядок з токеном:
    // const data = JSON.parse(body);
    // localStorage.setItem('token', data.token);

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
        <h1>Відкривай цікаві</h1>
        <h1>місця з нами</h1>

        {error && <p style={{ color: 'red', fontSize: '14px' }}>{error}</p>}

        <form onSubmit={handleSubmit}>
          <div className="form-field">
            <label htmlFor="name">Ім&apos;я</label>
            <input type="text" id="name" name="name" value={formData.name} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label htmlFor="surname">Прізвище</label>
            <input type="text" id="surname" name="surname" value={formData.surname} onChange={handleChange} />
          </div>

          <div className="form-field">
            <label htmlFor="email">Пошта</label>
            <input type="email" id="email" name="email" value={formData.email} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label htmlFor="login">Логін</label>
            <input type="text" id="login" name="login" value={formData.login} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label htmlFor="password">Пароль</label>
            <input type="password" id="password" name="password" value={formData.password} onChange={handleChange} required />
          </div>

          <div className="form-field">
            <label htmlFor="confirmPassword">Підтвердження паролю</label>
            <input type="password" id="confirmPassword" name="confirmPassword" value={formData.confirmPassword} onChange={handleChange} required />
          </div>

          <div className="checkbox-row">
            <label className="role-option">
              <input type="radio" name="role" value="client" checked={formData.role === 'client'} onChange={handleChange} />
              <span className="text">Я клієнт</span>
            </label>

            <label className="role-option">
              <input type="radio" name="role" value="agent" checked={formData.role === 'agent'} onChange={handleChange} />
              <span className="text">Я рієлтор</span>
            </label>
          </div>

          <div className="register-cta">
            <button type="submit" disabled={loading}>
              {loading ? 'Зачекайте...' : 'Зареєструватись'}
            </button>
          </div>

          <p>У вас вже є акаунт? <Link to="/login">Увійти</Link></p>
        </form>
      </div>

      <div className="side-image" style={{ backgroundImage: `url(${sideImage})` }}></div>
    </div>
  );
}