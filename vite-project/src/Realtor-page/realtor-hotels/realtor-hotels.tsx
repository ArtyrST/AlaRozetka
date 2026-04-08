import { Link } from "react-router-dom";
import { useEffect, useState } from 'react';
import './realtor-hotels.scss';

const RealtorHotels = () => {
  // Статичні дані замість API
  const hotels = [
    {
      id: 1,
      title: "Сучасні апартаменти в центрі",
      location: "Київ, вул. Хрещатик",
      roomType: "2-кімнатна квартира",
      realtor: "Дмитро Романчук",
      rating: 4.9,
      price: 15000,
      oldPrice: 17500,
      image: "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?q=80&w=2070&auto=format&fit=crop"
    },
    {
      id: 2,
      title: "Затишна студія біля парку",
      location: "Львів, вул. Стрийська",
      roomType: "Студія",
      realtor: "Олена Петрова",
      rating: 4.7,
      price: 12000,
      oldPrice: 13200,
      image: "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?q=80&w=1980&auto=format&fit=crop"
    },
    {
      id: 3,
      title: "Пентхаус з видом на море",
      location: "Одеса, Аркадія",
      roomType: "3-кімнатна квартира",
      realtor: "Ігор Мельник",
      rating: 5.0,
      price: 25000,
      oldPrice: null, // Тут спрацює логіка +10%, яку ти заклав
      image: "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?q=80&w=2070&auto=format&fit=crop"
    },
    {
      id: 4,
      title: "Пентхаус з видом на море",
      location: "Одеса, Аркадія",
      roomType: "3-кімнатна квартира",
      realtor: "Ігор Мельник",
      rating: 5.0,
      price: 25000,
      oldPrice: null, // Тут спрацює логіка +10%, яку ти заклав
      image: "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?q=80&w=2070&auto=format&fit=crop"
    }
  ];

  return (
    <div className="apart-conteiner">
    <h1 className="apartaments-title">Помешкання цього рієлтора</h1>
    <div className="apartments-list" id="apartmentsList">
      {hotels.length === 0 ? (
        <div className="no-results">
          Нічого не знайдено.
        </div>
      ) : (
        hotels.map((hotel) => (
          <div className="apartment-card" key={hotel.id}>
            <div className="card-image-container">
              <img
                className="apartment-img"
                src={hotel.image}
                alt={hotel.title}
              />
              <div className="favorite-icon">♡</div>
            </div>

            <div className="apartment-info">
              <div className="apartment-title">{hotel.title}</div>
              <div className="apartment-location">{hotel.location}</div>
              <div className="room-type">{hotel.roomType}</div>

              <div className="realtor-info">
                Ріелтор: <span>{hotel.realtor}</span>
              </div>

              <div className="rating-container">
                <div className="apartment-rating">
                  <span className="star">★</span> {hotel.rating}
                </div>
              </div>

              <div className="price-container">
                <div className="apartment-price">Від {hotel.price}₴</div>
                <div className="old-price">
                  {hotel.oldPrice ?? Math.round(hotel.price * 1.1)}₴
                </div>
              </div>

              <div className="apartment-cta">
                <button type="button">Обрати</button>
              </div>
            </div>
          </div>
        ))
      )}
    </div>
    <div className="show-more-wrapper">
      <button className="show-more-btn">Більше пропозицій</button>
    </div>
    </div>
  );
};

export default RealtorHotels;