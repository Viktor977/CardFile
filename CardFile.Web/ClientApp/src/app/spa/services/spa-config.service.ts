import { Injectable } from '@angular/core';
import { Icon } from '../interfaces/icon';
import { SpaConfig } from '../interfaces/spaconfig';

@Injectable({
  providedIn: 'root'
})
export class SpaConfigService {

    constructor() { }
    showUserControls = true;
    socialIcons = new Array<Icon>();
    configure(settings: SpaConfig): void {
        Object.assign(this, settings);
    }
}
