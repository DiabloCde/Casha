import axios from 'axios';
import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { Routes, Route, useNavigate } from 'react-router-dom';

import AdminHeader from '../../components/adminHeaderCompoment/AdminHeader';
import AdminNavbar from '../../components/adminNavbarComponent/AdminNavbar';
import UsersStingCell from '../../components/usersStringCellComponent/UsersStingCell';
import UsersPhotoCell from '../../components/usersPhotoCellComponent/UsersPhotoCell';

import styles from './AdminViewUsers.css';

//const URL_GETUSERS = "https://localhost:7128/api/User?search=s"
const URL_GETUSERS = "https://localhost:7128/api/User/All";
const URL_FILTER_USERS = "https://localhost:7128/api/User/AdminFilter"

function AdminViewUsers() {
    const navigate = useNavigate();
    const [users, setUsers] = useState([]);
    const [isRendered, setIsRendered] = useState(false);

    const [login, setLogin] = useState("");
    const [firstName, setFirstName] = useState("");
    const [secondName, setSecondName] = useState("");
    let queryForFilter = ""


    async function getAllUsers() {
        const response = await axios({
            method: "get",
            url: URL_GETUSERS,
            data: JSON.stringify(),
            headers: { "Content-Type": "application/json; charset=utf-8" },
        }).then((response) => {
            console.log(response.data)
            setUsers(response.data)
        })
    }

    function queryHepler(hasOneParameter, newParameter, parameterName) {
        if (newParameter != "") {

            if (!hasOneParameter) {
                queryForFilter += "?";
            }
            else {
                queryForFilter += "&"
            }

            queryForFilter += parameterName + "=" + newParameter;
            return true;
        }
        return hasOneParameter;
    }

    async function filterUsers() {
        let hasOneParameter = false;
        hasOneParameter = queryHepler(hasOneParameter, login, "userName");
        hasOneParameter = queryHepler(hasOneParameter, firstName, "firstName");
        hasOneParameter = queryHepler(hasOneParameter, secondName, "secondName");

        console.log("Filter Query: " + URL_FILTER_USERS + queryForFilter);
        const response = await axios({
            method: "get",
            url: URL_FILTER_USERS + queryForFilter,
            data: JSON.stringify(),
            headers: { "Content-Type": "application/json; charset=utf-8" },
        }).then((response) => {
            console.log(response.data)
            setUsers(response.data)
        })
    }

    useEffect(() => {
        getAllUsers()
        setIsRendered(true)
    }, [])

   function openUserPage (){
    alert("ok");
    navigate('/OtherUserMainPage');
   }

    if (isRendered) {
        return (
            <>
                <AdminHeader />
                <AdminNavbar />
                <main className='main'>
                    <div className="form_block" id='form_block'>
                        <div className="user_head_container">
                            <h1>Users</h1>
                        </div>
                        <form action="POST" className="form">
                            <div className="users_filtres">
                                <div className="input_block">
                                    <label htmlFor="login">Nick Name:</label>
                                    <input id="login" type="text" onChange={e => setLogin(e.target.value)} />
                                </div>
                                <div className="input_block">
                                    <label htmlFor="firstName">First Name:</label>
                                    <input type="text" id="firstName" onChange={e => setFirstName(e.target.value)} />
                                </div>
                                <div className="input_block">
                                    <label htmlFor="secondName">Last Name:</label>
                                    <input type="text" id="secondName" onChange={e => setSecondName(e.target.value)} />
                                </div>
                            </div>
                            <button className="filter_button" type="button" onClick={filterUsers} >Filter</button>
                        </form>

                        <table className='table_admin'>
                            <tr className='table_row'>
                                <th className='table_cell'>Profile photo</th>
                                <th className='table_cell'>Nick Name</th>
                                <th className='table_cell'>First Name</th>
                                <th className='table_cell'>Last Name</th>
                                <th className='table_cell'>Actions</th>
                            </tr>
                            {users?.reverse().map((item) => (
                                <tr className='table_row' key={item.id}>
                                    <td className='table_cell'>
                                        <div className="img_div">
                                            <UsersPhotoCell
                                                imageUrl={item.profilePictureUrl} />
                                           
                                        </div>
                                    </td>
                                    <td className="table_cell">
                                        <div className="nick_name">
                                            <UsersStingCell
                                                cellValue={item.displayName} />
                                        </div>
                                    </td>
                                    <td className="table_cell">
                                        <div className="nick_name">
                                            <UsersStingCell
                                                cellValue={item.firstName} />
                                        </div>
                                    </td>
                                    <td className="table_cell">
                                        <div className="nick_name">
                                            <UsersStingCell
                                                cellValue={item.lastName} />
                                        </div>
                                    </td>
                                    <td className="table_cell">
                                        <button className='view_button' onClick={openUserPage}>View</button>
                                    </td>
                                </tr>
                            ))}
                        </table>
                        <button className='loadMore_button' onClick={getAllUsers}>Load More</button>
                    </div>
                </main>
            </>
        )
    }
    else {
        return <h1>Please Wait</h1>
    }
}

export default AdminViewUsers
