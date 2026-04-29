import React from 'react';
import './hotel.css';



function Hotel() {
  return (
    <div className="container">
  <div className="hotel-header">
    <h1>Radisson Blu Hotel <span className="rating">9.7</span></h1>
    <div className="location">
      <i className="fas fa-map-marker-alt"></i>
      Барселона, Іспанія / Carrer de Johann Sebastian Bach, 18
    </div>
  </div>

  <div className="hotel-section">
    <div className="hotel-info">
      <p>
        У помешканні Messe-Congress Central with balcony, розташованому приблизно за 1 км від пам'ятки
        "Конгрес-центр Messe Wien", гостям пропонують комфортне перебування з краєвидом на місто та безкоштовний Wi-Fi.
      </p>

      <div className="icons">
        <div><i className="fas fa-city"></i> Вид на місто</div>
        <div><i className="fas fa-bath"></i> Ванна кімната</div>
        <div><i className="fas fa-wine-bottle"></i> Міні-бар</div>
        <div><i className="fas fa-thermometer-half"></i> Опалення</div>
        <div><i className="fas fa-wifi"></i> Безкоштовний Wi-Fi</div>
        <div><i className="fas fa-parking"></i> Приватна автостоянка</div>
        <div><i className="fas fa-tv"></i> Телевізор</div>
        <div><i className="fas fa-dumbbell"></i> Фітнес-центр</div>
      </div>

      <div className="hotel-features">
        <div className="feature-tabs">
          <div className="feature-tab active" data-tab="description">Опис</div>
          <div className="feature-tab" data-tab="amenities">Зручності</div>
          <div className="feature-tab" data-tab="reviews">Відгуки</div>
          <div className="feature-tab" data-tab="location">Розташування</div>
        </div>
        
        <div className="feature-content active" id="description">
          <p>Radisson Blu Hotel пропонує розкішне проживання в самому серці Барселони. Наш готель поєднує в собі сучасний дизайн, високий рівень комфорту та іспанський шарм. Всі номери обладнані кондиціонером, телевізором з плоским екраном, міні-баром та безкоштовним Wi-Fi.</p>
          <p>Гості можуть насолоджуватися смачною європейською кухнею в нашому ресторані, відпочити у барі з терасою або скористатися послугами спа-центру. Готель також пропонує конференц-зали для ділових подій.</p>
        </div>
        
        <div className="feature-content" id="amenities">
          <div className="icons">
            <div><i className="fas fa-swimming-pool"></i> Басейн</div>
            <div><i className="fas fa-spa"></i> Спа-центр</div>
            <div><i className="fas fa-utensils"></i> Ресторан</div>
            <div><i className="fas fa-concierge-bell"></i> Обслуговування номерів</div>
            <div><i className="fas fa-business-time"></i> Бізнес-центр</div>
            <div><i className="fas fa-luggage-cart"></i> Камера схову багажу</div>
            <div><i className="fas fa-child"></i> Дитячий клуб</div>
            <div><i className="fas fa-paw"></i> Дозволено з домашніми тваринами</div>
          </div>
        </div>
        
        <div className="feature-content" id="reviews">
          <div className="reviews">
            <div className="review-item">
              <div className="review-header">
                <div className="reviewer-name">Олександр К.</div>
                <div className="review-date">15 травня 2023</div>
              </div>
              <div className="review-rating">
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
              </div>
              <p>Чудовий готель з прекрасним видом на місто. Персонал дуже уважний та професійний. Обов'язково повернемось!</p>
            </div>
            
            <div className="review-item">
              <div className="review-header">
                <div className="reviewer-name">Марія П.</div>
                <div className="review-date">2 квітня 2023</div>
              </div>
              <div className="review-rating">
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
                <i className="fas fa-star"></i>
                <i className="fas fa-star-half-alt"></i>
              </div>
              <p>Гарний готель, чисто, зручне розташування. Єдиний недолік - довге очікування ліфта в години пік.</p>
            </div>
          </div>
        </div>
        
        <div className="feature-content" id="location">
          <div className="map-container">
            <div className="map-placeholder">
              <i className="fas fa-map-marked-alt" style={{fontSize: "40px", marginRight: "10px"}}></i>
              <span>Карта розташування готелю</span>
            </div>
          </div>
          <p style={{marginTop: "15px"}}>Готель розташований в престижному районі Барселони, за 15 хвилин їзди від аеропорту та в 10 хвилинах ходьби від знаменитої вулиці Рамбла.</p>
        </div>
      </div>

      <div className="calculator">
        <h3>Розрахунок вартості проживання</h3>
        <div className="calc-fields">
          <div className="field">
            <label htmlFor="checkin">Прибуття</label>
            <input type="date" id="checkin" />
          </div>

          <div className="field">
            <label htmlFor="checkout">Виїзд</label>
            <input type="date" id="checkout" />
          </div>

          <div className="field">
            <label htmlFor="guests">Кількість гостей</label>
            <select id="guests" defaultValue="2">
              <option value="1">1 Дорослий</option>
              <option value="2">2 Дорослих</option>
              <option value="3">3 Дорослих</option>
              <option value="4">Сім'я</option>
            </select>
          </div>

          <button className="search-btn">
            <i className="fas fa-search"></i> Забронювати
          </button>
        </div>

        <div className="extra-services">
          <h4>Додаткові послуги (за окрему плату):</h4>
          <label><input type="checkbox" className="extra" value="700"/><span className="box"></span> + Додаткове ліжко (+700₴)</label>
          <label><input type="checkbox" className="extra" value="500"/><span className="box"></span> + Міні-бар (+500₴)</label>
          <label><input type="checkbox" className="extra" value="900"/><span className="box"></span> + Пізній виїзд (+900₴)</label>
          <label><input type="checkbox" className="extra" value="1200"/><span className="box"></span> + Трансфер з аеропорту (+1200₴)</label>
        </div>

        <div className="calc-result" id="calcResult">Від 6999₴ за ніч</div>
      </div>
    </div>

    <div className="hotel-gallery-container">
      <img src="https://images.unsplash.com/photo-1506744038136-46273834b3fb" alt="Radisson Blu Hotel" className="main-photo gallery-item" />
      <div className="small-photos-grid">
        <img src="https://images.unsplash.com/photo-1560448204-e02f11c3d0e2" alt="Номер готелю" className="gallery-item" />
        <img src="https://images.unsplash.com/photo-1613977257363-707ba9348227" alt="Ванна кімната" className="gallery-item" />
        <img src="https://images.unsplash.com/photo-1600585154340-be6161a56a0c" alt="Ресторан" className="gallery-item" />
        <img src="https://images.unsplash.com/photo-1522708323590-d24dbb6b0267" alt="Басейн" className="gallery-item" />
      </div>
    </div>
  </div>
</div>
  );
}
export default Hotel;