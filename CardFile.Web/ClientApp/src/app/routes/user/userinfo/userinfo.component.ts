import { Location } from "@angular/common";
import { Component, Input, OnInit } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { CurrentUser } from "src/app/models/currentuser";
import { User } from "src/app/spa/interfaces/user";
import { UserService } from "src/app/spa/services/user.service";

@Component({
  selector: "app-userinfo",
  templateUrl: "./userinfo.component.html",
  styleUrls: ["./userinfo.component.css"],
})
export class UserinfoComponent implements OnInit {
  form: FormGroup;
  user: User;
  currentUser:CurrentUser;
  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private location: Location
  ) {}

  ngOnInit() {
    this.initForm();
    let userId = JSON.parse(localStorage.getItem("id")).id;

    this.userService.getUserById(userId).subscribe(
      (user: User) => {
        this.user = user;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  initForm(): void {
    this.form = this.fb.group({
      firstname: '',
      lastname: '',
      email: '',
      password:''
    });
  }
  back() {
    this.location.back();
  }
  onSubmit() {
    this.currentUser=new CurrentUser();
    this.currentUser.firstname=this.firstnameField.value;
    this.currentUser.email=this.emailField.value;
    this.currentUser.lastname=this.lastNameField.value;
    this.currentUser.password=this.passwordField.value;
    this.userService.upDate(this.currentUser).subscribe();
  }
  get firstnameField(){
    return this.form.get('firstname');
  }
  get lastNameField(){
    return this.form.get('lastname');
  }
  get passwordField(){
    return this.form.get('password');
  }
  get emailField(){
    return this.form.get('email');
  }
}
