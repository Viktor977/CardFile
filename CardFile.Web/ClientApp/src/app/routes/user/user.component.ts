import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Card } from "../../spa/interfaces/card";
import { CardService } from "../../spa/services/card.service";

@Component({
  selector: "app-user",
  templateUrl: "./user.component.html",
  styleUrls: ["./user.component.css"],
})
export class UserComponent implements OnInit {
  private _cards!: Card[];
  card: Card;
  @Output()
  onLikePost = new EventEmitter<Card>();
  selectedcard: Card[];
  @Input()
  cards: Card[];

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

  searhWithTitle(title: string) {
    this.cardService.search(title).subscribe((cards: Card[]) => {
      this.selectedcard = cards;
    });
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
  handleLikedText(event: Event, id: number) {
    this.card.id = id;
    this.cardService.addLike(this.card.id,'');
  }
}
