import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { map } from "rxjs/operators";
import { Card } from "../interfaces/card";
import { FilterSeacher } from "src/app/models/FilterSeacher";
import { Reaction } from "src/app/models/reaction";
import { Assessment } from "src/app/models/assessment";

@Injectable({
  providedIn: "root",
})
export class CardService {
  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };
  searchId!: number;
  seacherFilter:FilterSeacher;
  reaction:Reaction;
  constructor(private http: HttpClient) {}

  getCards(): Observable<Card[]> {
   return this.http
      .get<Card[]>(`${environment.apiUrl}/TextMaterail`)
      .pipe(map((cards) => cards.slice(0, 10)));
  }

  like(id: number) {
    this.searchId = id;
    console.log(this.searchId);
  }
 

  search(searcTitle: string):Observable<Card[]> {
   this.seacherFilter= new FilterSeacher();
    this.seacherFilter.title = searcTitle;
  
      let res= this.http.get<Card[]>(`${environment.apiUrl}/TextMaterail`);
      console.log(res);
      return res;
  }
  addLike(id:number,coment:string){
   this.reaction=new Reaction();
   this.reaction.id=0;
   this.reaction.userId=JSON.parse(localStorage.getItem('id')).id;
   this.reaction.textId=id;
   this.reaction.comment=coment;
   this.reaction.assessments=Assessment.Like;
   console.log(this.reaction);
  
       let res=this.http.post(`${environment.apiUrl}/Reaction`,this.reaction,this.httpOptions);
       console.log(res);
       return res;
  }
  getReactionById(id:number):Observable<Reaction>{
let res=this.http.get<Reaction>(`${environment.apiUrl}/Reaction ${id}`);
return res;
  }
}
