import React, { useState } from 'react';
import './realtor-profile.scss';
import RealtorFullInfo from './realtor-full-info/realtor-full-info.tsx';


const RealtorProfile = () => {
  const [activeItem, setActiveItem] = useState('Головна');

  const menuItems = [
    'Головна',
    'Особисті дані',
    'Мої готелі',
    'Відгуки',
    'Архів',
    'Знижки'
  ];

  const renderContent = () => {
    switch (activeItem) {
      case 'Особисті дані':
        return <RealtorFullInfo />;
      case 'Мої готелі':
        return <div>{/* <MyHotels /> */}</div>;
      case 'Відгуки':
        return <div></div>;
      case 'Головна':
      default:
        return <div></div>;
    }
  };

  return (
    <div className="profile-page">
      
      <aside className="sidebar">
        <div className="profile-card">
          <img 
            src='/src/assets/realtor.jpg'
            alt="Дмитро Романчук" 
            className="avatar"
          />
          <h2 className="profile-name">Дмитро Романчук</h2>
        </div>

        <nav className="navigation">
          <ul>
            {menuItems.map((item, index) => (
              <li 
                key={index} 
                className={item === activeItem ? 'active' : ''} 
                onClick={() => setActiveItem(item)} // Змінюємо стан при кліку
                style={{ cursor: 'pointer' }}
              >
                {item}
              </li>
            ))}
          </ul>
        </nav>
      </aside>

    
      <main className="main-realtor-content">
        {renderContent()}
      </main>
    </div>
  );
};

export default RealtorProfile;