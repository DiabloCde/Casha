import React from 'react';

import AdminHeader from '../../components/adminHeaderCompoment/AdminHeader';
import AdminNavbar from '../../components/adminNavbarComponent/AdminNavbar';

import styles from './AdminEditRecipes.css'

function AdminEditRecipes() {
    return (
        <>
            <AdminHeader />
            <AdminNavbar />
            <main class='main'>
               
                <div className="form_block">
                    <h1>Recipes</h1>
                    <form action="POST" className="form">
                        <div className="input_block">
                            <label htmlFor="name">Name:</label>
                            <input id="name" type="text" />
                        </div>
                        <div className="input_block">
                            <label htmlFor="cuisine">Cuisine:</label>
                            <input type="text" id="cuisine" />
                        </div>
                        <div className="input_block">
                            <label htmlFor="holidays">Holidays:</label>
                            <input type="text" id="holidays" />
                        </div>
                        <div className="input_block">
                            <label htmlFor="complexity">Complexity:</label>
                            <input type="text" id="complexity" />
                        </div>
                    </form>
                </div>
                <div className="scrolling">
                    
                    </div>
            </main>

        </>
    )
}

export default AdminEditRecipes
