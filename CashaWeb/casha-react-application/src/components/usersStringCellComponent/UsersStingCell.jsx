import React from 'react'
import { useEffect, useState } from 'react'

function UsersStingCell(props) {
    const [visualString, setVisualString] = useState("Not Entered");

    function getCellString() {
        if (props.cellValue) {
            setVisualString(props.cellValue);
        }
    }

    useEffect(() => {
        getCellString()
    },[]);

    return (
        <p>{visualString}</p>
    )
}

export default UsersStingCell
