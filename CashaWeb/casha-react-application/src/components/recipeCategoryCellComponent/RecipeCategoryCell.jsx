import React from 'react'

function RecipeCategoryCell(props) {
    return (
        <table>
            {props.categories.map((item) => (
                <tr key={item.categoryId}>
                    <td>
                        {item.categoryName}
                    </td>
                </tr>
            ))}

        </table>
    )
}

export default RecipeCategoryCell
