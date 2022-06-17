import { Injectable,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Card } from '../interfaces/card';
@Injectable({
  providedIn: 'root'
})
export class CardService {

    url = "/api/TextMaterail";
    cards: Card[];
    constructor(private http: HttpClient) { }
    getText() {
        return this.http.get<Card[]>(this.url);
    }
}
