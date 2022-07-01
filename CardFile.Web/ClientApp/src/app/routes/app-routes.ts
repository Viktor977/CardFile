import { Routes } from "@angular/router";
import { AuthGuard } from "../guards/auth.guard";
import { RegistrationComponent } from "../spa/users/registration/registration.component";
import { SignInComponent } from "../spa/users/sign-in/sign-in.component";
import { AdminComponent } from "./admin/admin.component";
import { UserslistComponent } from "./admin/userslist/userslist.component";
import { AuthenticatedComponent } from "./authenticated/authenticated.component";
import { HomeComponent } from "./home/home.component";
import { UserComponent } from "./user/user.component";
import { UserinfoComponent } from "./user/userinfo/userinfo.component";

export const appRouters: Routes = [
  {path:'home',component: HomeComponent},
  { path: "sign-in", component: SignInComponent },
  { path: "register", component: RegistrationComponent },
  {
    path: "auth",
    component: AuthenticatedComponent, 
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        canActivateChild: [AuthGuard],
        children: [         
          { path: 'user', component: UserComponent },
          { path: 'admin', component: AdminComponent},
          {path:'userslist',component:UserslistComponent},
          {path:'userinfo',component:UserinfoComponent}
        ],
      },
    ],
  },
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "**", component: HomeComponent },
];
