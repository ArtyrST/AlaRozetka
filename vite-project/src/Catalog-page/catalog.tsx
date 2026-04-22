import { useEffect, useMemo, useState, type JSX } from 'react'
import './catalog.scss'

type ApiHotel = {
  id: number
  name: string
  country: string
  price: number
  categoryName: string
  date: string
  city: string
  
}

type Hotel = {
  id: number
  title: string
  location: string
  country: string
  rating: number
  price: number
  image: string
  realtor: string
  roomType: string
  oldPrice?: number
}

function Catalog(): JSX.Element {
  const [hotels, setHotels] = useState<Hotel[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const [error, setError] = useState<string>('')

  const [isSidebarOpen, setIsSidebarOpen] = useState<boolean>(false)
  const [priceMin, setPriceMin] = useState<number>(4000)
  const [priceMax, setPriceMax] = useState<number>(8000)
  const [countryInput, setCountryInput] = useState<string>('')
  const [confirmedCountry, setConfirmedCountry] = useState<string>('')
  const [selectedRatings, setSelectedRatings] = useState<number[]>([])
  const [sortSelect, setSortSelect] = useState<string>('default')

  useEffect(() => {
    const fetchHotels = async () => {
      try {
        setLoading(true)
        setError('')

        const response = await fetch('/api/hotels')

        if (!response.ok) {
          throw new Error('Не вдалося отримати готелі')
        }

        const data: ApiHotel[] = await response.json()

        const mappedHotels: Hotel[] = data.map((hotel) => ({
          id: hotel.id,
          title: hotel.name,
          location: `${hotel.city}, ${hotel.country}`,
          country: hotel.country,
          price: hotel.price,

          // залишаємо як у початковому варіанті / заглушки
          rating: 8.5,
          image: 'https://via.placeholder.com/400x250?text=Hotel',
          realtor: 'Ще не додано',
          roomType: 'Ще не додано',
          oldPrice: Math.round(hotel.price * 1.1),
        }))

        setHotels(mappedHotels)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Сталася помилка')
      } finally {
        setLoading(false)
      }
    }

    fetchHotels()
  }, [])

  const toggleRating = (value: number): void => {
    setSelectedRatings((prev) =>
      prev.includes(value)
        ? prev.filter((item) => item !== value)
        : [...prev, value]
    )
  }

  const resetFilters = (): void => {
    setPriceMin(4000)
    setPriceMax(8000)
    setCountryInput('')
    setConfirmedCountry('')
    setSelectedRatings([])
    setSortSelect('default')
  }

  const filteredHotels = useMemo(() => {
    let filtered = hotels.filter(
      (hotel) => hotel.price >= priceMin && hotel.price <= priceMax
    )

    if (confirmedCountry.trim() !== '') {
      filtered = filtered.filter((hotel) =>
        hotel.country.toLowerCase().includes(confirmedCountry.trim().toLowerCase())
      )
    }

    if (selectedRatings.length > 0) {
      filtered = filtered.filter((hotel) =>
        selectedRatings.some((rating) => {
          if (rating === 9) return hotel.rating >= 9
          if (rating === 8) return hotel.rating >= 8 && hotel.rating < 9
          if (rating === 7) return hotel.rating >= 7 && hotel.rating < 8
          if (rating === 6) return hotel.rating >= 6 && hotel.rating < 7
          return false
        })
      )
    }

    const sorted = [...filtered]

    if (sortSelect === 'price_asc') {
      sorted.sort((a, b) => a.price - b.price)
    } else if (sortSelect === 'price_desc') {
      sorted.sort((a, b) => b.price - a.price)
    }

    return sorted
  }, [hotels, priceMin, priceMax, confirmedCountry, selectedRatings, sortSelect])

  const minPercent = (priceMin / 20000) * 100
  const maxPercent = (priceMax / 20000) * 100

  if (loading) {
    return <div>Завантаження готелів...</div>
  }

  if (error) {
    return <div>Помилка: {error}</div>
  }

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
      </div>
    </div>
  )
}

export default Catalog