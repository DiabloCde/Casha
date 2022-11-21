import axios from 'axios';
import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';

import AdminHeader from '../../components/adminHeaderCompoment/AdminHeader';
import AdminNavbar from '../../components/adminNavbarComponent/AdminNavbar';


import styles from './AdminViewUsers.css';

//const URL_GETUSERS = "https://localhost:7128/api/User?search=s"
const URL_GETUSERS = "https://localhost:7128/api/User/All"

function AdminViewUsers() {
    const [users, setUsers] = useState([]);
    const [isRendered, setIsRendered] = useState(false);

    const [login, setLogin] = useState("");
    const [firstName, setFirstName] = useState("");
    const [secondName, setSecondName] = useState("");

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

    async function filterUsers() {
        console.log(login);
    }

    useEffect(() => {
        getAllUsers()
        setIsRendered(true)
    }, [])

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
                                    <label htmlFor="login">Login:</label>
                                    <input id="login" type="text" onChange={e=>setLogin(e.target.value)}/>
                                </div>
                                <div className="input_block">
                                    <label htmlFor="firstName">First Name:</label>
                                    <input type="text" id="firstName" onChange = {e=>setFirstName(e.target.value)}/>
                                </div>
                                <div className="input_block">
                                    <label htmlFor="secondName">Second Name:</label>
                                    <input type="text" id="secondName" onChange={e=>setSecondName(e.target.value)}/>
                                </div>
                            </div>
                            <button className="filter_button" type="button" onClick={filterUsers} >Filter</button>
                        </form>

                        <table className='table_admin'>
                            <tr className='table_row'>
                                <th className='table_cell'>Profile photo</th>
                                <th className='table_cell'>Nick Name</th>
                                <th className='table_cell'>Actions</th>
                            </tr>
                            {users?.reverse().map((item) => (
                                <tr className='table_row' key={item.id}>
                                    <td className='table_cell'>
                                        <div className="img_div">
                                            <img src={item.profilePictureUrl} alt="User Image" />
                                        </div>
                                    </td>
                                    <td className="table_cell">
                                        <div className="nick_name">
                                            <p>{item.displayName}</p>
                                        </div>
                                    </td>
                                    <td className="table_cell">
                                        <button className='view_button'>View</button>
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
