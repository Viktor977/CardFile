import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from './header/header.component';
import { ContentComponent } from './content/content.component';
import { FooterComponent } from './footer/footer.component';
import { BodyComponent } from './body/body.component';
import { ScreenLargeDirective } from './directives/screen-large.directive';
import { ScreenSmallDirective } from './directives/screen-small.directive';
import { IconBarComponent } from './icon-bar/icon-bar.component';
import { MenuComponent } from '../spa/menus/menu/menu.component';
import { MenuItemComponent } from '../spa/menus/menu-item/menu-item.component';
import { RegistrationComponent } from './users/registration/registration.component';
import { SignInComponent } from './users/sign-in/sign-in.component';
import { ScreenService } from '../spa/services/screen.service';
import { MenuService } from './services/menu.service';
import { SpaConfigService } from './services/spa-config.service';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({

    declarations: [HeaderComponent,
        ContentComponent,
        BodyComponent,
        FooterComponent,
        HeaderComponent,
        ScreenLargeDirective,
        ScreenSmallDirective,
        IconBarComponent,
        MenuComponent,
        MenuItemComponent,
        RegistrationComponent,
        SignInComponent
    ],
    imports: [
        CommonModule, RouterModule, FormsModule
    ],
    providers: [SpaConfigService, ScreenService, MenuService],
    exports: [BodyComponent]


})
export class SpaModule { }
