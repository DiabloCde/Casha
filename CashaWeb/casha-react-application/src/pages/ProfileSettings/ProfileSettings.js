import { useState, useEffect } from "react";
import { Button, InputGroup, FormControl } from "react-bootstrap";

import axios from "axios";

import "./ProfileSettings.css";
import ProfileMenu from "../../components/ProfileMenuComponent/ProfileMenu.js";

const profileMenuTexts = ["Overview", "Own recipes", "Settings"];
const profileMenuLinks = ["/to", "/to", "/to"];
const activeText = "Settings";

const API_Imgur = "https://api.imgur.com/3/image/";
const Client_ID = "e9a6b3bb9d8860f";

const URL_USER = "https://localhost:7128/api/User/";
const USER_ID = "f4ce72b6-f67f-433b-925c-e0aa6798cd87";

const ChangePasswordUrl = "https://localhost:7128/api/Account/changePassword";

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

	useEffect(() => {
		getUser();
	}, []);

	useEffect(() => {
		setTempVariables();
	}, [user]);

	async function getUser() {
		try {
			const response = await axios.get(URL_USER + USER_ID);
			setUser(response.data);
		} catch (err) {
			//errors that expected from back
			if (!err?.response) {
				alert("No Server Response");
			} else if (err.response?.status === 400) {
				alert("Missing Password or Login");
			} else if (err.response?.status === 401) {
				alert("Unathorized");
			} else {
				alert("Login failed");
			}
		}
	}

	function setTempVariables() {
		//console.log(user);
		// take data from user
		setUserImg(user.profilePictureUrl == null ? "" : user.profilePictureUrl);
		setUserNickName(user.displayName == null ? "" : user.displayName);
		setUserName(user.firstName == null ? "" : user.firstName);
		setUserSurname(user.lastName == null ? "" : user.lastName);
		setUserEmail(user.email == null ? "" : user.email);
		setUserBio(user.bio == null ? "" : user.bio);
	}

	const updateUserHandleSubmit = async e => {
		e.preventDefault();
		// New updated user
		let newUser = {
			id: user.id,
			bio: userBio,
			email: userEmail,
			displayName: userNickName,
			firstName: userName,
			lastName: userSurname,
			isCertified: user.isCertified,
			profilePictureUrl: userImg
		};
		console.log(newUser);
		try {
			const response = await axios.put(URL_USER + USER_ID, newUser);
		} catch (err) {
			//errors that expected from back
			if (!err?.response) {
				alert("No Server Response");
			} else if (err.response?.status === 400) {
				alert("400");
			} else if (err.response?.status === 401) {
				alert("Unathorized");
			} else {
				alert("Login failed");
			}
		}
	};

	// TODO API change user password (data: currentPassword, newPassword)
	const changeUserPasswordHandleSubmit = async e => {
		e.preventDefault();
		// View model to change password
		let ChangePasswordViewModel = {
			username: user.displayName,
			oldPassword: currentPassword,
			newPassword: newPassword
		};

		try {
			const response = await axios.post(ChangePasswordUrl, ChangePasswordViewModel);
		} catch (err) {
			//errors that expected from back
			if (!err?.response) {
				alert("No Server Response");
			} else if (err.response?.status === 400) {
				alert("Not correct password");
			} else if (err.response?.status === 401) {
				alert("Unathorized");
			} else {
				alert("Login failed");
			}
		}
	};
	// How to use:
	// Instead of localhost write your local ip address, like: 192.168.197
	// Save img in imgur and write img to object
	function saveImg(ev) {
		const formdata = new FormData();
		formdata.append("image", ev.target.files[0]);
		fetch(API_Imgur, {
			method: "POST",
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
								<div className="my_image row d-flex justify-content-center text-center p-2">
									<img className="rounded-circle" src={userImg} alt="img" />
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
											maxlength="50"
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
											maxlength="50"
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
											maxlength="50"
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
										maxlength="500"
										onChange={e => setUserBio(e.target.value)}
										aria-describedby="inputGroup-sizing-default"
										required
									/>
								</InputGroup>
							</div>
							<div className="row container">
								<div className="d-flex justify-content-end p-2">
									<Button onClick={updateUserHandleSubmit} className="btn btn-sm btn-warning yellowButton">
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
												maxlength="50"
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
												maxlength="50"
												onChange={e => setNewPassword(e.target.value)}
												aria-describedby="inputGroup-sizing-default"
											/>
										</InputGroup>
									</div>
								</div>
								<div className="row">
									<div className="d-flex justify-content-start p-2">
										<Button
											onClick={changeUserPasswordHandleSubmit}
											className="btn btn-sm btn-warning yellowButton">
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
