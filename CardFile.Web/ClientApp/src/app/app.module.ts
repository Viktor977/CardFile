import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {  HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SpaModule } from './spa/spa.module';
import { AuthenticatedComponent } from './routes/authenticated/authenticated.component';
import { appRouters } from './routes/app-routes';
import { UserService } from './spa/services/user.service';
import { AuthGuard } from './guards/auth.guard';
import { UserApi } from './models/user-api';
import { FormsModule } from '@angular/forms';
import { RouterModule } from "@angular/router";





@NgModule({
  declarations: [AppComponent, AuthenticatedComponent, ],
  exports: [],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    SpaModule,
    RouterModule.forRoot(appRouters),
  ],
  providers: [
    UserService,
    { provide: UserApi, useExisting: UserService },
    AuthGuard,
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
