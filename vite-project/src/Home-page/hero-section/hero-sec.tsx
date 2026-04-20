import { Link } from "react-router-dom";
import './hero-sec.css';
import heroImg from '../../Assets/hyro_section.jpg';

function HeroSection (){
    return(
<div className="hero-section">
        <img className="imgHero" src={heroImg} alt="Hero" />

        <div className="hero-content">
          <div className="hero-content2">
            <h1 data-i18n="hero.line1">Відкривай цікаві</h1>
            <h1 data-i18n="hero.line2">місця з нами</h1>
            <p data-i18n="hero.subtitle">
              Легкий спосіб знайти унікальні місця для відпочинку та насолоди – приєднуйся до нас!
            </p>
          </div>

          <Link to="/catalog" className="cta-button" data-i18n="cta.search">
            Шукати житло
          </Link>
        </div>
      </div>
    );
}
export default HeroSection;