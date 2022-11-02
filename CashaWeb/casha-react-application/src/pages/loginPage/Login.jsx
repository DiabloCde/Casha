import styles from '../../common/styles/Auth.css';

import React from 'react'
import { useRef, useState, useEffect, useContext } from 'react';
import { Routes, Route, useNavigate } from 'react-router-dom';
import { Link } from "react-router-dom";
import axios from 'axios';
import { useCookies } from "react-cookie";

const URL = "https://localhost:7128/api/Account/login";

function Login() {

    const [cookies, setCookie] = useCookies();
    const navigate = useNavigate();
    const userRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [token, setToken] = useState('');


    useEffect(() => {
        setErrMsg('');
    }, [user, pwd])

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            console.log(JSON.stringify({ login: user, password: pwd }));

            let body = {
                login: user,
                password: pwd
            }

            const response = await axios({
                method: 'post',
                url: URL,
                data: JSON.stringify(body),
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            })
                .then((response) => {
                    setToken(response.data);
                    console.log(response.data);
                })

            console.log(response);    
            setCookie('token',token);
            navigate('/'); //ProfileSettings
        } catch (err) {
            if (!err?.response) {
                alert("No Server Response");
            } else if (err.response?.status === 400) {
                alert("Missing Password or Login");
            } else if (err.response?.status === 401) {
                alert("Unathorized")
            } else {
                alert("Login failed");
            }

        }
    }

    return (
        <div class="Auth_Wrapper">
            <section>
                <div class="Auth_Image_Container">
                    <img src='./img/Logo.png'></img>
                </div>
                <form onSubmit={handleSubmit} method="Post">
                    <div className="Form_Input_Area_Wrapper">
                        <div class="Auth_Input_Wrap">
                            <div class="Input_Blocks First_Input_Block">
                                <div class="Input_Icon">
                                    <img src='./img/Login.png'></img>
                                </div>
                                <div class="Input_Label">
                                    <label htmlFor='username'>Username:</label>
                                </div>
                                <div class="Input_Input">
                                    <input
                                        type="text"
                                        id="username"
                                        ref={userRef}
                                        autoComplete="off"
                                        onChange={(e) => setUser(e.target.value)}
                                        required
                                    />
                                </div>
                            </div>

                            <div class="Input_Blocks">
                                <div class="Input_Icon">
                                    <img src='./Img/Password.png'></img>
                                </div>
                                <div class="Input_Label">
                                    <label htmlFor='password'>Password:</label>
                                </div>
                                <div class="Input_Input">
                                    <input
                                        type="password"
                                        id="password"
                                        onChange={(e) => setPwd(e.target.value)}
                                        value={pwd}
                                        required
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="Button_Wrapper">
                        <button>Log In</button>
                    </div>

                </form>
                <div class="Registration_Link">
                    <p>
                        No account yet?&nbsp;&nbsp;
                        <Link to="/Register">
                            <span className="line">Register</span>
                        </Link>
                    </p>
                </div>
            </section>
        </div >
    )
}

export default Login;