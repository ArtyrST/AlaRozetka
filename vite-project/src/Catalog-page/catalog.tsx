import { useMemo, useState, type JSX } from 'react'
import './catalog.css'

type Hotel = {
  id: string
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

const hotelsData: Hotel[] = [
  {
    id: 'radisson',
    title: 'Radisson Blu Hotel',
    location: 'Барселона, Іспанія',
    country: 'Іспанія',
    rating: 9.7,
    price: 6999,
    oldPrice: 7699,
    image: '../Assets/Egipt.jpg',
    realtor: 'Олександр Коваль',
    roomType: 'Люкс із видом на море',
  },
  {
    id: 'alicante',
    title: 'Alicante Hills',
    location: 'Аліканте, Іспанія',
    country: 'Іспанія',
    rating: 6.3,
    price: 4699,
    oldPrice: 5200,
    image: '../Assets/Turkish.jpg',
    realtor: 'Ірина Литвин',
    roomType: 'Стандарт з балконом',
  },
  {
    id: 'vienna',
    title: 'Vienna Grand',
    location: 'Відень, Австрія',
    country: 'Австрія',
    rating: 9.2,
    price: 7999,
    oldPrice: 8600,
    image: '../Assets/Bali.jpg',
    realtor: 'Петро Гнатюк',
    roomType: 'Сімейний номер з кухнею',
  },
]

function Catalog(): JSX.Element {
  const [isSidebarOpen, setIsSidebarOpen] = useState<boolean>(false)
  const [priceMin, setPriceMin] = useState<number>(4000)
  const [priceMax, setPriceMax] = useState<number>(8000)
  const [countryInput, setCountryInput] = useState<string>('')
  const [confirmedCountry, setConfirmedCountry] = useState<string>('')
  const [selectedRatings, setSelectedRatings] = useState<number[]>([])
  const [sortSelect, setSortSelect] = useState<string>('default')

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
    let filtered = hotelsData.filter(
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
  }, [priceMin, priceMax, confirmedCountry, selectedRatings, sortSelect])

  return (
    <div className="apartments-main">
      <div
        id="filterOverlay"
        className={`filter-overlay ${isSidebarOpen ? 'active' : ''}`}
        onClick={() => setIsSidebarOpen(false)}
      ></div>

      <button
        id="openFilterBtn"
        className="filter-toggle-btn"
        type="button"
        onClick={() => setIsSidebarOpen(true)}
      >
        Фільтр
      </button>

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
              ₴
              <span id="priceLabel">
                {priceMin} - {priceMax}
              </span>
            </span>
          </div>

          <div className="price-sliders">
            <input
              type="range"
              min={4000}
              max={8000}
              value={priceMin}
              id="priceMin"
              onChange={(e) => {
                const value = Number(e.target.value)
                setPriceMin(value > priceMax ? priceMax : value)
              }}
            />
            <span className="price-separator">–</span>
            <input
              type="range"
              min={4000}
              max={8000}
              value={priceMax}
              id="priceMax"
              onChange={(e) => {
                const value = Number(e.target.value)
                setPriceMax(value < priceMin ? priceMin : value)
              }}
            />
          </div>
        </div>

        <div className="filter-section" id="ratingSection">
          <div className="filter-header">Оцінка за відгуками</div>

          <div id="ratingOptions" className="rating-options">
            <label>
              <input
                type="checkbox"
                value="9"
                checked={selectedRatings.includes(9)}
                onChange={() => toggleRating(9)}
              />
              <span className="box"></span>
              <span className="text"> Чудово: 9+</span>
            </label>

            <label>
              <input
                type="checkbox"
                value="8"
                checked={selectedRatings.includes(8)}
                onChange={() => toggleRating(8)}
              />
              <span className="box"></span>
              <span className="text"> Дуже добре: 8+</span>
            </label>

            <label>
              <input
                type="checkbox"
                value="7"
                checked={selectedRatings.includes(7)}
                onChange={() => toggleRating(7)}
              />
              <span className="box"></span>
              <span className="text"> Добре: 7+</span>
            </label>

            <label>
              <input
                type="checkbox"
                value="6"
                checked={selectedRatings.includes(6)}
                onChange={() => toggleRating(6)}
              />
              <span className="box"></span>
              <span className="text"> Досить добре: 6+</span>
            </label>
          </div>
        </div>

        <div className="filter-section" id="countrySection">
          <div className="filter-header">Країна</div>

          <div className="country-input-container">
            <input
              type="text"
              id="countryInput"
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

      <section className="apartments-content">
        <div className="apartments-header">
          <div className="results-count" id="resultsCount">
            Знайдено {filteredHotels.length}
            {confirmedCountry.trim() !== '' ? ` помешкань у ${confirmedCountry}` : ' помешкань'}
          </div>

          <div className="sorting-options">
            <label htmlFor="sortSelect">Сортувати за:</label>
            <select
              id="sortSelect"
              value={sortSelect}
              onChange={(e) => setSortSelect(e.target.value)}
            >
              <option value="default">наші рекомендації</option>
              <option value="price_asc">ціною (від низької до високої)</option>
              <option value="price_desc">ціною (від високої до низької)</option>
            </select>
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
                  <img className="apartment-img" src={hotel.image} alt={hotel.title} />
                  <div className="favorite-icon">
                    <span>♡</span>
                  </div>
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
                    <button
                      type="button"
                      onClick={() => {
                        window.location.href =
                          'https://easystay.wuaze.com/Apartments/hotel-radisson.html'
                      }}
                    >
                      Вибрати
                    </button>
                  </div>
                </div>
              </div>
            ))
          )}
        </div>
      </section>
    </div>
  )
}

export default Catalog