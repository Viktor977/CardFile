import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { User } from '../interfaces/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient){}
  users: User[];
  getUsers(): Observable<User[]> {
    
    return this.http
      .get<User[]>(`${environment.apiUrl}/User`);
      //.pipe(map((users) => this.users));
  }
  getUserById(id: number) {
    return this.http.get<User>(`${environment.apiUrl}/User/${id}`);
  }
}
