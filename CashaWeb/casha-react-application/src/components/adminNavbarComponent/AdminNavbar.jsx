import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { Routes, Route, useNavigate } from 'react-router-dom';

import styles from './AdminNavbar.css';

function AdminNavbar() {
    const navigate = useNavigate();
    const [currentPage, setCurrentPage] = useState("/EditRecipes");
    //const [curretnAdminPanel, setCurrentAdminPanel] = useState("");
    const key = 'currentAdminPanel';
    const classColorName = 'choosen';
    var flag = false;

    useEffect(() => {
        if(!flag){
        setColor();
        flag = true;
        }
    }, [])

    async function setColor() {
        const currentAdminPanel = JSON.parse(localStorage.getItem('currentAdminPanel'));
        console.log(currentAdminPanel);

        if (currentAdminPanel == null) {
            const currentColorElement = document.getElementById('recipes_item');
            currentColorElement.classList.add(classColorName);
        }
        else {
            const previousElement = document.getElementsByClassName(classColorName);
            console.log(previousElement);
            if(previousElement.item(0)){
            previousElement.item(0).classList.remove(classColorName);
            }
            const currentColorElement = document.getElementById(currentAdminPanel);
            console.log(currentColorElement);
            currentColorElement.classList.add(classColorName);
        }
    }

    const usersClick = async (e) => {
        var elem = e.target.id;
        elem += '_item'
        console.log(elem)
        localStorage.setItem('currentAdminPanel', JSON.stringify(elem));
        navigate('/AdminViewUsers');
    }

    const ingredientsClick = async (e) => {
        var elem = e.target.id;
        elem += '_item'
        console.log(elem)
        localStorage.setItem('currentAdminPanel', JSON.stringify(elem));
        navigate('/');
    }

    const recipesClick = async (e) => {
        var elem = e.target.id;
        elem += '_item'
        console.log(elem)
        localStorage.setItem('currentAdminPanel', JSON.stringify(elem));
        navigate('/EditRecipes');
    }

    return (
        <nav className='menu'>
            <ul className='menu__list' id="demo">
                <li className='menu__item' id='recipes_item' onClick={recipesClick}>
                    <a href="#" className='menu__link' id='recipes'>
                        Recipes
                    </a>
                </li>
                <li className='menu__item' id='ingredients_item' onClick={ingredientsClick}>
                    <a href="#" className='menu__link' id='ingredients'>
                        Ingridients
                    </a>
                </li>
                <li className='menu__item' id='users_item' onClick={usersClick}>
                    <a href="#" className='menu__link' id='users'>
                        Users
                    </a>
                </li>
                <li className='menu__item' id='elementN'>
                    <a href="#" className='menu__link'>
                        ElementN
                    </a>
                </li>
            </ul>
        </nav>
    )
}

export default AdminNavbar
