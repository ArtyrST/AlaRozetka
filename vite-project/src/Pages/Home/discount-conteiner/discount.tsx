import discountImg from "../../../Assets/disc_section.jpg"
import './discount.css';
function Discount() {
    return(
    <div className="discount">
        <img className="imgDisk" src={discountImg} alt="Discount background" />

        <div className="discount-content">
          <h1 data-i18n="discount.title">
            Отримайте постійну знижку -10% на деякі пропозиції після реєстрації
          </h1>

          <button data-i18n="discount.cta">Зареєструватись</button>
        </div>
      </div>
    );
}
export default Discount;