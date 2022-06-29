import { Role } from "./models/role.enum";
import { MenuItems } from "./spa/interfaces/menuitems";

export const AppMenuItems: Array<MenuItems> = [
   
    {
        text: 'Home',
        icon: '../assets/home.png',
        role:Role.guest,
        route: '/home',      
    },
    {
        text: ' Users',
        icon: '../assets/users.svg',
        role:Role.regestered,
        route: '/auth/user',      
    },
    {
        text: 'Admin',
        icon: '../assets/admin.svg',
        role:Role.admin,
        route: '/auth/admin',      
    },

]