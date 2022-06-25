import { MenuItems } from "./spa/interfaces/menuitems";

export const AppMenuItems: Array<MenuItems> = [
   
    {
        text: 'Home',
        icon: '../assets/home.png',
        route: '/auth/home',      
    },
    {
        text: ' Users',
        icon: '../assets/users.svg',
        route: '/auth/user',      
    },
    {
        text: 'Admin',
        icon: '../assets/admin.svg',
        route: '/auth/admin',      
    },

]