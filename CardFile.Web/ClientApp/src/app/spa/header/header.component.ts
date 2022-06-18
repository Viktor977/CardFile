import { Component, OnInit } from '@angular/core';
import { MenuService } from '../services/menu.service';
import { ScreenService } from '../services/screen.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
<<<<<<< HEAD

    flagForIcons = true;
    constructor(private screenService: ScreenService, private menuService: MenuService) { }
=======
    flagForIcons = true;
    constructor(private screenService: ScreenService, private menuService: MenuService) { }

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
  ngOnInit() {
  }

}
