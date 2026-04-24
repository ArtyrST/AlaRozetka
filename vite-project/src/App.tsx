import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainLayout from './MainLayout.tsx';
import {HomePage} from './Home-page/home.tsx';
import Catalog from './Catalog-page/catalog.tsx';
import Register from './Auth-page/Register/register.tsx';
import Login from "./Auth-page/Login/Login.tsx";
import {RealtorPage}  from "./Realtor-page/realtor-page.tsx";
import ContactPage from "./Contact-page/contact.tsx";
import ProtectedRoute from "./ProtectedRoute.tsx";
import DeleteToken from "./DeleteToken.tsx";
import RealtorProfile from "./Realtor-profile/realtor-profile.tsx";
import AddHotel from "./Add-hotel-page/add-hotel.tsx";
import './App.css';
function App() {
  return (
    <BrowserRouter>
  <Routes>
    <Route path="/" element={<MainLayout />}>
      <Route path="protected" element={<ProtectedRoute />} />
      <Route path="logout" element={<DeleteToken />} />
      <Route index element={<HomePage />} />
      <Route path="catalog" element={<Catalog />} />
      <Route path="contacts" element={<ContactPage />} />
      <Route path="realtor" element={<RealtorPage />} />
      <Route path="realtor-profile" element={<RealtorProfile />} />
      <Route path="add-hotel" element={<AddHotel />} />
    </Route>

    <Route path="/register" element={<Register />} />
    <Route path="/login" element={<Login />} />
  </Routes>
</BrowserRouter>

  );
}

export default App;