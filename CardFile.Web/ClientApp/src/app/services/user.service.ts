import { Injectable,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})



export class UserService {

    public url: string;
    public users: User[];

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl;
    }


    getAllUsers() {

        return this.http.get<User[]>(this.url + 'api/User');      
    }
}
