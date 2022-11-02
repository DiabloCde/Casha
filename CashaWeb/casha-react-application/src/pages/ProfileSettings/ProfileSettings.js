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
const USER_ID = "028f54b4-6c1e-4533-a81d-616a2e4c065b";

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

<<<<<<< HEAD
=======
	// TODO onLoad function
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
	useEffect(() => {
		getUser();
	}, []);

	useEffect(() => {
		setTempVariables();
	}, [user]);

<<<<<<< HEAD
=======
	// TODO API GET user (user id in cookies)(set user data into variable 'user')
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
	async function getUser() {
		try {
			const response = await axios.get(URL_USER + USER_ID);
			setUser(response.data);
<<<<<<< HEAD
=======
			//setTempVariables();
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
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
<<<<<<< HEAD
	}

	function setTempVariables() {
		// take data from user
=======
		//Names same as back expectes
	}

	// TODO SET temporary variables to store user changes
	function setTempVariables() {
		console.log(user);
		// temporary
		// take data from user!!!
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
		setUserImg(user.profilePictureUrl);
		setUserNickName(user.displayName);
		setUserName(user.firstName);
		setUserSurname(user.lastName);
<<<<<<< HEAD
		// TODO ADD Email in API request
=======
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
		//setUserEmail();
		setUserBio(user.bio);
	}

<<<<<<< HEAD
	// TODO  ADD Email in API request
	const handleSubmit = async e => {
		e.preventDefault();
		// New updated user
=======
	// TODO API update user data (take data from temporary variables)
	const handleSubmit = async e => {
		e.preventDefault();
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
		let newUser = {
			id: user.id,
			bio: userBio,
			displayName: userNickName,
			firstName: userName,
			lastName: userSurname,
			isCertified: user.isCertified,
			profilePictureUrl: userImg
		};
		try {
			const response = await axios.put(URL_USER + USER_ID, newUser);
			console.log(response);
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
	};

	// TODO API change user password (data: currentPassword, newPassword)
	function changeUserPassword() {}

	// Save img in imgur and write img to object
	function saveImg(ev) {
		const formdata = new FormData();
		formdata.append("image", ev.target.files[0]);
		fetch(API_Imgur, {
<<<<<<< HEAD
			method: "POST",
=======
			method: "post",
>>>>>>> 23dd70405366905225a79ddc9db517004f94d4ff
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
								{/* User Email */}
								{/* <div className="container row p-2">
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
								</div> */}
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
									<Button onClick={handleSubmit} className="btn btn-sm btn-warning yellowButton">
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
