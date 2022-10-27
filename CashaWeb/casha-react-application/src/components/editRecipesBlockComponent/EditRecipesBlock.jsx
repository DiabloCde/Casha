import React from 'react'

import styles from './EditRecipesBlock.css';

function EditRecipesBlock() {
    const sendRecipe = () => {
        document.getElementById('editRecipes_block').style.display = 'none';
        document.getElementById('form_block').style.display = 'block';
    }

    return (
        <div className='editRecipes_block' id='editRecipes_block' >
            <h1>Add/Edit recipe</h1>
            <form action="POST">
                <div className="input_block">
                    <label htmlFor="name">Name:</label>
                    <input type="text" id="name" />
                </div>
                <div className="input_block">
                    <label htmlFor="cuisine">Type of cuisine:</label>
                    <input type="text" id="cuisine" />
                </div>
                <div className="input_block">
                    <label htmlFor="holidays">Holidays:</label>
                    <input type="text" id="holidays" />
                </div>
                <div className="input_block">
                    <label htmlFor="complexity">Complexity:</label>
                    <input type="radio" name="complexity" id="complexityEasy" value={"Easy"} />
                </div>
                <div className="input_block">
                <label htmlFor="complexityEasy">Easy</label>
                <input type="radio" name="complexity" id="complexityMedium" value={"Medium"} />
                </div>
                <div className="input_block">
                <label htmlFor="complexityMedium">Medium</label>
                <input type="radio" name="complexity" id="complexityHard" value={"Hard"} />
                </div>
                <div className="input_block">
                <label htmlFor="complexityHard">Hard</label>
                <label htmlFor="ingredients">Ingredients</label>
                </div>
                <div className="input_block">
                <input type="text" id="ingredients" />
                </div>
                <div className="input_block">
                <label htmlFor="image">Image:</label>
                <input type="image" id="image" src="" alt="" />
                </div>
                <div className="input_block">
                <label htmlFor="instructions">Instructions</label>
                <input type="text" id='instructions' />
                </div>
                <button className='submit_button_addrecipe' type="submit" onClick={sendRecipe}>Submit</button>

            </form>
        </div>
    )
}

export default EditRecipesBlock
