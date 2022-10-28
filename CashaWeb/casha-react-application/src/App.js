import Login from "./pages/loginPage/Login.jsx";
import Register from "./pages/registerPage/Register.jsx";
import { BrowserRouter, Routes, Route, Navigate, } from "react-router-dom";

function App() {
  return (
    // <main>
    //   <Login/>
    // </main>
    <BrowserRouter>
			<Routes>
          <Route path="/Login" element= {<Login /> } />
          <Route path="/Register" element={<Register /> } />
				  {/* Default Router */}
          <Route path="/" element= { <Navigate to="/Login"/> }/>
			</Routes>
		</BrowserRouter>
  );
}

export default App;
