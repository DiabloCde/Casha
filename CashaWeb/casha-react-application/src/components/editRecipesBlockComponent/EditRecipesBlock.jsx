import React from 'react'
import { useState } from 'react';

import styles from './EditRecipesBlock.css';

const POST_RECIPE_URL ="https://localhost:7128/api/Recipe"

function EditRecipesBlock() {
    const [name, setName] = useState("");
    const [recipeImageUrl, setRecipeImageUrl] = useState("");
    const [difficulty, setDifficulty] = useState("");
    const [instruction, setInstruction] = useState("");
    const [userId, setUserId] = useState("");
    const [recipeProducts, setRecipesProducts] = useState([]);
    const [recipeCategories, setRecipesCAtegories] = useState([]);

    const postRecipe = () => {
        document.getElementById('editRecipes_block').style.display = 'none';
        document.getElementById('form_block').style.display = 'block';
    }

    function convertComplexity(){

    }

    return (
        <div className='editRecipes_block' id='editRecipes_block' >
            <h1>Add/Edit recipe</h1>
            <form className='editRecipe_form' action="POST">
                <div className="input_block">
                    <label htmlFor="name">Name:</label>
                    <input type="text" id="name" onChange={e=> setName(e.target.value)}/>
                </div>
                <div className="input_block">
                    <label htmlFor="cuisine">Type of cuisine:</label>
                    <input type="text" id="cuisine" onChange={e=> setCuisine(e.target.value)}/>
                </div>
                <div className="input_block">
                    <label htmlFor="holidays">Holidays:</label>
                    <input type="text" id="holidays" />
                </div>
                <div className="input_block">
                    <label>Complexity:</label>
                    <div className="radio_buttons">
                        <input className='radioButton' type="radio" name="complexity" id="complexityEasy" value={"0"} />
                        <label className='radioLabel' htmlFor="complexityEasy">Easy</label>
                        <input className='radioButton' type="radio" name="complexity" id="complexityMedium" value={"1"} />
                        <label className='radioLabel' htmlFor="complexityMedium">Medium</label>
                        <input className='radioButton' type="radio" name="complexity" id="complexityHard" value={"2"} />
                        <label className='radioLabel' htmlFor="complexityHard">Hard</label>
                    </div>
                </div>
                <div className="input_block">
                    <label htmlFor="ingredients">Ingredients</label>
                    <select id="ingredients">
                        <option value="Carrot">Carrot</option>
                        <option value="Cuccumber">Cucumber</option>
                        <option value="Potato">Potato</option>
                        <option value="Grass">Grass</option>
                    </select>
                </div>
                <div className="input_block">
                    <label htmlFor="image">Image:</label>
                    <input type="file" name="imageFile" id="image" />
                </div>
                <div className="input_block">
                    <label htmlFor="instructions">Instructions</label>
                    <textarea name="" id="instructions" rows="5" placeholder='Write your instructions here'></textarea>
                </div>
                <button className='submit_button_addrecipe' type="submit" onClick={postRecipe}>Save</button>
            </form>
        </div>
    )
}

export default EditRecipesBlock
