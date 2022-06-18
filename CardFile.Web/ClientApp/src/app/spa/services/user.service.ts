import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
<<<<<<< HEAD
import { Observable, of, throwError } from 'rxjs';
import { delay } from 'rxjs/operators';

=======
import { UserApi } from '../../spa/users/user-api';
import { Observable, of, throwError } from 'rxjs';
import { delay } from 'rxjs/operators';


>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
@Injectable({
  providedIn: 'root'
})
export class UserService {

<<<<<<< HEAD

=======
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
    isAuthenticated = false;

    constructor(private router: Router) { }

    signIn(email: string, password: string): Observable<any> {
        if (email === 'test@gmail.com' && password === '123') {
            this.isAuthenticated = true;
            return of({}).pipe(delay(2000));
        } else { return throwError('Invalid email or password'); }
    }
    signOut(): Observable<any> {
        this.isAuthenticated = false;
        this.router.navigate(['/sign-in']);
        return of({});
    }
}
