import { Component, OnInit } from "@angular/core";
import { User } from "../../spa/interfaces/user";
import { UserService } from "src/app/spa/services/user.service";
import { Role } from "src/app/models/role.enum";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css"],
})
export class AdminComponent implements OnInit {
  users: User[];
  isAdmin:boolean;
  constructor(private userService: UserService) {

  }

  ngOnInit(): void {
    let userRole=JSON.parse(localStorage.getItem("role")).role;
    console.log(userRole);
    if(userRole===2){
      this.isAdmin=true;;
    }
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }),
      (e: any) => {
        console.log(e);
      };
  }
}
