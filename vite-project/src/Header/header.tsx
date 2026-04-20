import { Link } from "react-router-dom";
import { useEffect, useState } from 'react';
import './header.scss';

type Language = 'uk' | 'en';

function Header() {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
  const [isLangMenuOpen, setIsLangMenuOpen] = useState(false);
  const [language, setLanguage] = useState<Language>('uk');

  useEffect(() => {
    const savedLanguage = localStorage.getItem('siteLanguage') as Language | null;

    if (savedLanguage === 'uk' || savedLanguage === 'en') {
      setLanguage(savedLanguage);
      document.dispatchEvent(
        new CustomEvent('languageChanged', {
          detail: { lang: savedLanguage },
        })
      );
    } else {
      document.dispatchEvent(
        new CustomEvent('languageChanged', {
          detail: { lang: 'uk' },
        })
      );
    }
  }, []);

  useEffect(() => {
    document.body.style.overflow = isMobileMenuOpen ? 'hidden' : 'auto';

    return () => {
      document.body.style.overflow = 'auto';
    };
  }, [isMobileMenuOpen]);

  const toggleMobileMenu = (): void => {
    setIsMobileMenuOpen((prev) => !prev);
  };

  const closeMobileMenu = (): void => {
    setIsMobileMenuOpen(false);
  };

  const toggleLangMenu = (): void => {
    setIsLangMenuOpen((prev) => !prev);
  };

  const selectLanguage = (lang: Language): void => {
    setLanguage(lang);
    localStorage.setItem('siteLanguage', lang);

    document.dispatchEvent(
      new CustomEvent('languageChanged', {
        detail: { lang },
      })
    );

    setIsLangMenuOpen(false);
  };

  const handleAnchorClick = (
    e: React.MouseEvent<HTMLAnchorElement>,
    href: string
  ): void => {
    if (!href.startsWith('#')) return;

    e.preventDefault();

    const target = document.querySelector(href);
    if (target) {
      target.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
      });
      closeMobileMenu();
    }
  };

  return (
    <>
      <header className="header">
        <a href="/Main-Page/index.html" className="logo">
          <img src="/src/assets/Group 3.svg" alt="Logo" />
        </a>

        <div className="center-section">
          <a  className="pages">
            <Link to="/">Головна</Link>
          </a>
          <a  className="pages">
            <Link to="/Catalog">Апартаменти</Link>
          </a>
          <a href="/About-us/about-us.html" className="pages">
            Про нас
          </a>
          <a className="pages">
            <Link to="/Contacts">Контакти</Link>
          </a>
        </div>

        <div className="right-section">
          <div className="dropdown-lang-container">
            <div className="elements">
              <div className="lang">
                <span className="text" data-i18n="lang.short">
                  {language === 'en' ? 'EN' : 'UA'}
                </span>
              </div>

              <button
                id="langToggleBtn"
                type="button"
                onClick={toggleLangMenu}
                aria-label="Toggle language menu"
              >
                <div className="arrow">
                  <img src="/src/assets/Vector.png" alt="Arrow" />
                </div>
              </button>
            </div>

            <div className={`lang-menu ${isLangMenuOpen ? 'active' : ''}`}>
              <button type="button" onClick={() => selectLanguage('uk')}>
                Українська
              </button>
              <button type="button" onClick={() => selectLanguage('en')}>
                English
              </button>
            </div>
          </div>

          <div className="user-section">
            <button type="button">
              <img src="/src/assets/Bell_fill.png" alt="Notifications" />
            </button>

            <a  title="Реєстрація">
              <Link to="/register" type="button">
                <img src="/src/assets/User_fill.png" alt="User" />
              </Link>
            </a>
          </div>
        </div>

        <button
          className={`mobile-menu-btn ${isMobileMenuOpen ? 'active' : ''}`}
          type="button"
          onClick={toggleMobileMenu}
          aria-label="Open mobile menu"
        >
          <span></span>
          <span></span>
          <span></span>
        </button>
      </header>

      <div
        className={`mobile-menu-overlay ${isMobileMenuOpen ? 'active' : ''}`}
        onClick={closeMobileMenu}
      ></div>

      <div className={`mobile-menu ${isMobileMenuOpen ? 'active' : ''}`}>
        <button
          id="closeMenu"
          type="button"
          onClick={closeMobileMenu}
          aria-label="Close mobile menu"
        >
          ✕
        </button>

        <a
          href="/Main-Page/index.html"
          className="mobile-page"
          onClick={closeMobileMenu}
        >
          Головна
        </a>
        <a
          href="/Apartments/apartaments.html"
          className="mobile-page"
          onClick={closeMobileMenu}
        >
          Апартаменти
        </a>
        <a
          href="/About-us/about-us.html"
          className="mobile-page"
          onClick={closeMobileMenu}
        >
          Про нас
        </a>
        <a
          href="/Contacts/contacts.html"
          className="mobile-page"
          onClick={closeMobileMenu}
        >
          Контакти
        </a>

        <a
          href="#some-section"
          className="mobile-page"
          onClick={(e) => handleAnchorClick(e, '#some-section')}
        >
          Якір
        </a>
      </div>
    </>
  );
}

export default Header;
