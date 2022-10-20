import React from 'react'
import { useRef, useState, useEffect, useContext } from 'react';
import AuthContext from './context/AuthProvider';
import axios from './api/axios';
const LOGIN_URL = '/address from back for this page';

function Login() {
    const { setAuth } = useContext(AuthContext);

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
            const response = await axios.post(LOGIN_URL,
                JSON.stringify({ userName: user, password: pwd }),
                {
                    headers: { 'Content-type': 'application/json' },
                    withCredentials: true
                }
            );
            //Names same as back expectes
            console.log(JSON.stringify(response?.data)); //temp
            const accessToken = response?.data?.accessToken;  //what back returns
            const roles = response?.data?.roles; //what back returns
            setAuth({user,pwd,roles,accessToken}); //storing information in this object and store it in global context
            setUser('');
            setPwd('');
            setSuccess(true);

        } catch (err) {                 //errors that expected from back
            if(!err?.response){
                alert("No Server Response");
            } else if(err.response?.status === 400){
                alert("Missing Password or Login");
            } else if(err.response?.status === 401){
                alert("Unathorized")
            }else{
                alert("Login failed");
            }

        }

        //console.log(JSON.stringify({user, pwd}));
    }

    return (
        <div class="Login_Wrapper">
            <section>
                <div class="Login_Image_Container">
                    <img src='./Img/Logo.png'></img>
                </div>
                <form onSubmit={handleSubmit}>
                    <div className="Form_Input_Area_Wrapper">
                        <div class="Login_Input_Wrap">
                            <div class="Input_Blocks First_Input_Block">
                                <div class="Input_Icon">
                                    <img src='./Img/Login.png'></img>
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
                        <span className="line"> {/*router link here*/}<a href="#">Register</a></span>
                    </p>
                </div>
            </section>
        </div >
    )
}

export default Login
