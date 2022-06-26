import { Component, OnInit, Input } from "@angular/core";
import { CardService } from "../services/card.service";
import { Card } from "../interfaces/card";
import { Observable } from "rxjs";

@Component({
  selector: "app-card",
  templateUrl: "./card.component.html",
  styleUrls: ["./card.component.css"],
})
export class CardComponent implements OnInit {
  @Input() card: Card;

  constructor(
    private cardServise: CardService,
  ) {}

  ngOnInit(): void {
   
  }

  handleLikedText(event: Event, id: number) {
    this.card.id = id;
    this.cardServise.like(this.card.id);
  }
}
