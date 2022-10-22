import React from 'react';

import AdminHeader from '../../components/adminHeaderCompoment/AdminHeader';
import AdminNavbar from '../../components/adminNavbarComponent/AdminNavbar';

import styles from './AdminEditRecipes.css'

function AdminEditRecipes() {

    const filterRecipes = async (e) => {
        alert('recipes was filtered');
    }

    const addRecipe = (e) => {
        alert('new Recipe');
    }

    return (
        <>
            <AdminHeader />
            <AdminNavbar />
            <main class='main'>
                <div className="form_block">
                    <h1>Recipes</h1>
                    <form action="POST" className="form">
                        <div className="recipe_filtres">
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
                        </div>

                        <div className="userInformation">
                            <h3 className='userInformation__head'>User:</h3>
                            <label htmlFor="userId">Id:</label>
                            <input type="text" id="userId" />
                            <label htmlFor="userName">Name:</label>
                            <input type="text" id="userName" />
                        </div>

                        <div className="ingredientsInformation">
                            <h3 className='ingredientsInformation__head'>Ingredients:</h3>
                            <label htmlFor="ingredientId">Id:</label>
                            <input type="text" id="ingredientId" />
                            <label htmlFor="ingredientSelect">Select:</label>
                            <input type="text" id="ingredientSelect" />
                        </div>

                        <button className="filter_button" type="button" onClick={filterRecipes} >Filter</button>
                    </form>
                </div>
                <div className="scrolling">

                </div>
            </main>

        </>
    )
}

export default AdminEditRecipes
