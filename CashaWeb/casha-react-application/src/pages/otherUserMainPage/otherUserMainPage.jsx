import React from "react"
import CreateProfileBlog from "../../components/createProfileBlogComponent/createProfileBlog"
import UserHeader from "../../components/userHeaderComponent/UserHeader"
import ProfileMenu from "../../components/ProfileMenuComponent/ProfileMenu"
import { useRef, useState, useEffect, useContext } from "react"
import { Routes, Route, useNavigate } from "react-router-dom"
import { Link } from "react-router-dom"

import axios from "axios"

const URL =
  "https://localhost:7128/api/User/028f54b4-6c1e-4533-a81d-616a2e4c065b"

function OtherUserMainPage() {

  const [userInfo, setUserInfo] = useState({})
  const [userPosts, setUserPosts] = useState({})
  const [isRendered, setIsRendered] = useState(false)
  const profileMenuTexts = ["Overview", "User recipes"]
  const profileMenuLinks = ["/to", "/to"]
  const activeText = "Overview"

  useEffect(() => {
    setUserInfo(getUser());
  },[])

  async function getUser() {
    const response = await axios({
      method: "get",
      url: URL,
      data: JSON.stringify(),
      headers: { "Content-Type": "application/json; charset=utf-8" },
    }).then((response) => {
      setUserInfo(response.data)
      setIsRendered(true)
      return response.data
    })
  }



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
}
export default OtherUserMainPage
