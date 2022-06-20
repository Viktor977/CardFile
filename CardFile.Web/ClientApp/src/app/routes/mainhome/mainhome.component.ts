import { Component, OnInit } from '@angular/core';
import { Card } from '../../spa/interfaces/card';
import { CardService } from '../../spa/services/card.service';

@Component({
  selector: 'app-mainhome',
  templateUrl: './mainhome.component.html',
  styleUrls: ['./mainhome.component.css']
})
export class MainhomeComponent implements OnInit {

    searchTitle: string;
    cards: Card[];
  private  _cards: Card[];
    constructor(private cardService: CardService) { }

    ngOnInit() {
        this.cardService.getText().subscribe(
            ((cards: Card[]) => { this.cards = cards }), ((e: any) => { console.log(e) }));

    }

    search() {
        if (this.searchTitle.length === 0) {
            this.cards = this._cards;
            return;
        }
        this._cards = this.cards;
        this.cards = this.cards.filter(card => card.title.startsWith(this.searchTitle));
    }

}
