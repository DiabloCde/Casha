import Login from "./pages/loginPage/Login.jsx";
import Register from "./pages/registerPage/Register.jsx";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import AdminEditRecipes from "./pages/adminEditRecipes/AdminEditRecipes.jsx";
import ProfileSettings from "./pages/ProfileSettings/ProfileSettings.js";

function App() {
	return (
		<BrowserRouter>
			<ProfileSettings />
			<Routes>
				{/* <Route path="/Login" element={<Login />} />
				<Route path="/Register" element={<Register />} />
				<Route path="/EditRecipes" element={<AdminEditRecipes />} /> */}
				{/* Default Router */}
				{/* <Route path="/" element={<Navigate to="/Login" />} /> */}
			</Routes>
		</BrowserRouter>
	);
}

export default App;
