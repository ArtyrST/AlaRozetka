import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainLayout from './Components/MainLayout.tsx';
import {HomePage} from './Pages/Home/home.tsx';
import Catalog from './Pages/Catalog/catalog.tsx';
import Register from './Pages/Auth/Register/register.tsx';
import Login from "./Pages/Auth/Login/Login.tsx";
import {RealtorPage}  from "./Pages/Realtor-office/realtor-page.tsx";
import ContactPage from "./Pages/Contact/contact.tsx";
import DeleteToken from "./Components/DeleteToken.tsx";
import RealtorProfile from "./Pages/Realtor-profile/realtor-profile.tsx";
import AddHotel from "./Pages/Add-hotel/add-hotel.tsx";
import Hotel from "./Pages/Hotel/hotel.tsx";
import './App.css';
function App() {
  return (
    <BrowserRouter>
  <Routes>
    <Route path="/" element={<MainLayout />}>
      <Route path="logout" element={<DeleteToken />} />
      <Route index element={<HomePage />} />
      <Route path="catalog" element={<Catalog />} />
      <Route path="contacts" element={<ContactPage />} />
      <Route path="realtor" element={<RealtorPage />} />
      <Route path="realtor-profile" element={<RealtorProfile />} />
      <Route path="add-hotel" element={<AddHotel />} />
      <Route path="hotel" element={<Hotel />} />
    </Route>

    <Route path="/register" element={<Register />} />
    <Route path="/login" element={<Login />} />
  </Routes>
</BrowserRouter>

  );
}

export default App;