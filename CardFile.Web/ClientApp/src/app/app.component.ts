import { Component } from '@angular/core';

import { SpaConfigService, SpaConfigSettings } from '../app/spa/services/spa-config.service';
import { AppMenuItems } from './app.menu';
import { MenuService } from './spa/services/menu.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
    constructor(private spaConfigService: SpaConfigService,private menuService:MenuService) {
        const config: SpaConfigSettings = {
            socialIcons: [
                { imageFile: '../assets/IMG/facebook.png', alt: 'Facebook', url: 'http://facebook.com' },
                { imageFile: '../assets/IMG/instagram.png', alt: 'Instargram', url: 'http://www.instagram.com' },
                { imageFile: '../assets/IMG/facebook.png', alt: 'Twitter', url: 'http://twitter.com' },
                { imageFile: '../assets/IMG/facebook.png', alt: 'WhatsApp', url: 'http://www.whatsapp.com' },
            ],
            showUserControls: true
        };
        spaConfigService.configure(config);
        menuService.items = AppMenuItems;
    }
}
