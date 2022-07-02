import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/spa/interfaces/user';
import { UserService } from 'src/app/spa/services/user.service';

@Component({
  selector: 'app-userinfo',
  templateUrl: './userinfo.component.html',
  styleUrls: ['./userinfo.component.css']
})
export class UserinfoComponent implements OnInit {
 
user:User
  constructor(private userService:UserService) { }

  ngOnInit() {
    let userId=JSON.parse(localStorage.getItem('id')).id;
    
    this.userService.getUserById(userId).subscribe((user:User)=>{this.user=user},(error:any)=>{console.log(error)});
  }

}
