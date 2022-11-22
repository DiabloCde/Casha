import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';

import AdminHeader from '../../components/adminHeaderCompoment/AdminHeader';
import AdminNavbar from '../../components/adminNavbarComponent/AdminNavbar';
import EditRecipesBlock from '../../components/editRecipesBlockComponent/EditRecipesBlock';
import RecipeCategoryCell from '../../components/recipeCategoryCellComponent/RecipeCategoryCell';
import RecipeComplexityCell from '../../components/recipeComplexityCellComponent/RecipeComplexityCell';
import axios from 'axios';

import styles from './AdminEditRecipes.css'

const URL_GET_RECIPES = "https://localhost:7128/api/Recipe/All"

function AdminEditRecipes() {
    const [recipes, setRecipes] = useState([]);
    const [isRendered, setIsRendered] = useState(false);

    async function getAllRecipes() {
        const response = await axios({
            method: "get",
            url: URL_GET_RECIPES,
            data: JSON.stringify(),
            headers: { "Content-Type": "application/json; charset=utf-8" },
        }).then((response) => {
            console.log(response.data)
            setRecipes(response.data)
        })
    }

    useEffect(() => {
        getAllRecipes()
        setIsRendered(true)
    }, [])

    const filterRecipes = async (e) => {
        alert('recipes was filtered');
    }

    const addRecipe = (e) => {
        document.getElementById('editRecipes_block').style.display = 'block';
        console.log(document.getElementById('form_block'));
        document.getElementById('form_block').style.display = 'none';
    }
    if (isRendered) {
        return (
            <>
                <AdminHeader />
                <AdminNavbar />
                <main class='main'>
                    <EditRecipesBlock />
                    <div className="form_block" id='form_block'>
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
                        <button className='add_button' id='add_button' onClick={addRecipe}>Add</button>

                        <table className='table_admin'>
                            <tr className='table_row'>
                                <th className='table_cell'>Name</th>
                                <th className='table_cell'>Cuisine</th>
                                <th className='table_cell'>Complexity</th>
                                <th className='table_cell'>Actions</th>
                            </tr>
                            {recipes?.reverse().map(item => (
                                <tr className='table_row' key={item.recipeId}>
                                    <td className='table_cell'>{item.name}</td>
                                    <td className="table_cell">
                                        <RecipeCategoryCell
                                            categories={item.recipeCategories}
                                        />
                                    </td>
                                    <td className="table_cell complexity_cell">
                                        <RecipeComplexityCell
                                            complexity={item.difficulty}
                                        />
                                    </td>
                                    <td className="tablecell">
                                        <button className='view_button'>View</button>
                                        <button className='edit_button'>Edit</button>
                                        <button className='delete_button'>Delete</button>
                                    </td>
                                </tr>
                            ))}
                        </table>
                        <button className='loadMore_button' onClick={getAllRecipes}>Load More</button>
                    </div>
                </main>
            </>
        )
    }
    else {
        return <h1>Please Wait</h1>
    }
}

export default AdminEditRecipes
