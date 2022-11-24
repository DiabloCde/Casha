import React from 'react'
import { useEffect, useState } from 'react'

function RecipeComplexityCell(props) {
    const [complexity, setComplexty] = useState("");

    function getComplexity() {
        if(props.complexity == 0){
            setComplexty("Easy");
            return;
        }
        if(props.complexity == 1){
            setComplexty("Medium");
            return;
        }
        if(props.complexity == 2){
            setComplexty("Hard");
            return;
        }
    }

    useEffect(() => {
        getComplexity();
    }, []);

    
    return (
       <p>{complexity}</p>
    )
}

export default RecipeComplexityCell
