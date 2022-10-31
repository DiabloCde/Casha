import styles from './AdminHeader.css';

import React from 'react'

function adminHeader() {
    return (
        <header>
            <div className="wrapper">
                <div className="logo">
                    <img src="./img/HeaderLogo.png" alt="Bad Response" />
                    <a href=''></a>
                </div>
                <div className="search">
                    <form>
                        <div class="form_wrapper">
                            <div class="form_input">
                                <input type={'text'} placeholder={'Type for search'} />
                            </div>
                                <button class = "submit_button" type="submit">
                                    <img src="./img/SearchIcon.png" alt="Nothing to serch" />
                                </button>
                        </div>
                    </form>
                </div>
                <div className="avatar">
                    <img src="./img/AvatarIcon.png" alt="Bad response" />
                </div>
            </div>
        </header>
    )
}

export default adminHeader
