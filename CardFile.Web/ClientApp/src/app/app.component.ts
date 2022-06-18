import { Component } from '@angular/core';
import { AppMenuItems } from './app.menu';
import { SpaConfig } from './spa/interfaces/spaconfig';
import { MenuService } from './spa/services/menu.service';
import { SpaConfigService } from './spa/services/spa-config.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
    constructor(private spaConfigService: SpaConfigService, private menuService: MenuService) {
        const config: SpaConfig = {
            socialIcons: [
                { imageFile: "../assets/facebook.png", alt: 'Facebook', url: 'http://facebook.com' },
                { imageFile: '../assets/instagram.png', alt: 'Instargram', url: 'http://www.instagram.com' },
                { imageFile: '../assets/twitter.png', alt: 'Twitter', url: 'http://twitter.com' },
                { imageFile: '../assets/whatsapp.png', alt: 'WhatsApp', url: 'http://www.whatsapp.com' },
            ],
            showUserControls: true
        };
        spaConfigService.configure(config);
        menuService.items = AppMenuItems;
    }

}
