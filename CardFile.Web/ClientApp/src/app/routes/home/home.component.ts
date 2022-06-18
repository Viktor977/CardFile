import { Component, OnInit } from '@angular/core';
import { Card } from '../../spa/interfaces/card';
import { CardService } from '../../spa/services/card.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
<<<<<<< HEAD
 
=======

>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
    cards: Card[];
    constructor(private cardService: CardService) { }

    ngOnInit() {
        this.cardService.getText().subscribe(
            ((cards: Card[]) => { this.cards = cards }), ((e: any) => { console.log(e) }));
<<<<<<< HEAD
    }
=======
  }
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f

}
