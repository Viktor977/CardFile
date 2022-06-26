import { Component, Input, OnInit} from "@angular/core";
import { Observable } from "rxjs";
import { Card } from "../../spa/interfaces/card";
import { CardService } from "../../spa/services/card.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  
  cards:Card[];
  cardlist!:Observable<Card[]>
  searchtitle = "";
 
  constructor(private cardService: CardService) {}

  ngOnInit(): void {
    this.cardService.getCards().subscribe((cards: Card[]) => {
      this.cards = cards;
    }),
      (e: any) => {
        console.log(e);
      };
  }
  searByTitle(){

    if (this.searchtitle && this.searchtitle.length === 0) {    
      return;
    }
       this.cardService.search(this.searchtitle).subscribe((card:Card[])=>{
        this.cardlist=card;
      }),
      ((e:any)=>{console.log(e)});
   

 

  }
  
}
