import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { BodyComponent } from './body/body.component';
import { HeaderComponent } from './header/header.component';
import { ContentComponent } from './content/content.component';
import { FooterComponent } from './footer/footer.component';
import { IconBarComponent } from './icon-bar/icon-bar.component';
import { SpaConfigService } from './services/spa-config.service';
import { ScreenService } from './services/screen.service';
import { ScreenLargeDirective } from './directives/screen-large.directive';
import { ScreenSmallDirective } from './directives/screen-small.directive';
import { MenuComponent } from './menus/menu/menu.component';
import { MenuItemComponent } from './menus/menu-item/menu-item.component';
import { RouterModule } from '@angular/router';
import { MenuService } from './services/menu.service';
import { SignInComponent } from './users/sign-in/sign-in.component';
import { RegistrationComponent } from './users/registration/registration.component';




@NgModule({
    declarations: [
       
        BodyComponent,
        HeaderComponent,
        ContentComponent,
        FooterComponent,
        IconBarComponent,
        ScreenLargeDirective,
        ScreenSmallDirective,
        MenuComponent,
        MenuItemComponent,
        SignInComponent,
        RegistrationComponent,
        ],
    imports: [ FormsModule,
        CommonModule, RouterModule,
    ],
    exports: [BodyComponent],
    providers: [SpaConfigService, ScreenService, MenuService]
})
export class SpaModule { }
