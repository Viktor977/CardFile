import { MenuItems } from "./spa/interfaces/menuitems";

export const AppMenuItems: Array<MenuItems> = [
   
    {
        text: 'Home',
        icon: '../assets/home.png',
        route: '/auth/home',
        submenu: null
    },
    {
        text: ' Users',
        icon: '../assets/users.svg',
        route: '/auth/user',
        submenu: null
    },
    {
        text: 'Admin',
        icon: '../assets/admin.svg',
        route: '/auth/admin',
        submenu: null
    },

]