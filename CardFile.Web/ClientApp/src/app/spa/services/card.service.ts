import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { map, tap } from 'rxjs/operators';
import { Card } from '../interfaces/card';



@Injectable({
  providedIn: 'root'
})

export class CardService {

    url = "/api/TextMaterail";
    cards: Card[] = [];
    card: Card;
    cardId: number;

    constructor(private http: HttpClient) { }

    getText(): Observable<Card[]> {
        return this.http.get<Card[]>(`${environment.apiUrl}/TextMaterail`).pipe(map((cards) => cards.slice(0, 3)))
    };

    like(id: number) {
        this.cardId = id;
        console.log(this.cardId);
    }
}
