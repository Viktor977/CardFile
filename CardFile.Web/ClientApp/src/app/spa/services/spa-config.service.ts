import { Injectable } from '@angular/core';
<<<<<<< HEAD
import { Icon } from '../interfaces/icon';
import { SpaConfig } from '../interfaces/spaconfig';
=======
import { Icons } from '../interfaces/icons';
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f

@Injectable({
  providedIn: 'root'
})
export class SpaConfigService {

    constructor() { }
    showUserControls = true;
<<<<<<< HEAD
    socialIcons = new Array<Icon>();
    configure(settings: SpaConfig): void {
        Object.assign(this, settings);
    }
}
=======
    socialIcons = new Array<Icons>();
    configure(settings: SpaConfigSettings): void {
        Object.assign(this, settings);
    }
}


export interface SpaConfigSettings {
    showUserControls?: boolean;
    socialIcons?: Array<Icons>;
}

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
