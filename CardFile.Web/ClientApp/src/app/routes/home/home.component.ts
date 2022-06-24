import { Component, Input, OnInit, EventEmitter, Output } from "@angular/core";
import { Card } from "../../spa/interfaces/card";
import { CardService } from "../../spa/services/card.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  cards!: Card[];
  private _cards!: Card[];
  card!: Card;
  @Input()
  searchtitle = "";
  @Output()
  onLikePost = new EventEmitter<Card>();
  constructor(private cardService: CardService) {}

  ngOnInit(): void {
    this.cardService.getCards().subscribe((cards: Card[]) => {
      this.cards = cards;
    }),
      (e: any) => {
        console.log(e);
      };
  }
  search() {
    if (this.searchtitle && this.searchtitle.length === 0) {
      this.cards = this._cards;
      return;
    }

    this._cards = this.cards;
    this.cards = this.cards.filter((card) =>
      card.title.startsWith(this.searchtitle)
    );
  }
}
