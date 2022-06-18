import { Injectable } from '@angular/core';
import { MenuItems } from '../interfaces/menuitems';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

    constructor() { }
    items: Array<MenuItems>;
    isVertical = false;
    showVerticalMenu = false;
    toggleMenu(): void {
        this.isVertical = true;
        this.showVerticalMenu = !this.showVerticalMenu;
    }
}
<<<<<<< HEAD
=======


>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
