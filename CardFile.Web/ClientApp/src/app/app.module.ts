import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SpaModule } from './spa/spa.module';
import { HomeComponent } from './routes/home/home.component';
import { CardComponent } from './routes/card/card.component';
import { RouterModule } from '@angular/router';
import { appRouters } from './routes/app.routes';
import { AuthenticatedComponent } from './routes/authenticated/authenticated.component';
import { UserService } from './spa/services/user.service';
import { UserApi } from './spa/users/user-api';
import { AuthGuard } from './spa/services/auth-guard.service';



@NgModule({
  declarations: [
    AppComponent,
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
  bootstrap: [AppComponent]
})
export class AppModule { }
