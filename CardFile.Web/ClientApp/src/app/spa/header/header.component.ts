import { Component, OnInit } from "@angular/core";
import { MenuService } from "../services/menu.service";
import { ScreenService } from "../services/screen.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"],
})
export class HeaderComponent implements OnInit {
  flagForIcons = true;
  constructor(
    private screenService: ScreenService,
    private menuService: MenuService
  ) {}

  ngOnInit() {}
}
