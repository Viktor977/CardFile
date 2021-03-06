import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { UserService } from "../../services/user.service";
import { UserApi } from "../../../models/user-api";
import { tokenName } from "@angular/compiler";

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
            let map = new Map(Object.entries(data));
            let userName = map.get("firstName");
            let id = map.get("id");
            let role = map.get("role");
            let token=map.get('token');
            localStorage.setItem(
              "name",
              JSON.stringify({ username: userName })
            );
            localStorage.setItem("role", JSON.stringify({ role : role }));
            localStorage.setItem("id", JSON.stringify({ id : id }));
            localStorage.setItem('token',JSON.stringify({token : token}));
           
            this.router.navigate(["/auth/home"]);
          },

          (error) => {
            this.submitting = false;
            this.formError = error;
          }
        );
      this.userService.isAuthenticated = true;
    }
  }

  ngOnInit() {}
}
