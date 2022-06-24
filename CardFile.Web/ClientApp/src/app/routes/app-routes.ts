import { Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AuthenticatedComponent } from './authenticated/authenticated.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';

export const appRouters: Routes = [
  { path: "home", component: HomeComponent },  
  {
    path: 'auth',
    component: AuthenticatedComponent,
    children: [
     {path:'home',component:HomeComponent},
      { path: "user", component: UserComponent },
      { path: "admin", component: AdminComponent },
    ],
  },
  { path: '', redirectTo: "home", pathMatch: "full" },
  {path:'**',component:HomeComponent},
];