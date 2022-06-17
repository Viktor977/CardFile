import { Injectable } from '@angular/core';
import { Icons } from '../interfaces/icons';

@Injectable({
  providedIn: 'root'
})
export class SpaConfigService {

    constructor() { }
    showUserControls = true;
    socialIcons = new Array<Icons>();
    configure(settings: SpaConfigSettings): void {
        Object.assign(this, settings);
    }
}


export interface SpaConfigSettings {
    showUserControls?: boolean;
    socialIcons?: Array<Icons>;
}

