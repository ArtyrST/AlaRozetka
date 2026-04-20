import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainLayout from './MainLayout.tsx';
import {HomePage} from './Home-page/home.tsx';
import Catalog from './Catalog-page/catalog.tsx';
import Register from './Auth-page/Register/register.tsx';
import Login from "./Auth-page/Login/Login.tsx";
import {RealtorPage}  from "./Realtor-page/realtor-page.tsx";
function App() {
  return (
    <BrowserRouter>
  <Routes>
    <Route path="/" element={<MainLayout />}>
      <Route index element={<HomePage />} />
      <Route path="catalog" element={<Catalog />} />
      <Route path="realtor" element={<RealtorPage />} />
    </Route>

    <Route path="/register" element={<Register />} />
    <Route path="/login" element={<Login />} />
  </Routes>
</BrowserRouter>

  );
}

export default App;