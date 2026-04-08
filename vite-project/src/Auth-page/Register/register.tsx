import React, { useState } from 'react';
import './register.scss';

import logo from '../../assets/Group 3.svg';
import sideImage from '../../assets/Rectangle 53.png';
import { Link } from 'react-router-dom';

type Role = 'client' | 'agent';

export default function Register() {
  const [formData, setFormData] = useState({
    name: '',
    surname: '',
    email: '',
    login: '',
    password: '',
    role: 'client' as Role,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value, type } = e.target;

    if (type === 'radio') {
      setFormData((prev) => ({
        ...prev,
        role: value as Role,
      }));
      return;
    }

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

    console.log('Форма реєстрації:', formData);

    // тут потім сам додаси navigate або API
    // наприклад:
    // navigate('/');
  };

  return (
    <div className="register-wrapper">
      <div className="register-card">
        <img src={logo} alt="EasyStay Logo" className="register-logo" />

        <h1>Відкривай цікаві</h1>
        <h1>місця з нами</h1>

        <form onSubmit={handleSubmit}>
          <div className="form-field">
            <label htmlFor="name">Ім&apos;я</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </div>

          <div className="form-field">
            <label htmlFor="surname">Прізвище</label>
            <input
              type="text"
              id="surname"
              name="surname"
              value={formData.surname}
              onChange={handleChange}
            />
          </div>

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

          <div className="form-field">
            <label htmlFor="password">Підтвердження паролю</label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              required
            />
          </div>

          <div className="checkbox-row">
            <label className="role-option">
              <input
                type="radio"
                name="role"
                value="client"
                checked={formData.role === 'client'}
                onChange={handleChange}
              />
              <span className="box"></span>
              <span className="text">Я клієнт</span>
            </label>

            <label className="role-option">
              <input
                type="radio"
                name="role"
                value="agent"
                checked={formData.role === 'agent'}
                onChange={handleChange}
              />
              <span className="box"></span>
              <span className="text">Я рієлтор</span>
            </label>
          </div>

          <div className="register-cta">
            <button type="submit">Зареєструватись</button>
          </div>

          <p>
            У вас вже є акаунт? <Link to="/login">Увійти</Link>
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