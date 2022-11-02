import styles from "./UserHeader.css"
import React from "react"
// import { Link } from "react-router-dom"

function UserHeader() {
  return (
    <header>
      <div className="wrapper">
        <div className="logo">
          <img src="./img/HeaderLogo.png" alt="Bad Response" />
          <a href=""></a>
        </div>

        <div className="search">
          <form>
            <div className="form_wrapper">
              <div className="form_input">
                <input type={"text"} placeholder={"Type for search"} />
              </div>
              <button className="submit_button" type="submit">
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

export default UserHeader
