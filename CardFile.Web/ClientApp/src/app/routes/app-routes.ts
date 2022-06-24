import { Routes } from "@angular/router";
import { AuthGuard } from "../guards/auth.guard";
import { GreetingsComponent } from "../spa/greetings/greetings.component";
import { RegistrationComponent } from "../spa/users/registration/registration.component";
import { SignInComponent } from "../spa/users/sign-in/sign-in.component";
import { AdminComponent } from "./admin/admin.component";
import { AuthenticatedComponent } from "./authenticated/authenticated.component";
import { HomeComponent } from "./home/home.component";
import { UserComponent } from "./user/user.component";

export const appRouters: Routes = [
  { path: "sign-in", component: SignInComponent },
  { path: "register", component: RegistrationComponent },
  {
    path: "auth",
    component: AuthenticatedComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "",
        canActivateChild: [AuthGuard],
        children: [
          { path: "home", component: HomeComponent },
          { path: "user", component: UserComponent },
          { path: "admin", component: AdminComponent},
        ],
      },
    ],
  },
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "**", component: GreetingsComponent },
];
