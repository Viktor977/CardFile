import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Card } from "../../spa/interfaces/card";
import { CardService } from "../../spa/services/card.service";
import { CardModel } from "src/app/models/cardmodel";

@Component({
  selector: "app-user",
  templateUrl: "./user.component.html",
  styleUrls: ["./user.component.css"],
})
export class UserComponent implements OnInit {
  

  @Output()
  onLikePost = new EventEmitter<Card>();
  selectedcard: Card[];
  @Input()
  cards: Card[];
  @Input()
  card: Card;
  searchtitle = "";
  comment:string;
  constructor(private cardService: CardService) {}

  ngOnInit(): void {
   
  }

  searByTitle(){
    console.log(this.searchtitle);
     return this.cardService.search(this.searchtitle).subscribe((cards:Card)=>{
      this.card=cards;
      console.log(this.card);
      
    },(e:any)=>{console.log(e)});
    }
 
  handleLikedText(event: Event, id: number) {
    this.card.id = id;
    this.cardService.addLike(this.card.id,'');
  }
}
