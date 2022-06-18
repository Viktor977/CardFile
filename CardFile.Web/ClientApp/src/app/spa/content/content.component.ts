import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD:CardFile.Web/ClientApp/src/app/spa/content/content.component.ts
import { MenuService } from '../services/menu.service';
import { ScreenService } from '../services/screen.service';
=======
import { ScreenService } from '../services/screen.service';
import { MenuService } from '../services/menu.service';
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f:CardFile.Web/ClientApp/src/app/components/public/content/content.component.ts

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {

    constructor(private screenService: ScreenService, private menuService: MenuService) { }

  ngOnInit() {
  }

}
