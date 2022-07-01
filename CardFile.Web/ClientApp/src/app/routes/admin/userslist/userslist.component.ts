import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/spa/interfaces/user';
import { UserService } from 'src/app/spa/services/user.service';

@Component({
  selector: 'app-userslist',
  templateUrl: './userslist.component.html',
  styleUrls: ['./userslist.component.css']
})
export class UserslistComponent implements OnInit {

  users:User[];
  constructor(private userService:UserService) { }

  ngOnInit() {
    return this.userService.getUsers().subscribe((users:User[])=>this.users=users);
  }

}
