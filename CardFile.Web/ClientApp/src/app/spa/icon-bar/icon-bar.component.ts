import { Component, Input, OnInit } from '@angular/core';
import { SpaConfigService } from '../services/spa-config.service';
import { UserApi } from '../users/user-api';

@Component({
  selector: 'app-icon-bar',
  templateUrl: './icon-bar.component.html',
  styleUrls: ['./icon-bar.component.css']
})
export class IconBarComponent implements OnInit {

    constructor(private spaConfigService: SpaConfigService, private userApi: UserApi) { }
    showLoader: boolean;
    @Input() showIcons;

    ngOnInit() {
        this.showLoader = false;
    }
    signOut() {
        this.showLoader = true;
        setTimeout(() => { this.userApi.signOut(); }, 2000);
        console.log('Sign out');
    }

}