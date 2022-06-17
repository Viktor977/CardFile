export interface MenuItems {
    text: string;
    icon: string;
    route: string;
    submenu: Array<MenuItems>;
}
