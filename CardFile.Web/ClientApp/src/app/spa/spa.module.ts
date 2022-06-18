import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
<<<<<<< HEAD
import { HeaderComponent } from './header/header.component';
import { ContentComponent } from './content/content.component';
import { FooterComponent } from './footer/footer.component';
import { BodyComponent } from './body/body.component';
import { ScreenLargeDirective } from './directives/screen-large.directive';
import { ScreenSmallDirective } from './directives/screen-small.directive';
import { IconBarComponent } from './icon-bar/icon-bar.component';
import { MenuComponent } from './menu/menu/menu.component';
import { MenuItemComponent } from './menu/menu-item/menu-item.component';
import { RegistrationComponent } from './users/registration/registration.component';
import { SignInComponent } from './users/sign-in/sign-in.component';
import { ScreenService } from '../spa/services/screen.service';
import { MenuService } from './services/menu.service';
import { SpaConfigService } from './services/spa-config.service';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
=======
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

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f



@NgModule({
<<<<<<< HEAD
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

=======
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
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
})
export class SpaModule { }
