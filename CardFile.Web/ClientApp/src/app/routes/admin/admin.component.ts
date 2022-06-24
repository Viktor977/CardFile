import { Component, OnInit } from "@angular/core";
import { User } from "../../spa/interfaces/user";
import { UserService } from "src/app/spa/services/user.service";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css"],
})
export class AdminComponent implements OnInit {
  users: User[];
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }),
      (e: any) => {
        console.log(e);
      };
  }
}
