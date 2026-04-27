import { Link } from "react-router-dom";
import { useEffect, useState } from 'react';
import './realtor-reviews.scss';

const RealtorReviews = () => {
  const reviews = [
    {
      id: 1,
      name: "Марія",
      text: "Розташування було дуже близько до центру міста. Господар був дуже добрим. Квартира була дуже чистою та дуже добре мебльованою. Ціна була дуже хорошою.",
      rating: 4.9
    },
    {
      id: 2,
      name: "Марія",
      text: "Розташування було дуже близько до центру міста. Господар був дуже добрим. Квартира була дуже чистою та дуже добре мебльованою. Ціна була дуже хорошою.",
      rating: 4.9
    },
    {
      id: 3,
      name: "Марія",
      text: "Розташування було дуже близько до центру міста. Господар був дуже добрим. Квартира була дуже чистою та дуже добре мебльованою. Ціна була дуже хорошою.",
      rating: 4.9
    },
    {
      id: 4,
      name: "Марія",
      text: "Розташування було дуже близько до центру міста. Господар був дуже добрим. Квартира була дуже чистою та дуже добре мебльованою. Ціна була дуже хорошою.",
      rating: 4.9
    },
  ];

  return (
    <div className="reviews-conteiner"> 
    <h1 className="reviews-title">Відгуки</h1>
    <div className="reviews-grid">
      {reviews.length === 0 ? (
        <div className="reviews-empty">
          Нічого не знайдено.
        </div>
      ) : (
        reviews.map((review) => (
          <div className="review-card" key={review.id}>
            <div className="review-content">
              <div className="review-header">
                <span className="review-author">{review.name}</span>
                <div className="review-rating">
                  <span className="star">★</span> {review.rating}
                </div>
              </div>
              <p className="review-text">{review.text}</p>
            </div>
          </div>
        ))
      )}
    </div>
    <div className="review-div">
        <button className="show-more-review-btn">Більше відгуків</button>  
    </div>
    </div>
  );
};

export default RealtorReviews;