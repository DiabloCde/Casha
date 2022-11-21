import axios from 'axios';
import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';

import AdminHeader from '../../components/adminHeaderCompoment/AdminHeader';
import AdminNavbar from '../../components/adminNavbarComponent/AdminNavbar';


import styles from './AdminViewUsers.css';

const URL_GETUSERS = "https://localhost:7128/api/User?search=s"
const EMPTY_STRING = ""


function AdminViewUsers() {
    const [users, setUsers] = useState([]);
    const [isRendered, setIsRendered] = useState(false);

    async function getAllUsers() {
        const response = await axios({
            method: "get",
            url: URL_GETUSERS + EMPTY_STRING,
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

    if (isRendered) {
        return (
            <>
                <AdminHeader />
                <AdminNavbar />
                <main className='main'>
                    <div className="form_block" id='form_block'>
                        <div className="user_block_wrapper">
                            <div className="user_head_container">
                                <h1>Users</h1>
                            </div>
                            <button className='add_button'>Add</button>
                        </div>
                        <div className="users_table">
                            {users?.reverse().map(item => (
                                <div className="user_wrapper" key={item.id}>
                                    <div className="profile_info_wrapper">
                                        <div className="img_div">
                                            <img src={item.profilePictureUrl} alt="User Image" />
                                        </div>
                                        <div className="nick_name">
                                            <p>{item.displayName}</p>
                                        </div>
                                    </div>
                                    <button className='button_delete'>Delete</button>
                                </div>
                            ))}
                        </div>
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
