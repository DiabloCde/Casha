import Login from "./pages/loginPage/Login.jsx";
import Register from "./pages/registerPage/Register.jsx";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import AdminEditRecipes from "./pages/adminEditRecipes/AdminEditRecipes.jsx";
import OtherUserMainPage from "./pages/otherUserMainPage/otherUserMainPage.jsx";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/Login" element={<Login />} />
                <Route path="/Register" element={<Register />} />
                <Route path="/EditRecipes" element={<AdminEditRecipes />} />
                <Route path="/OtherUserMainPage" element={<OtherUserMainPage />} />

                {/* Default Router */}
                <Route path="/" element={<Navigate to="/Login" />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
