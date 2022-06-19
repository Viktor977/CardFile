import { Injectable } from '@angular/core';
import { Icons } from '../interfaces/icons';
import { SpaConfig } from '../interfaces/spaconfig';


@Injectable({
  providedIn: 'root'
})
export class SpaConfigService {

    constructor() { }
    showUserControls = true;

    socialIcons = new Array<Icons>();
    configure(settings: SpaConfig): void {
        Object.assign(this, settings);
    }
}

