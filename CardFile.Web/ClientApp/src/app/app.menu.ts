<<<<<<< HEAD
import { MenuItems } from "./spa/interfaces/menuitems";

export const AppMenuItems: Array<MenuItems> = [
   
    {
        text: 'Home',
        icon: '../assets/home.png',
        route: '/authenticated/home',
        submenu: null
    },
    {
        text: 'Regestered Users',
        icon: '../assets/users.svg',
        route: '/authenticated/user',
        submenu: null
    },
    {
        text: 'Administrator',
        icon: '../assets/admin.svg',
        route: '/authenticated/admin',
        submenu: null
    },

=======
﻿import { MenuItems } from '../app/spa/interfaces/menuitems';

export const AppMenuItems: Array<MenuItems> = [
    {
        text: 'Cars',
        icon: '../assets/IMG/car.png',
        route: '/authenticated/card',
        submenu: null
    },
    {
        text: 'Maintenance',
        icon: '../assets/IMG/settings.png',
        route: '/authenticated/settings',
        submenu: null
    },
    {
        text: 'Home',
        icon: '../assets/IMG/home.png',
        route: '/authenticated/home',
        submenu: null
    },
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
]