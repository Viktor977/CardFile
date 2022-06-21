import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Card } from '../../spa/interfaces/card';
import { CardService } from '../../spa/services/card.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

    searchTitle: string
    id: number;
    confirmId: number;
    rejectId: number;
    selectedCard: Card;
    cards: Card[];
    private _cards: Card[];

    @Input() card!: Card;

    @Output()
    onLikePost = new EventEmitter<Card>();

    constructor(private cardService: CardService) { }

    ngOnInit() {
        this.cardService.getText().subscribe(
            ((cards: Card[]) => { this.cards = cards }), ((e: any) => { console.log(e) }));
    }

    selct(card: Card) {
        this.selectedCard = card;
    }

    search() {
        if (this.searchTitle.length === 0) {
            this.cards = this._cards;
            return;
        }
        this._cards = this.cards;
        this.cards = this.cards.filter(card => card.title.startsWith(this.searchTitle));
    }

    handleLikedText(event: Event, id: number) {
        this.id = id;
        this.cardService.like(this.id);

    }

    handleConfirmText(event: Event, id: number) {
        this.confirmId = id;
    }

    handleRejectext(evenr: Event, id: number) {
        this.rejectId = id;
    }


}
