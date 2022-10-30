import React from "react"

import styles from "./createProfileBlog.css"

function CreateProfileBlog() {
  return (
    <div className="wrapperBlog">
      <h1>Blog:</h1>
      <div className="blogs">
        <div className="postOfReceipt">
          <div className="postInfo">
            <img src="./img/ico.png" alt="" />
            <p>nickname</p>
            <p>12.02.2003</p>
          </div>
          <div className="postMainInfo">
            <p>Название:</p>
            <img src="./img/Pic.png" alt="" />
            <button className="btn openReceipt">Open receipt</button>
            <p>Описание</p>
            <button className="btn">Comments</button>
          </div>
        </div>
      </div>
    </div>
  )
}
export default CreateProfileBlog
