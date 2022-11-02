import React from "react"
import { useRef, useState, useEffect, useContext } from "react"
import axios from "axios"
import moment from "moment/moment"

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
            <div className="postOfReceipt" key={item.postId} >
              <div className="postInfo" >
                <img  src={item.profilePictureUrl} alt="" />
                <p >{item.displayName}</p>
                <p >{moment(item.postedDate).format('DD.MM.YYYY')}</p>
              </div>
              <div className="postMainInfo">
                <p >{item.title}</p>
                <img key = {item.postId} src={item.profilePictureUrl} alt="" />
                <button className="btn openReceipt">Open receipt</button>
                <p >{item.description}</p>
                <button className="btn">Comments</button>
              </div>
            </div>
          )}

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
