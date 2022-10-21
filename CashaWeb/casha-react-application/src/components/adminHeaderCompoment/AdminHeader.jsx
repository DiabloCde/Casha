import styles from './AdminHeader.css';

import React from 'react'

function adminHeader() {
    return (
        <header>
            <div className="wrapper">
                <div className="logo">
                    <img src="" alt="Bad Response" />
                    <a href=''></a>
                </div>
                <div className="search">
                    <form>
                        <input type={'text'}></input>
                        
                        <button type="submit"></button>
                    </form>
                </div>
                <div className="avatar">
                    <img src="" alt="Bad response" />
                </div>
            </div>
        </header>
    )
}

export default adminHeader
