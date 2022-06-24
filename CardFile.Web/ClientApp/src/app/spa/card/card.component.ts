import { Component, OnInit, Input } from "@angular/core";
import { CardService } from "../services/card.service";
import { Card } from "../interfaces/card";
import { User } from "../../models/user";
import { AuthUserService } from "src/app/appservices/authuser.service";
import { Role } from "src/app/models/role.enum";

@Component({
  selector: "app-card",
  templateUrl: "./card.component.html",
  styleUrls: ["./card.component.css"],
})
export class CardComponent implements OnInit {
  
  @Input() card: Card;
 
 
  constructor(private cardServise: CardService,private authService:AuthUserService) {
   
 
  }
  public user:User;

  ngOnInit(): void {
 
    this.user=this.authService.getCurrentUser();
   
  }

  handleLikedText(event: Event, id: number) {
    this.card.id = id;
    this.cardServise.like(this.card.id);
  }
}
