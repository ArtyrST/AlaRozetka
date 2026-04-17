
import searchImg from '../../Assets/Search.png';
import './search-sec.css';
function SearchSection() {
  return (
    <div className="search-container">
        <div className="search-field">
          <label data-i18n="label.where">Куди</label>
          <input
            type="text"
            id="city"
            placeholder="Введіть місто"
            data-i18n="placeholder.city"
          />
        </div>

        <div className="search-field">
          <label data-i18n="label.checkin">Прибуття</label>
          <input type="date" id="checkin" />
        </div>

        <div className="search-field">
          <label data-i18n="label.checkout">Виїзд</label>
          <input type="date" id="checkout" />
        </div>

        <div className="search-field">
          <label data-i18n="label.guests">Кількість гостей</label>
          <select id="guests">
            <option value="1" data-i18n="option.adult1">1 Дорослий</option>
            <option value="2" data-i18n="option.adult2">2 Дорослих</option>
            <option value="3" data-i18n="option.adult3">3 Дорослих</option>
            <option value="4" data-i18n="option.family">Сім'я</option>
          </select>
        </div>

        <div className="search-button">
          <button>
            <img src={searchImg} alt="Search" />
            <span data-i18n="cta.search">Шукати</span>
          </button>
        </div>
    </div>
  );
}
export default SearchSection;