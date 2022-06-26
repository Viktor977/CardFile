import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { UserService } from "../../services/user.service"; 
import { UserApi } from "../../../models/user-api";

@Component({
  selector: "app-sign-in",
  templateUrl: "./sign-in.component.html",
  styleUrls: ["./sign-in.component.css"],
})
export class SignInComponent implements OnInit {
  submitting = false;
  formError: string;
  constructor(
    private userApi: UserApi,
    private userService: UserService,
    private router: Router
  ) {}

  onSubmit(signInForm: NgForm): void {
    if (signInForm.valid) {
      this.submitting = true;
      this.formError = null;
      this.userApi
        .signIn(signInForm.value.email, signInForm.value.password)
        .subscribe(
          (data) => {
            console.log(data);
            this.router.navigate(["/auth/home"]);
          },

          (error) => {
            this.submitting = false;
            this.formError = error;
          }
        );
        this.userService.isAuthenticated=true;
        localStorage.setItem('user',JSON.stringify({"name":signInForm.value.password}));
    }
  }

  ngOnInit() {}
}
