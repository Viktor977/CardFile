import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UserApi } from '../../../models/user-api';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registering = false;
  hasAdded = false;

  constructor(private router: Router, private userApi: UserApi) { }
  onSubmit(registerForm: NgForm) {
    this.registering = true;
    this.userApi.registerUser(registerForm.value).subscribe(() => {
      setTimeout(() => {this.hasAdded = true; }, 1200);
      setTimeout(() => {this.router.navigate(['/sign-in']); }, 2000);
    });
  }
  ngOnInit() {
  }
}
