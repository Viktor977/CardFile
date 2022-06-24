import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable, of, throwError } from "rxjs";
import { delay, map } from "rxjs/operators";

import { User } from "../interfaces/user";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class UserService {
  isAuthenticated = false;
  users: User[];
  user: User;
  constructor(private router: Router, private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http
      .get<User[]>(`${environment.apiUrlTwo}/User`);
      //.pipe(map((users) => this.users));
  }

  getUserById(id: number) {
    return this.http.get<User>(`${environment.apiUrl}/User/${id}`);
  }

  signIn(email: string, password: string): Observable<any> {
    if (email === "test@gmail.com" && password === "123") {
      this.isAuthenticated = true;
      return of({}).pipe(delay(2000));
    } else {
      return throwError("Invalid email or password");
    }
  }
  signOut(): Observable<any> {
    this.isAuthenticated = false;
    this.router.navigate(["/sign-in"]);
    return of({});
  }
}
