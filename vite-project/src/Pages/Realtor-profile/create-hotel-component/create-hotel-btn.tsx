import { Navigate, Link  } from "react-router-dom";
function CreateHotelPage() {

    return(
        <div className="create-hotel-component">
            <h1 className="create-hotel-title">Зареєструйте своє помешкання</h1>
            <a>
            <Link to="/add-hotel" className="register-hotel-btn">Зареєструвати</Link>
            </a>
        </div>
    );
}
export default CreateHotelPage;