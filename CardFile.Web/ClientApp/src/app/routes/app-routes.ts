
import { Routes } from '@angular/router';
import { RegistrationComponent } from "../spa/users/registration/registration.component";
import { SignInComponent } from "../spa/users/sign-in/sign-in.component";
import { AuthenticatedComponent } from "./authenticated/authenticated.component";
import { HomeComponent } from "./home/home.component";
import { AuthGuard } from '../spa/guards/auth.guard';
import { AdminComponent } from './admin/admin.component';
import { UserComponent } from './user/user.component';

export const appRouters: Routes = [

    { path: 'sign-in', component: SignInComponent },
    { path: 'register', component: RegistrationComponent },
    {
        path: 'authenticated', component: AuthenticatedComponent, canActivate: [AuthGuard], children: [
            {
                path: '', canActivateChild: [AuthGuard], children: [

                    { path: 'home', component: HomeComponent },
                    { path: 'user', component: UserComponent },               
                    { path: 'admin', component: AdminComponent }
                ]
            }

        ]
    },
    { path: '', redirectTo: 'authenticated', pathMatch: 'full' },
    { path: '**', component: HomeComponent }
]