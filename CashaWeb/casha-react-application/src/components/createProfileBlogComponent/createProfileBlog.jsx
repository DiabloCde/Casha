import React from "react"
import { useRef, useState, useEffect, useContext } from "react"
import axios from "axios"

import styles from "./createProfileBlog.css"

const URL_GETUSERPOSTS = "https://localhost:7128/api/Post/UserPosts/e802fce3-10bc-4ce4-a90f-bc94967eee13"

function CreateProfileBlog() {
  const [userPosts, setUserPosts] = useState([])
  const [isRendered, setIsRendered] = useState(false)



  async function getUserPosts() {
    const response = await axios({
      method: "get",
      url: URL_GETUSERPOSTS,
      data: JSON.stringify(),
      headers: { "Content-Type": "application/json; charset=utf-8" },
    }).then((response) => {
      setUserPosts(response.data)
    })
  }

  useEffect(() => {
    getUserPosts();
    setIsRendered(true);
  }, [])

  if (isRendered) {
    console.log(userPosts)
    return (
      <div className="wrapperBlog">
        <h1>Blog:</h1>
        <div className="blogs">
          {userPosts?.reverse().map((item) =>
            <>
              <div className="postOfReceipt">
                <div className="postInfo">
                  <img key={item.postId} src={item.profilePictureUrl} alt="" />
                  <p key={item.postId}>{item.displayName}</p>
                  <p key={item.postId}>{item.displayName}</p>
                </div>
                <div className="postMainInfo">
                  <p key={item.postId}>{item.title}</p>
                  <img src="./img/Pic.png" alt="" />
                  <button className="btn openReceipt">Open receipt</button>
                  <p key={item.postId}>{item.description}</p>
                  <button className="btn">Comments</button>
                </div>
              </div>

            </>)}

        </div>
      </div>
    )
  }
  else {
    return (
      <h1>Please Wait</h1>
    )
  }
}
export default CreateProfileBlog
