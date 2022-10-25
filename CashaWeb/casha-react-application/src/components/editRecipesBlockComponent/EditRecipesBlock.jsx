import React from 'react'

import styles from './EditRecipesBlock.css';

function EditRecipesBlock() {
    const sendRecipe = () =>{
        document.getElementById('editRecipes_block').style.visibility ='hidden';
    }

    return (
        <div className='editRecipes_block' id = 'editRecipes_block' >
            <h1>Add/Edit recipe</h1>
            <form action="POST">
                <label htmlFor="name">Name:</label>
                <input type="text" id ="name"/>
                <label htmlFor="cuisine">Type of cuisine:</label>
                <input type="text" id ="cuisine"/>
                <label htmlFor="holidays">Holidays:</label>
                <input type="text" id ="holidays" />
                <label htmlFor="complexity">Complexity:</label>
                <input type="radio" name="complexity" id="complexityEasy" value={"Easy"}/>
                <label htmlFor="complexityEasy">Easy</label>
                <input type="radio" name="complexity" id="complexityMedium" value={"Medium"} />
                <label htmlFor="complexityMedium">Medium</label>
                <input type="radio" name="complexity" id="complexityHard" value={"Hard"} />
                <label htmlFor="complexityHard">Hard</label>
                <label htmlFor="ingredients">Ingredients</label>
                <input type="text" id="ingredients" />
                <label htmlFor="image">Image:</label>
                <input type="image" id="image" src="" alt="" />
                <label htmlFor="instructions">Instructions</label>
                <input type="text" id='instructions'/>
                <button type="submit" onClick={sendRecipe}></button>

            </form>
        </div>
    )
}

export default EditRecipesBlock
