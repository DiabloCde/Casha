import React from "react"
import CreateProfileBlog from "../../components/createProfileBlogComponent/createProfileBlog"
import UserHeader from "../../components/userHeaderComponent/UserHeader"
import ProfileMenu from "../../components/ProfileMenuComponent/ProfileMenu"
import { useRef, useState, useEffect, useContext } from "react"
import { Routes, Route, useNavigate } from "react-router-dom"
import { Link } from "react-router-dom"

import axios from "axios"

const URL_GETUSER =
  "https://localhost:7128/api/User/e802fce3-10bc-4ce4-a90f-bc94967eee13"

const URL_GETUSERPOSTS =
  "https://localhost:7128/api/Post/UserPosts/e802fce3-10bc-4ce4-a90f-bc94967eee13"

function OtherUserMainPage() {
  const [userInfo, setUserInfo] = useState({})
  const [isRendered, setIsRendered] = useState(false)
  const profileMenuTexts = ["Overview", "User recipes"]
  const profileMenuLinks = ["/to", "/to"]
  const activeText = "Overview"

  async function getUser() {
    const response = await axios({
      method: "get",
      url: URL_GETUSER,
      data: JSON.stringify(),
      headers: { "Content-Type": "application/json; charset=utf-8" },
    }).then((response) => {
      setUserInfo(response.data)
    })
  }

  useEffect(() => {
    getUser()
    setIsRendered(true)
  }, [])

  if (isRendered === true) {
    console.log(userInfo)
    return (
      <>
        <UserHeader />
        <ProfileMenu
          profileMenuTexts={profileMenuTexts}
          profileMenuLinks={profileMenuLinks}
          activeText={activeText}
          imgLink={userInfo.profilePictureUrl}
          userNickName={userInfo.displayName}
        />
        <CreateProfileBlog />
      </>
    )
  } else {
    return <h1>Wait please LOADING...</h1>
  }
}
export default OtherUserMainPage
