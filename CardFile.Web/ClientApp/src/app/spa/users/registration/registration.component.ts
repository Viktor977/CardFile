import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthUserService } from 'src/app/appservices/authuser.service';
import { UserApi } from '../user-api';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  submitting = false;
  formError: string;
  constructor(
    private userApi: UserApi,
    private userService: AuthUserService,
    private router: Router
  ) { }

  onSubmit(signInForm: NgForm): void {
    if (signInForm.valid) {
      this.submitting = true;
      this.formError = null;
      this.userApi
        .signIn(signInForm.value.email, signInForm.value.password)
        .subscribe(
          (data) => {
            console.log(data);
            this.router.navigate(["/sign-in"]);
          },

          (error) => {
            this.submitting = false;
            this.formError = error;
          }
        );
    }
  }
  ngOnInit() {
  }

}
