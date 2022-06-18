<<<<<<< HEAD
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Card } from '../interfaces/card';

=======
import { Injectable,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Card } from '../interfaces/card';
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
@Injectable({
  providedIn: 'root'
})
export class CardService {

<<<<<<< HEAD
  
=======
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
    url = "/api/TextMaterail";
    cards: Card[];
    constructor(private http: HttpClient) { }
    getText() {
        return this.http.get<Card[]>(this.url);
    }
}
