import { Component, Input, OnInit} from "@angular/core";
import { Router } from "@angular/router";
import { Card } from "../../spa/interfaces/card";
import { CardService } from "../../spa/services/card.service";


@Component({
  selector: "app-user",
  templateUrl: "./user.component.html",
  styleUrls: ["./user.component.css"],
})
export class UserComponent implements OnInit {
  
  selectedcard: Card[];
  @Input()
  cards: Card[];
  @Input()
  card: Card;
  searchtitle : string;
  comment : string;
  constructor(private cardService: CardService,private route:Router) {}

  ngOnInit(): void {
   
  }

  searByTitle(){
    this.card=null;
    console.log(this.searchtitle);
     return this.cardService.search(this.searchtitle).subscribe((cards:Card)=>{
      this.card=cards;
      console.log(this.card);
       this.searchtitle='';
    },(e:any)=>{console.log(e)});
   
    }
 
  handleLikedText(event: Event, id: number) {
    let confirmed = window.confirm("Thank for Your LIKE!!!");
    if(confirmed){

      this.card.id = id;
      this.cardService.addLikeAndComment(this.card.id,this.comment).subscribe();
   
  }
}
upDate(){
  this.route.navigate(['/auth/userinfo'])
}
}
