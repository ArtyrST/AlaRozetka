
import { Link } from "react-router-dom";
import './home.css';

import HeroSection from "./hero-section/hero-sec";
import SearchSection from "./search-conteiner/search-sec";
import Carousel from "./home-carousel/carousel";
import Services from "./services-conteiner/services";
import Discount from "./discount-conteiner/discount";


export const HomePage = () => {
  return (
    <main className="main">
      
        <HeroSection />
        <SearchSection />
        <Carousel />
        <Services />
        <Discount />
        
        
      
    </main>
  );
}



