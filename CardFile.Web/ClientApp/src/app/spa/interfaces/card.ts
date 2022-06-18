import { Data } from "@angular/router";

export interface Card {
    id?: number;
    title?: string;
    author?: string;
    article?: string;
    data?: Data;
    allows?: number;
    users?: Object[];
    reactions?: Object[];
}
