import { Injectable } from "@angular/core";
import { Role } from "src/app/models/role.enum";
import { MenuItems } from "../interfaces/menuitems";

@Injectable({
  providedIn: "root",
})
export class MenuService {
  constructor() {}
  role:Role;
  items: Array<MenuItems>;
  isVertical = false;
  showVerticalMenu = false;

  toggleMenu(): void {
    this.isVertical = true;
    this.showVerticalMenu = !this.showVerticalMenu;
  }

  toggleOrientation(): void {
    this.isVertical = !this.isVertical;
  }
}
