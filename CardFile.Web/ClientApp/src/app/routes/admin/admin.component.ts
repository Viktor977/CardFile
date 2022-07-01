import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "src/app/spa/services/user.service";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.css"],
})
export class AdminComponent implements OnInit {

  isAdmin:boolean = false;
  constructor(private userService: UserService,private route:Router) {

  }

  ngOnInit(): void {
    let userRole=JSON.parse(localStorage.getItem("role")).role;
    console.log(userRole);
    if(userRole===2){
      this.isAdmin=true;;
    }
    
  }
  showUsersList(){
this.route.navigate(['/auth/userslist'])
  }
}
