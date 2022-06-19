import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { SpaModule } from './spa/spa.module';

import { AuthenticatedComponent } from './routes/authenticated/authenticated.component';
import { HomeComponent } from './routes/home/home.component';
import { appRouters } from './routes/app-routes';
import { UserService } from './spa/services/user.service';
import { AuthGuard } from './spa/guards/auth.guard';
import { UserApi } from './spa/users/user-api';
import { AdminComponent } from './routes/admin/admin.component';
import { UserComponent } from './routes/user/user.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from "@angular/router";



@NgModule({
  declarations: [
    AppComponent,
    AuthenticatedComponent,
    HomeComponent,
    AdminComponent,
    UserComponent,
  
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    SpaModule,
    RouterModule.forRoot(appRouters)
  ],
    providers:
        [UserService,
            { provide: UserApi, useExisting: UserService }, AuthGuard
        ],
   
  bootstrap: [AppComponent]
})
export class AppModule { }
