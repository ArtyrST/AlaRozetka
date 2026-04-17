import arrowImg from '../../Assets/arrow.png';
import './carousel.css';
function Carousel() {
    return(
<div className="body-carousel">
        <div className="carousel-container">
          <div className="background-image"></div>
          <h2 data-i18n="best.offers">Найкращі пропозиції</h2>

          <div className="carousel">
            <div className="carousel-track">
              <div className="item item1">
                <div className="item-content">
                  <h3>Єгипет</h3>
                  <div className="year">від 8799₴</div>
                </div>
              </div>

              <div className="item item2">
                <div className="item-content">
                  <h3>Туреччина</h3>
                  <div className="year">від 6899₴</div>
                </div>
              </div>

              <div className="item item3">
                <div className="item-content">
                  <h3>Балі</h3>
                  <div className="year">від 7599₴</div>
                </div>
              </div>

              <div className="item item4">
                <div className="item-content">
                  <h3>Шрі-Ланка</h3>
                  <div className="year">від 5999₴</div>
                </div>
              </div>
            </div>
          </div>

          <div className="buttons">
            <button className="prev">
              <img src={arrowImg} alt="Previous" />
            </button>

            <button className="next">
              <img src={arrowImg} alt="Next" />
            </button>
          </div>
        </div>
      </div>
    );
}
export default Carousel;