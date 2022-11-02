import { useState, useEffect } from "react";
import { Modal, Button, Form, Row, Col, Table, InputGroup, FormControl } from "react-bootstrap";
import "./ProfileMenu.css";

import { Link } from "react-router-dom";

// HOW TO USE
// Create variables like in an example at the bottom and send them into props
// profileMenuTexts - Menu items texts
// profileMenuLinks - Links to new pages
// activeText - Active text to a specific menu item
// imgLink - User image link
//
// Example
// const profileMenuTexts = ["Overview", "Own recipes", "Settings"];
// const profileMenuLinks = ["/to", "/to", "/to", "/to"];
// const activeText = "Own recipes";
// Use in page:
/*
	<ProfileMenu
	profileMenuTexts={profileMenuTexts}
	profileMenuLinks={profileMenuLinks}
	activeText={activeText}
	imgLink={userImg}
	userNickName={userNickName}/>; 
*/

function ProfileMenu(props) {
    const [profileMenu, setProfileMenu] = useState([]);
    function createProfileMenu() {
        let object = [];
        for (let i = 0; i < props.profileMenuTexts.length; i++) {
            let isActive = false;
            if (props.profileMenuTexts[i] === props.activeText) {
                isActive = true;
            }
            object.push({
                name: props.profileMenuTexts[i],
                link: props.profileMenuLinks[i],
                active: isActive,
            });
        }
        setProfileMenu(object);
    }
    // onLoad function
    useEffect(() => {
        createProfileMenu();
    }, []);

    return (
        <div className="profileMenu">
            <div className="d-flex flex-column">
                <div className="d-flex">
                    <img className="rounded-circle maxWidthForIng" src={props.imgLink} alt="img" />
                </div>
                <div className="d-flex  p-3">
                    <strong className="">{props.userNickName}</strong>
                </div>
            </div>
            <div className="nav d-flex  text-center">
                <ul className="nav p-3 navbar-nav w-100">
                    {profileMenu.map((element) => {
                        if (element.active) {
                            return (
                                <li key={element.name} className="nav-item">
                                    <div className="d-flex align-items-center text-center border">
                                        <Link
                                            className="w-100 nav-link border border-dark activeMenuItem"
                                            to={element.link}
                                        >
                                            <strong>{element.name}</strong>
                                        </Link>
                                    </div>
                                </li>
                            );
                        }
                        return (
                            <li key={element.name} className="nav-item">
                                <div className="d-flex align-items-center text-center">
                                    <Link className=" nav-link border border-dark" to={element.link}>
                                        <p>{element.name}</p>
                                    </Link>
                                </div>
                            </li>
                        );
                    })}
                </ul>
            </div>
        </div>
    );
}
export default ProfileMenu;
