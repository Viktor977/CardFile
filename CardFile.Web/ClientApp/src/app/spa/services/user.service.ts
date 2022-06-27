import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { Router } from "@angular/router";

import { User } from "../interfaces/user";
import {  AuthUser } from "src/app/models/authuser";
import { environment } from "src/environments/environment";
import { UserApi } from "src/app/models/user-api";
import { UserForRegistration } from "src/app/models/userforregistration";

@Injectable({
  providedIn: "root",
})
export class UserService implements UserApi {
  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };
  isAuthenticated = false;
  constructor(private http: HttpClient, private router: Router) {}
  users: User[];
  user: AuthUser;
  registretion: UserForRegistration;
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/User`);
  }
  getUserById(id: number) {
    return this.http.get<User>(`${environment.apiUrl}/User/${id}`);
  }
  signIn(email: string, password: string): Observable<any> {
    this.user = new AuthUser(password, email);
    let response= this.http.post(
      `${environment.apiUrl}/Authentication`,
      this.user,
      this.httpOptions
    );  
    return response;
  }

  signOut(): Observable<any> {
    this.isAuthenticated = false;
    localStorage.clear();
    this.router.navigate(["/sign-in"]);
    return of({});
  }
  registerUser(registerForm: User) {
    this.registretion = new UserForRegistration(
      registerForm.password,
      registerForm.email,
      registerForm.fname,
      registerForm.lname
    );
    return this.http.post(
      `${environment.apiUrl}/Authentication/create`,
      this.registretion,
      this.httpOptions
    );
  }
}
