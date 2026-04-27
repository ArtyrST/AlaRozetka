import arrowImg from '../../../Assets/arrow.png';
import './carousel.css';
import type { Hotel } from '../../../Services/types/hotel.types';
import { hotelService } from '../../../Services/hotelService';
import { useEffect, useMemo, useState, type JSX } from 'react';


function Carousel(): JSX.Element {
  const [hotels, setHotels] = useState<Hotel[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');

  const [currentIndex, setCurrentIndex] = useState(0);
  const itemsToShow = 1;

useEffect(() => {
    const loadData = async () => {
      try {
        setLoading(true);
        const data = await hotelService.getAll();
        setHotels(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Сталася помилка');
      } finally {
        setLoading(false);
      }
    };
    loadData();


 
  }, []);

    if (loading) return <div className="loading">Завантаження...</div>;
    if (error) return <div className="error">Помилка: {error}</div>;
  

  
const nextSlide = () => {
  if (hotels.length === 0) return;
  const maxIndex = hotels.length - 1;
  setCurrentIndex((prev) => (prev === maxIndex ? 0 : prev + 1));
};

const prevSlide = () => {
  if (hotels.length === 0) return;
  const maxIndex = hotels.length - 1;
  setCurrentIndex((prev) => (prev === 0 ? maxIndex : prev - 1));
};


   return (
  <div className="body-carousel">
    <div className="carousel-container">
      <div className="background-image"></div>
      <h2 data-i18n="best.offers">Найкращі пропозиції</h2>

      <div className="carousel" style={{ overflow: 'hidden' }}> 
        <div 
          className="carousel-track" 
          style={{ 
            display: 'flex',
            transition: 'transform 0.5s ease-in-out',
            transform: `translateX(-${currentIndex * 20}%)` 
          }}
        >
          {hotels.map((hotel, index) => {
  const styleIndex = (index % 4) + 1;

  return (
    <div 
      className={`item item${styleIndex}`} 
      key={hotel.id}
      style={{ 
        flexShrink: 0,
      }}
    >
      <div 
        className="item-image-bg" 
      ><img className="item-image" src={hotel.displayImage}  /></div>
      <div className="item-content">
        <h3>{hotel.country}</h3>
        <p>{hotel.name}</p>
        <div className="year">від {hotel.price}₴</div>
      </div>
    </div>
  );
})}
        </div>
      </div>

      <div className="buttons">
        <button className="prev" onClick={prevSlide} type="button">
          <img src={arrowImg} alt="Previous" />
        </button>

        <button className="next" onClick={nextSlide} type="button">
          <img src={arrowImg} alt="Next" />
        </button>
      </div>
    </div>
  </div>
);
}
export default Carousel;