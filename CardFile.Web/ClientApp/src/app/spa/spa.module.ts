import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { HeaderComponent } from "./header/header.component";
import { ContentComponent } from "./content/content.component";
import { FooterComponent } from "./footer/footer.component";
import { BodyComponent } from "./body/body.component";
import { ScreenLargeDirective } from "./directives/screen-large.directive";
import { ScreenSmallDirective } from "./directives/screen-small.directive";
import { IconBarComponent } from "./icon-bar/icon-bar.component";
import { MenuComponent } from "../spa/menus/menu/menu.component";
import { MenuItemComponent } from "../spa/menus/menu-item/menu-item.component";
import { SpaConfigService } from "./services/spa-config.service";
import { MenuService } from "./services/menu.service";
import { ScreenService } from "./services/screen.service";
import { CardService } from "./services/card.service";
import { HomeComponent } from "../routes/home/home.component";
import { UserComponent } from "../routes/user/user.component";
import { AdminComponent } from "../routes/admin/admin.component";
import{SignInComponent} from '../spa/users/sign-in/sign-in.component'
import { RegistrationComponent } from "./users/registration/registration.component";
import { UserService } from "./services/user.service";
import { UserslistComponent } from "../routes/admin/userslist/userslist.component";
import { RolePipe } from "../pipes/role.pipe";
import { ReactionPipe } from "../pipes/reaction.pipe";
import { UserinfoComponent } from "../routes/user/userinfo/userinfo.component";

@NgModule({
  declarations: [
    HeaderComponent,
    BodyComponent,
    ContentComponent,
    FooterComponent,
    MenuComponent,
    MenuItemComponent,
    IconBarComponent,
    ScreenLargeDirective,
    ScreenSmallDirective,
    SignInComponent,
    RegistrationComponent,
    HomeComponent,
    UserComponent,
    AdminComponent,
    UserinfoComponent,
    UserslistComponent,RolePipe,ReactionPipe
  
  ],
  imports: [FormsModule,ReactiveFormsModule, RouterModule, CommonModule],
  providers: [SpaConfigService, MenuService, ScreenService, CardService,UserService],
  exports: [BodyComponent],
})
export class SpaModule {}
