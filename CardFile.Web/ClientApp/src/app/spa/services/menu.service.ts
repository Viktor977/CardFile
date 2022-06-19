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





