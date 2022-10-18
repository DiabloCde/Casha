import React from 'react'

function Login() {
    return (
        <div class="wrapper">
            <section>
                <div class="Login_Image_Container">
                    <img src='./Img/Logo.png'></img>
                </div>
                <form>
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
                                        autoComplete="off"
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
                                        required
                                    />
                                </div>

                            </div>

                        </div>
                    </div>
                    <div class="Button_Wrapper">
                        <div class="Button_Block">
                            <button>Log In</button>
                        </div>
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
