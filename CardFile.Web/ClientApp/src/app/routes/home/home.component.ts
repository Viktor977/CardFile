import { Component, Input, OnInit} from "@angular/core";
import { Card } from "../../spa/interfaces/card";
import { CardService } from "../../spa/services/card.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  
  cards:Card[];
  private _cardList:Card[];
  searchtitle:string;
 
  constructor(private cardService: CardService) {}

  ngOnInit(): void {
    this.cardService.getCards().subscribe((cards: Card[]) => {
      this.cards = cards;
    }),
      (e: any) => {
        console.log(e);
      };
  }
  search(){
    if(this.searchtitle.length === 0){
      this.cards=this._cardList;
      return;
    }
    this._cardList=this.cards;
    this.cards=this.cards.filter(post=>post.title.startsWith(this.searchtitle));
  }
  
  
}
