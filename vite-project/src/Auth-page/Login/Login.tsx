import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './login.scss';

import logo from '../../assets/Group 3.svg';
import sideImage from '../../assets/Rectangle 53.png';

export default function Login() {
  const [formData, setFormData] = useState({
    email: '',
    password: '',
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      sessionStorage.setItem('authSuccess', 'true');
    } catch (err) {
      console.error(err);
    }

    console.log('Форма логіну:', formData);

    // тут потім сам додаси navigate('/') або API
  };

  return (
    <div className="login-wrapper">
      <div className="login-card">
        <img src={logo} alt="EasyStay Logo" className="login-logo" />

        <h1>Відкривай цікаві</h1>
        <h1>місця з нами</h1>

        <form onSubmit={handleSubmit}>
          <div className="form-field">
            <label htmlFor="email">Пошта</label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
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
            <button type="submit">Вхід</button>
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