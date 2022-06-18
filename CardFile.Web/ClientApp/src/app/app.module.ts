import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SpaModule } from './spa/spa.module';
<<<<<<< HEAD
import { AuthenticatedComponent } from './routes/authenticated/authenticated.component';
import { HomeComponent } from './routes/home/home.component';
import { appRouters } from './routes/app-routes';
import { UserService } from './spa/services/user.service';
import { AuthGuard } from './spa/guards/auth.guard';
import { UserApi } from './spa/users/user-api';
import { AdminComponent } from './routes/admin/admin.component';
import { UserComponent } from './routes/user/user.component';
=======
import { HomeComponent } from './routes/home/home.component';
import { CardComponent } from './routes/card/card.component';
import { RouterModule } from '@angular/router';
import { appRouters } from './routes/app.routes';
import { AuthenticatedComponent } from './routes/authenticated/authenticated.component';
import { UserService } from './spa/services/user.service';
import { UserApi } from './spa/users/user-api';
import { AuthGuard } from './spa/services/auth-guard.service';
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f



@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
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
=======
    HomeComponent,
    CardComponent,
    AuthenticatedComponent,
   
  ],
  imports: [
     // BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      BrowserModule,
      HttpClientModule,
      SpaModule,
      RouterModule.forRoot(appRouters)
   
    ],
    providers:
        [UserService,
            { provide: UserApi, useExisting: UserService }, AuthGuard
    ],
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
  bootstrap: [AppComponent]
})
export class AppModule { }
