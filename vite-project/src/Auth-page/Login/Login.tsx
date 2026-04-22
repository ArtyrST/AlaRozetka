import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom'; 
import './Login.scss';

import logo from '../../assets/Group 3.svg';
import sideImage from '../../assets/Rectangle 53.png';

export default function Login() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    login: '', 
    password: '',
  });
  
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setError(null);
    setLoading(true);

    try {
      const params = new URLSearchParams();
      params.append('Email', formData.login);
      params.append('PasswordHash', formData.password);

      const response = await fetch('https://localhost:7147/api/user/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: params,
      });

      const result = await response.text();

      if (!response.ok) {
        throw new Error(result || 'Невірний логін або пароль');
      }


      localStorage.setItem('token', result); 
      
      console.log('Вхід успішний');
      navigate('/'); 
      
    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-wrapper">
      <div className="login-card">
        <img src={logo} alt="EasyStay Logo" className="login-logo" />

        <h1>Відкривай цікаві</h1>
        <h1>місця з нами</h1>

        <form onSubmit={handleSubmit}>
          {error && <div className="error-message" style={{ color: 'red', marginBottom: '10px' }}>{error}</div>}
          
          <div className="form-field">
            <label htmlFor="login">Логін</label>
            <input
              type="text"
              id="login"
              name="login" 
              value={formData.login}
              onChange={handleChange}
              required
            />
          </div>

          <div className="form-field">
            <label htmlFor="password">Пароль</label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              required
            />
          </div>

          <div className="login-cta">
            <button type="submit" disabled={loading}>
              {loading ? 'Вхід...' : 'Вхід'}
            </button>
          </div>

          <p>
            У вас немає акаунту? <Link to="/register">Зареєструватись</Link>
          </p>
        </form>
      </div>

      <div
        className="side-image"
        style={{ backgroundImage: `url(${sideImage})` }}
        aria-hidden="true"
      ></div>
    </div>
  );
}