import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import Header from './Header/header.tsx'
import Footer from './Footer/footer.tsx'
import Catalog from './Catalog-page/catalog.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode> 
    <Header />
    <Catalog />
    <Footer />
    <App />
  </StrictMode>,
)
