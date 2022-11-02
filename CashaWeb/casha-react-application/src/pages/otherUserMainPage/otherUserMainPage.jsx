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
  const profileMenuTexts = ["Overview", "User recipes"]
  const profileMenuLinks = ["/to", "/to"]
  const activeText = "Overview"
  async function render() {
    const response = await axios({
      method: "get",
      url: URL,
      data: JSON.stringify(),
      headers: { "Content-Type": "application/json; charset=utf-8" },
    }).then((response) => {
      console.log(response.data)
    })
    return response.data
  }

  var object = render()
  console.log(object.data)

  // console.log()
  return (
    <>
      <UserHeader />
      <ProfileMenu
        profileMenuTexts={profileMenuTexts}
        profileMenuLinks={profileMenuLinks}
        activeText={activeText}
        imgLink={
          "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/American_Beaver.jpg/640px-American_Beaver.jpg"
        }
        userNickName={"popabebra"}
      />
      <CreateProfileBlog />
    </>
  )
}
export default OtherUserMainPage
