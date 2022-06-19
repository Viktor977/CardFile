import { Component, OnInit } from '@angular/core';
import { Card } from '../../spa/interfaces/card';
import { CardService } from '../../spa/services/card.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {


    cards: Card[];
    constructor(private cardService: CardService) { }

    ngOnInit() {
        this.cardService.getText().subscribe(
            ((cards: Card[]) => { this.cards = cards }), ((e: any) => { console.log(e) }));
    }
 

}
