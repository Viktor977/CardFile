import { Routes } from '@angular/router';
import { HomeComponent } from "../routes/home/home.component";
import { CardComponent } from "../routes/card/card.component";
import { AuthenticatedComponent } from './authenticated/authenticated.component';
import { SignInComponent } from '../spa/users/sign-in/sign-in.component';
import { RegistrationComponent } from '../spa/users/registration/registration.component';
import { AuthGuard } from '../spa/services/auth-guard.service';

export const appRouters: Routes = [
    
        { path: 'sign-in', component: SignInComponent },
    { path: 'register', component: RegistrationComponent },
    {
        path: 'authenticated', component: AuthenticatedComponent, canActivate: [AuthGuard], children: [
            {
                path: '', canActivateChild: [AuthGuard], children: [

                   { path: 'home', component: HomeComponent },
                    { path: 'card', component: CardComponent },
                ]
            }
            
        ]},      
       { path: '', redirectTo: 'sign-in', pathMatch: 'full' },
       { path: '**', component: SignInComponent }
]