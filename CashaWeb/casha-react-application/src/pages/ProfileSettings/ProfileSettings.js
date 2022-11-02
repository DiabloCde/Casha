import { useState, useEffect } from "react";
import { Button, InputGroup, FormControl } from "react-bootstrap";

import axios from "../../api/axios";

import "./ProfileSettings.css";
import ProfileMenu from "../../components/ProfileMenuComponent/ProfileMenu.js";

const profileMenuTexts = ["Overview", "Own recipes", "Settings"];
const profileMenuLinks = ["/to", "/to", "/to"];
const activeText = "Settings";

const API_Imgur = "https://api.imgur.com/3/image/";
const Client_ID = "e9a6b3bb9d8860f";

const URL_USER = "https://localhost:7128/api/User/";

function ProfileSettings() {
	const [user, setUser] = useState([]);

	// temporary variables to store user changes
	const [userImg, setUserImg] = useState("");
	const [userNickName, setUserNickName] = useState("");
	const [userName, setUserName] = useState("");
	const [userSurname, setUserSurname] = useState("");
	const [userEmail, setUserEmail] = useState("");
	const [userBio, setUserBio] = useState("");
	const [currentPassword, setCurrentPassword] = useState("");
	const [newPassword, setNewPassword] = useState("");

	// TODO onLoad function
	useEffect(() => {
		getUser();
		setTempVariables();
	}, []);

	// TODO API GET user (user id in cookies)(set user data into variable 'user')
	function getUser() {
		// fetch(URL_USER + "028f54b4-6c1e-4533-a81d-616a2e4c065b", {
		// 	method: "GET",
		// 	headers: {
		// 		Accept: "application/json",
		// 		"Content-Type": "application/json"
		// 	}
		// })
		// 	.then(res => res.json())
		// 	.then(
		// 		result => {
		// 			console.log(result);
		// 		},
		// 		error => {
		// 			alert("Failed");
		// 		}
		// 	);
		const response = axios.get(URL_USER + "028f54b4-6c1e-4533-a81d-616a2e4c065b", JSON.stringify(), {
			headers: { "Content-type": "application/json" },
			withCredentials: true
		});
		//Names same as back expectes
		console.log(JSON.stringify(response?.data)); //temp
		console.log(123);
	}

	// TODO SET temporary variables to store user changes
	function setTempVariables() {
		// temporary
		// take data from user!!!
		setUserImg(
			"https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0f/ba/29/5c/img-worlds-of-adventure.jpg?w=1200&h=-1&s=1"
		);
		setUserNickName("User1");
		setUserName();
		setUserSurname();
		setUserEmail();
		setUserBio();
	}

	// TODO API update user data (take data from temporary variables)
	function updateUserData() {}

	// TODO API change user password (data: currentPassword, newPassword)
	function changeUserPassword() {}

	// Save img in imgur and write img to object
	function saveImg(ev) {
		const formdata = new FormData();
		formdata.append("image", ev.target.files[0]);
		fetch(API_Imgur, {
			method: "post",
			headers: {
				Authorization: "Client-ID " + Client_ID,
				Accept: "application/json"
			},
			body: formdata
		})
			.then(res => res.json())
			.then(data => {
				setUserImg(data.data.link);
				console.log(userImg);
			});
	}

	return (
		<div className="ProfileSettings p-2">
			<div className="container">
				<div className="row">
					<div className="col col-3">
						<ProfileMenu
							profileMenuTexts={profileMenuTexts}
							profileMenuLinks={profileMenuLinks}
							activeText={activeText}
							imgLink={userImg}
							userNickName={userNickName}
						/>
					</div>
					<div className="container col col-9 border rounded shadow-sm p-5">
						<div className="d-flex justify-content-center text-center container display-2">
							<strong>Settings</strong>
						</div>
						<div className="row">
							<div className="col">
								<div className="row d-flex justify-content-center text-center p-2">
									<img className="rounded-circle maxWidthForIng" src={userImg} alt="img" />
								</div>
								<div className="row d-flex justify-content-center text-center p-2">
									<InputGroup className="mb-3">
										<FormControl
											aria-label="Default"
											placeholder="file"
											type="file"
											size="sm"
											onChange={e => saveImg(e)}
											aria-describedby="inputGroup-sizing-default"
										/>
									</InputGroup>
									{/* // TODO add onClick function to load new user img */}
									<Button className="btn btn-sm btn-warning w-100 yellowButton">
										<strong className="colorBlack">Edit</strong>
									</Button>
								</div>
							</div>
							<div className="col col-8 container p-2">
								<div className="container row display-6 p-2">
									<h3>
										<strong>Change your personal data</strong>
									</h3>
								</div>
								<div className="container row p-2">
									<h5>Change your name</h5>
									<InputGroup className="mb-3">
										<FormControl
											aria-label="Default"
											placeholder="Name"
											value={userName}
											onChange={e => setUserName(e.target.value)}
											aria-describedby="inputGroup-sizing-default"
											required
										/>
									</InputGroup>
								</div>
								<div className="container row p-2">
									<h5>Change your surname</h5>
									<InputGroup className="mb-3">
										<FormControl
											aria-label="Default"
											placeholder="Surname"
											value={userSurname}
											onChange={e => setUserSurname(e.target.value)}
											aria-describedby="inputGroup-sizing-default"
											required
										/>
									</InputGroup>
								</div>
								<div className="container row p-2">
									<h5>Change your email</h5>
									<InputGroup className="mb-3">
										<FormControl
											aria-label="Default"
											placeholder="email@gmail.com"
											value={userEmail}
											onChange={e => setUserEmail(e.target.value)}
											aria-describedby="inputGroup-sizing-default"
											required
										/>
									</InputGroup>
								</div>
							</div>
						</div>
						<div className="row">
							<div className="row container col p-2">
								<h5>Bio</h5>
								<InputGroup className="mb-3">
									<FormControl
										aria-label="Default"
										placeholder="Bio"
										as="textarea"
										rows={7}
										value={userBio}
										onChange={e => setUserBio(e.target.value)}
										aria-describedby="inputGroup-sizing-default"
										required
									/>
								</InputGroup>
							</div>
							<div className="row container">
								<div className="d-flex justify-content-end p-2">
									{/* // TODO add onClick function to edit user data */}
									<Button className="btn btn-sm btn-warning yellowButton">
										<strong className="colorBlack">Save</strong>
									</Button>
								</div>
							</div>
						</div>
						<div className="row">
							<div className="col">
								<div className="row">
									<div className="container row p-2">
										<h3>
											<strong>Change your password</strong>
										</h3>
									</div>
								</div>
								<div className="row">
									<div className="row container col p-2">
										<h5>Current Password</h5>
										<InputGroup className="mb-3">
											<FormControl
												aria-label="Default"
												placeholder=""
												type="password"
												value={currentPassword}
												onChange={e => setCurrentPassword(e.target.value)}
												aria-describedby="inputGroup-sizing-default"
											/>
										</InputGroup>
									</div>
								</div>
								<div className="row">
									<div className="row container col p-2">
										<h5>New password</h5>
										<InputGroup className="mb-3">
											<FormControl
												aria-label="Default"
												placeholder=""
												type="password"
												value={newPassword}
												onChange={e => setNewPassword(e.target.value)}
												aria-describedby="inputGroup-sizing-default"
											/>
										</InputGroup>
									</div>
								</div>
								<div className="row">
									<div className="d-flex justify-content-start p-2">
										{/* // TODO add onClick function to edit user password */}
										<Button className="btn btn-sm btn-warning yellowButton">
											<strong className="colorBlack">Save</strong>
										</Button>
									</div>
								</div>
							</div>
							<div className="col"></div>
						</div>
					</div>
				</div>
			</div>
		</div>
	);
}
export default ProfileSettings;
