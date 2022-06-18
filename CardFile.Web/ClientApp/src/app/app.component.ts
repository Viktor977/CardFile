import { Component } from '@angular/core';
import { AppMenuItems } from './app.menu';
import { SpaConfig } from './spa/interfaces/spaconfig';
import { MenuService } from './spa/services/menu.service';
import { SpaConfigService } from './spa/services/spa-config.service';

import { SpaConfigService, SpaConfigSettings } from '../app/spa/services/spa-config.service';
import { AppMenuItems } from './app.menu';
import { MenuService } from './spa/services/menu.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
<<<<<<< HEAD
    constructor(private spaConfigService: SpaConfigService, private menuService: MenuService) {
        const config: SpaConfig = {
            socialIcons: [
                { imageFile: "../assets/facebook.png", alt: 'Facebook', url: 'http://facebook.com' },
                { imageFile: '../assets/instagram.png', alt: 'Instargram', url: 'http://www.instagram.com' },
                { imageFile: '../assets/twitter.png', alt: 'Twitter', url: 'http://twitter.com' },
                { imageFile: '../assets/whatsapp.png', alt: 'WhatsApp', url: 'http://www.whatsapp.com' },
=======
    constructor(private spaConfigService: SpaConfigService,private menuService:MenuService) {
        const config: SpaConfigSettings = {
            socialIcons: [
                { imageFile: '../assets/IMG/facebook.png', alt: 'Facebook', url: 'http://facebook.com' },
                { imageFile: '../assets/IMG/instagram.png', alt: 'Instargram', url: 'http://www.instagram.com' },
                { imageFile: '../assets/IMG/facebook.png', alt: 'Twitter', url: 'http://twitter.com' },
                { imageFile: '../assets/IMG/facebook.png', alt: 'WhatsApp', url: 'http://www.whatsapp.com' },
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
            ],
            showUserControls: true
        };
        spaConfigService.configure(config);
        menuService.items = AppMenuItems;
    }
<<<<<<< HEAD

=======
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
}
