import commonStyles from "../../common/styles/Auth.css";
import styles from "./Register.css";
import { messages } from "../../common/ErrorMessages";

import React from "react";
import { useRef, useState, useEffect, useContext } from "react";
import { Routes, Route, useNavigate } from 'react-router-dom';
import axios from "axios";
import { Link, redirect } from "react-router-dom";

const API_URL = "https://localhost:7128/api/Account/register";

function Register() {
    const navigate = useNavigate();
	const userRef = useRef();

	const [login, setlogin] = useState("");
	const [pwd, setPwd] = useState("");
	const [pwdRep, setPwdRep] = useState("");
	// Object => { property : message }
	//const [validity, setValidity] = useState({});

	useEffect(() => {}, [login, pwd]);

	const handleSubmit = async e => {
		e.preventDefault();

		console.log("submit");
		let validity = getUpdatedValidity();
		let success = validate(validity);

		if (success === false) {
			showErrors(validity);
			console.log("not succes");
			return;
		}

		try {
			console.log("try");

			let body = {
				Login: login,
				Password: pwd,
				PasswordConfirm: pwdRep
			};

			const response = await axios.post(API_URL, body);
			alert("Account created!");
            navigate('/Login');
		} catch (err) {
			//errors that expected from back
			console.log(err);
			if (!err?.response) {
				alert("No Server Response");
			} else if (err.response?.status === 400) {
				alert("Missing Password or Login");
			} else if (err.response?.status === 401) {
				alert("Unathorized");
			} else {
				alert("Registration failed");
			}
		}

		//console.log(JSON.stringify({login, pwd}));
	};

	const getUpdatedValidity = () => {
		var newValidity = {};
		var nonLatinRE = /[^\u0000-\u007f]/;
		var validPasswordRE = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/;

		if (login.length < 2 || nonLatinRE.test(login)) {
			newValidity["login"] = "InvalidLogin";
		} else {
			newValidity["login"] = "Valid";
		}

		if (pwd.length < 8 || nonLatinRE.test(pwd) || !validPasswordRE.test(pwd)) {
			newValidity["password"] = "InvalidPassword";
		} else {
			newValidity["password"] = "Valid";
		}

		if (pwdRep !== pwd) {
			newValidity["confirmation"] = "PasswordNotConfirmed";
		} else {
			newValidity["confirmation"] = "Valid";
		}

		return newValidity;
	};

	const validate = validity => {
		return validity["login"] === "Valid" && validity["password"] === "Valid" && validity["confirmation"] === "Valid";
	};

	const showErrors = validity => {
		for (let prop in validity) {
			let msg = validity[prop];
			if (msg !== "Valid") {
				alert(messages[msg]);
			}
		}

		return;
	};

	return (
		<div class="Auth_Wrapper">
			<section>
				<div class="Auth_Image_Container">
					<img src="./img/Logo.png"></img>
				</div>
				<form onSubmit={handleSubmit}>
					<div className="Form_Input_Area_Wrapper">
						<div class="Auth_Input_Wrap">
							<div class="Input_Blocks First_Input_Block">
								<div class="Input_Icon">
									<img src="./img/Login.png"></img>
								</div>
								<div class="Input_Label">
									<label htmlFor="username">Enter your login:</label>
								</div>
								<div class="Input_Input">
									<input
										type="text"
										id="username"
										ref={userRef}
										autoComplete="off"
										onChange={e => setlogin(e.target.value)}
										required
									/>
								</div>
							</div>

							<div class="Input_Blocks">
								<div class="Input_Icon">
									<img src="./Img/Password.png"></img>
								</div>
								<div class="Input_Label">
									<label htmlFor="password">Enter your password:</label>
								</div>
								<div class="Input_Input">
									<input
										type="password"
										id="password"
										onChange={e => setPwd(e.target.value)}
										value={pwd}
										required
									/>
								</div>
							</div>

							<div class="Input_Blocks">
								<div class="Input_Icon">
									<img src="./Img/Password.png"></img>
								</div>
								<div class="Input_Label">
									<label htmlFor="passwordRep">Repeat your password:</label>
								</div>
								<div class="Input_Input">
									<input
										type="password"
										id="passwordRep"
										onChange={e => setPwdRep(e.target.value)}
										value={pwdRep}
										required
									/>
								</div>
							</div>
						</div>
					</div>
					<div class="Button_Wrapper" type>
						<button type="submit">Register</button>
					</div>
				</form>

				<div class="Registration_Link">
					<p>
						Already have account?&nbsp;&nbsp;
						<Link to="/Login">
							<span className="line">Login</span>
						</Link>
					</p>
				</div>
			</section>
		</div>
	);
}

export default Register;
