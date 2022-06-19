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

]