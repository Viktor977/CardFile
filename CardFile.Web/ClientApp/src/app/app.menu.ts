import { MenuItems } from '../app/spa/interfaces/menuitems';

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
]