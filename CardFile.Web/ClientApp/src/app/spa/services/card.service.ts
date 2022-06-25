import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { map } from "rxjs/operators";
import { Card } from "../interfaces/card";
import { FilterSeacher } from "src/app/models/FilterSeacher";

@Injectable({
  providedIn: "root",
})
export class CardService {
  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };
  searchId!: number;
  constructor(private http: HttpClient) {}

  getCards(): Observable<Card[]> {
    return this.http
      .get<Card[]>(`${environment.apiUrl}/TextMaterail`)
      .pipe(map((cards) => cards.slice(0, 3)));
  }
  like(id: number) {
    this.searchId = id;
    console.log(this.searchId);
  }
  search(searcTitle: string) {
    let filter = new FilterSeacher();
    filter.title = searcTitle;
    let params = new HttpParams().set("TitleText", filter.title);

    return this.http.get<Card[]>(`${environment.apiUrl}/TextMaterail`, {
      params: params,
    });
  }
}
