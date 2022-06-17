import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { UserService } from '../../services/user.service';
import { UserApi } from '../user-api';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

    submitting = false;
    formError: string;
    constructor(private userApi: UserApi, private userService: UserService, private router: Router) { }

    onSubmit(signInForm: NgForm): void {
        if (signInForm.valid) {
            this.submitting = true;
            this.formError = null;
            this.userApi.signIn(signInForm.value.email, signInForm.value.password).subscribe((data) => {
                console.log(data);
                this.router.navigate(['/authenticated']);
            },
            (error) => {
                this.submitting = false;
                this.formError = error;
            });
        }
    }

  ngOnInit() {
  }

}
