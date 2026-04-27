import { useEffect, useMemo, useState, type JSX } from 'react';
import { hotelService } from '../../Services/hotelService';
import type { Hotel } from '../../Services/types/hotel.types';
import './catalog.scss';

function Catalog(): JSX.Element {
  const [hotels, setHotels] = useState<Hotel[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');

  // Стани для фільтрів
  const [isSidebarOpen, setIsSidebarOpen] = useState<boolean>(false);
  const [priceMin, setPriceMin] = useState<number>(0);
  const [priceMax, setPriceMax] = useState<number>(20000);
  const [countryInput, setCountryInput] = useState<string>('');
  const [confirmedCountry, setConfirmedCountry] = useState<string>('');
  const [selectedRatings, setSelectedRatings] = useState<number[]>([]);
  const [sortSelect, setSortSelect] = useState<string>('default');

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

  const filteredHotels = useMemo(() => {
    let filtered = hotels.filter(h => h.price >= priceMin && h.price <= priceMax);

    if (confirmedCountry.trim()) {
      filtered = filtered.filter(h => 
        h.country.toLowerCase().includes(confirmedCountry.trim().toLowerCase())
      );
    }

    const sorted = [...filtered];
    if (sortSelect === 'price_asc') sorted.sort((a, b) => a.price - b.price);
    else if (sortSelect === 'price_desc') sorted.sort((a, b) => b.price - a.price);

    return sorted;
  }, [hotels, priceMin, priceMax, confirmedCountry, sortSelect]);

  const minPercent = (priceMin / 20000) * 100;
const maxPercent = (priceMax / 20000) * 100;
  if (loading) return <div className="loading">Завантаження...</div>;
  if (error) return <div className="error">Помилка: {error}</div>;


   const resetFilters = (): void => {
  setPriceMin(0);
  setPriceMax(20000);
  setCountryInput('');
  setConfirmedCountry('');
  setSelectedRatings([]);
  setSortSelect('default');
};

// Функція для перемикання вибраних рейтингів
const toggleRating = (value: number): void => {
  setSelectedRatings((prev) =>
    prev.includes(value)
      ? prev.filter((item) => item !== value)
      : [...prev, value]
  );
};

  return (
    <div className="apartments-main">
      <button
        id="openFilterBtn"
        className="filter-toggle-btn"
        type="button"
        onClick={() => setIsSidebarOpen(true)}
      >
        Фільтр
      </button>

      {isSidebarOpen && (
        <div
          id="filterOverlay"
          className="filter-overlay"
          onClick={() => setIsSidebarOpen(false)}
        />
      )}

      <aside
        className={`apartments-filter ${isSidebarOpen ? 'active' : ''}`}
        id="filterSidebar"
      >
        <h2 className="filter-title" style={{ position: 'relative' }}>
          Фільтр

          <button
            id="resetFilters"
            className="reset-btn desktop-reset-btn"
            type="button"
            onClick={resetFilters}
          >
            Скинути
          </button>

          <button
            id="closeSidebarBtn"
            className="close-sidebar-btn"
            type="button"
            onClick={() => setIsSidebarOpen(false)}
          >
            ✕
          </button>
        </h2>

        <div className="reset-btn-container mobile-reset-btn">
          <button
            id="resetFiltersMobile"
            className="reset-btn"
            type="button"
            onClick={resetFilters}
          >
            Скинути
          </button>
        </div>

        <div className="filter-section" id="priceSection">
          <div className="filter-header">
            Ціна
            <span className="price-label">
              ₴<span id="priceLabel">{priceMin} - {priceMax}</span>
            </span>
          </div>

          <div className="price-sliders">
            <div
              className="slider-track"
              style={{
                left: `${minPercent}%`,
                width: `${maxPercent - minPercent}%`,
              }}
            />

            <input
              id="priceMin"
              type="range"
              min="0"
              max="20000"
              step="100"
              value={priceMin}
              onChange={(e) => {
                const value = Number(e.target.value)
                if (value <= priceMax) setPriceMin(value)
              }}
            />

            <input
              id="priceMax"
              type="range"
              min="0"
              max="20000"
              step="100"
              value={priceMax}
              onChange={(e) => {
                const value = Number(e.target.value)
                if (value >= priceMin) setPriceMax(value)
              }}
            />
          </div>

          
        </div>

        <div className="filter-section">
          <div className="filter-header">Рейтинг</div>

          <div className="rating-options" id="ratingOptions">
            {[9, 8, 7, 6].map((rating) => (
              <label key={rating}>
                <input
                  type="checkbox"
                  checked={selectedRatings.includes(rating)}
                  onChange={() => toggleRating(rating)}
                />
                <span className="box"></span>
                <span className="text">
                  {rating === 9 && '9+ Винятково'}
                  {rating === 8 && '8+ Дуже добре'}
                  {rating === 7 && '7+ Добре'}
                  {rating === 6 && '6+ Непогано'}
                </span>
              </label>
            ))}
          </div>
        </div>

        <div className="filter-section">
          <div className="filter-header">Країна</div>

          <div className="country-input-container">
            <input
            
              id="countryInput"
              type="text"
              placeholder="Введіть країну"
              value={countryInput}
              onChange={(e) => setCountryInput(e.target.value)}
            />

            <button
              id="countryConfirmBtn"
              type="button"
              onClick={() => setConfirmedCountry(countryInput)}
            >
              Підтвердити
            </button>
          </div>
        </div>
      </aside>

      <div className="apartments-content">
        <div className="apartments-header">
          <div className="results-count">
            Знайдено {filteredHotels.length} помешкань
          </div>
          <div className="filter-section">
          
        
          <div className="sorting-options">
            <div className="filter-header">Сортування:</div>
            <select
              id="sortSelect"
              value={sortSelect}
              onChange={(e) => setSortSelect(e.target.value)}
            >
              <option value="default">За замовчуванням</option>
              <option value="price_asc">Спочатку дешевші</option>
              <option value="price_desc">Спочатку дорожчі</option>
            </select>
          </div>
        </div>
        </div>

        <div className="apartments-list" id="apartmentsList">
          {filteredHotels.length === 0 ? (
            <div className="no-results">
              Нічого не знайдено за обраними фільтрами.
            </div>
          ) : (
            filteredHotels.map((hotel) => (
              <div className="apartment-card" key={hotel.id}>
                <div className="card-image-container">
                  <img
                    className="apartment-img"
                    src={hotel.displayImage}
                  />
                  <div className="favorite-icon">♡</div>
                </div>

                <div className="apartment-info">
                  <div className="apartment-title">{hotel.name}</div>

                  <div className="apartment-location">{hotel.location}</div>

                  <div className="room-type">{hotel.categoryName}</div>

                  <div className="realtor-info">
                    Ріелтор: <span>{hotel.userId}</span>
                  </div>

                  <div className="rating-container">
                    <div className="apartment-rating">
                      <span className="star">★</span> 
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
      </div>
    </div>

  );
}

export default Catalog;