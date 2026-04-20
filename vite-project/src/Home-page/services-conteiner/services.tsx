import service1 from '../../Assets/PoslygiSec1.png';
import service2 from '../../Assets/Poslygi2.png';
import service3 from '../../Assets/Poslugi3.png';
import service4 from '../../Assets/Poslugi4.png';
import service5 from '../../Assets/Poslugi5.png';
import './services.css';
function Services() {
    return(
<div className="services-container">
        <h1 data-i18n="services.title">Послуги, які ми пропонуємо</h1>

        <div className="service-list">
          <div className="service-item">
            <img className="service-icon" src={service1} alt="Готелі" />
            <h3>Готелі</h3>
            <p>Зручний вибір та бронювання</p>
            <a className="details-link">Детальніше</a>
          </div>

          <div className="service-item">
            <img className="service-icon" src={service2} alt="Авто" />
            <h3>Авто</h3>
            <p>Оренда авто для вашої зручності</p>
            <a className="details-link">Детальніше</a>
          </div>

          <div className="service-item">
            <img className="service-icon" src={service3} alt="Апартаменти" />
            <h3>Апартаменти</h3>
            <p>Комфортне проживання для відпочинку</p>
            <a className="details-link">Детальніше</a>
          </div>

          <div className="service-item">
            <img className="service-icon" src={service4} alt="Трансфери" />
            <h3>Трансфери</h3>
            <p>Швидкі та надійні перевезення</p>
            <a className="details-link">Детальніше</a>
          </div>

          <div className="service-item">
            <img className="service-icon" src={service5} alt="Тури" />
            <h3>Тури</h3>
            <p>Незабутні подорожі та екскурсії</p>
            <a className="details-link">Детальніше</a>
          </div>
        </div>
      </div>
    );
}
export default Services;