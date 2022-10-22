import React from 'react'

import styles from './AdminNavbar.css';

function AdminNavbar() {
    return (
        <nav className='menu'>
            <ul className='menu__list'>
                <li className='menu__item choosen'>
                    <a href ="#" className='menu__link'>
                        Recipes
                    </a>
                </li>
                <li className='menu__item'>
                    <a href ="#" className='menu__link'>
                        Ingridients
                    </a>
                </li>
                <li className='menu__item'>
                    <a href ="#" className='menu__link'>
                        Users
                    </a>
                </li>
                <li className='menu__item'>
                    <a href ="#" className='menu__link'>
                        ElementN
                    </a>
                </li>
            </ul>
        </nav>
    )
}

export default AdminNavbar
