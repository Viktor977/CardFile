import { Component, OnDestroy, OnInit } from '@angular/core';
import { User } from '../../../models/user';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit, OnDestroy {

    users!: User[]
    constructor(private userService: UserService) { }

    ngOnInit() {
        this.userService.getAllUsers().subscribe(
            ((users: User[]) => {
                this.users = users;
            }),
            ((err: any) => { console.log(err) })
        );
    }

    ngOnDestroy(): void {
        this.userService.getAllUsers();
    }
}
