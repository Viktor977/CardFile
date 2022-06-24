import { Injectable } from "@angular/core";
import { CanActivate, CanActivateChild, Router } from "@angular/router";
import { AuthUserService } from "../appservices/authuser.service";


@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate, CanActivateChild {
  constructor(private router: Router, private userService: AuthUserService) {}
  canActivate(): boolean {
    if (!this.userService.isAuthenticated) {
      this.router.navigate(["/sign-in"]);
    }
    return this.userService.isAuthenticated;
  }
  canActivateChild(): boolean {
    return this.canActivate();
  }
}