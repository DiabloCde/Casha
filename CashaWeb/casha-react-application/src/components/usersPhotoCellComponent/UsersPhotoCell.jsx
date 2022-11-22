import React from 'react'
import { useEffect, useState } from 'react'

function UsersPhotoCell(props) {
    const [imageUrl, setImageUrl] = useState("./img/AvatarIcon.png");

    function getImageUrl() {
        if (props.imageUrl) {
            setImageUrl(props.imageUrl);
        }
    }

    useEffect(() => {
        getImageUrl()
    },[]);

    return (
        <img src={imageUrl} alt="User Image" />
    )
}

export default UsersPhotoCell
