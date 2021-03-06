import { Component, Input, OnInit } from "@angular/core";
import { MenuItems } from "../../interfaces/menuitems";
import { MenuService } from "../../services/menu.service";

@Component({
  selector: "app-menu-item",
  templateUrl: "./menu-item.component.html",
  styleUrls: ["./menu-item.component.css"],
})
export class MenuItemComponent implements OnInit {
  
  @Input() item: MenuItems;
  constructor(private menuService: MenuService) {}

  ngOnInit() {
   
  }
}
