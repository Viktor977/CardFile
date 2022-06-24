import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { map } from "rxjs/operators";
import { Card } from "../interfaces/card";

@Injectable({
  providedIn: "root",
})
export class CardService {
  searchId!: number;
  constructor(private http: HttpClient) {}

  getCards(): Observable<Card[]> {
    return this.http
      .get<Card[]>(`${environment.apiUrlTwo}/Card`)
      .pipe(map((cards) => cards.slice(0, 3)));
  }
  like(id: number) {
    this.searchId = id;
    console.log(this.searchId);
  }
}
