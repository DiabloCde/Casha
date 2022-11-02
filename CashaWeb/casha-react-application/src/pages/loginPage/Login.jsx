import styles from '../../common/styles/Auth.css';

import React from 'react'
import { useRef, useState, useEffect, useContext } from 'react';
import {Routes, Route, useNavigate} from 'react-router-dom';
import AuthContext from '../../context/AuthProvider';
import axios from '../../api/axios';
import { Link } from "react-router-dom";

const URL = "https://localhost:7128/api/Login/login";

function Login() {
    const { setAuth } = useContext(AuthContext);

    const navigate = useNavigate();
    const userRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);

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
                .then((response) => { console.log(response) })

            console.log(body);
            setSuccess(true);
            console.log(success);
            if(success === true){
                navigate('/EditRecipes');
            }

        } catch (err) {                 //errors that expected from back
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

        //console.log(JSON.stringify({user, pwd}));
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