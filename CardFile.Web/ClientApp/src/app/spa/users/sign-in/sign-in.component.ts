import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
=======
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
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
<<<<<<< HEAD
                (error) => {
                    this.submitting = false;
                    this.formError = error;
                });
        }
    }


=======
            (error) => {
                this.submitting = false;
                this.formError = error;
            });
        }
    }

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
  ngOnInit() {
  }

}
