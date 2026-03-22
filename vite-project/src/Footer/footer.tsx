import './footer.css';
import { useEffect, useState } from 'react';

function Footer() {
  const [email, setEmail] = useState('');

  useEffect(() => {
    const scriptId = 'weatherwidget-io-js';

    if (!document.getElementById(scriptId)) {
      const script = document.createElement('script');
      script.id = scriptId;
      script.src = 'https://weatherwidget.io/js/widget.min.js';
      script.async = true;
      document.body.appendChild(script);
    } else {
      // якщо скрипт уже є, пробуємо оновити віджет
      const w = window as Window & {
        __weatherwidget_init?: () => void;
      };

      if (typeof w.__weatherwidget_init === 'function') {
        w.__weatherwidget_init();
      }
    }
  }, []);

  const validateEmail = (value: string): boolean => {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(value);
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (validateEmail(email)) {
      alert(`Дякуємо за підписку! На адресу ${email} будуть надходити наші новини.`);
      setEmail('');
    } else {
      alert('Будь ласка, введіть коректну email адресу');
    }
  };

  return (
    <footer className="footer">
      <div className="footer-container">
        <div className="footer-logo">
          <img src="../src/assets/Group 3_white.svg" alt="Eásystay logo" />
          <p data-i18n="footer.line1">Найкращі пропозиції житла для</p>
          <p data-i18n="footer.line2">комфортного відпочинку!</p>
        </div>

        <div className="footer-section">
          <h3 data-i18n="footer.info">Загальна інформація</h3>
          <ul>
            <li>
              <a href="../About-us/about-us.html" data-i18n="footer.about">
                Про Eásystay
              </a>
            </li>
            <li>
              <a href="../Contacts/contacts.html" data-i18n="footer.how">
                Як ми працюємо
              </a>
            </li>
            <li>
              <a href="../Contacts/contacts.html" data-i18n="footer.partners">
                Для партнерів
              </a>
            </li>
          </ul>
        </div>

        <div className="footer-section">
          <h3 data-i18n="footer.rules">Правила та умови</h3>
          <ul>
            <li>
              <a href="#" data-i18n="footer.user_agreement">
                Користувацька угода
              </a>
            </li>
            <li>
              <a href="#" data-i18n="footer.terms">
                Правила та умови
              </a>
            </li>
            <li>
              <a href="../Contacts/contacts.html" data-i18n="footer.support">
                Підтримка
              </a>
            </li>
          </ul>
        </div>

        <div className="newsletter">
          <h3 data-i18n="footer.news">Отримувати новини про знижки</h3>

          <form className="newsletter-form" onSubmit={handleSubmit}>
            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Електронна пошта"
              data-i18n="footer.email.placeholder"
            />
            <button type="submit" data-i18n="footer.subscribe">
              Підписатися
            </button>
          </form>
        </div>
      </div>

      <a
        className="weatherwidget-io"
        href="https://forecast7.com/en/49d8424d03/lviv/"
        data-label_1="LVIV"
        data-label_2="WEATHER"
        data-theme="original"
        data-basecolor="#3F523C"
        data-highcolor="#f8f8f8"
        data-lowcolor="#ffffff"
        data-cloudfill="#ffffff"
        data-raincolor="#2cd2ff"
      >
        LVIV WEATHER
      </a>
    </footer>
  );
}

export default Footer;