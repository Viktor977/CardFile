import { Reaction } from "./reaction";
import { CurrentUser } from './currentuser';
export class CardModel {
  id: number;
  title: string;
  article: string;
  author: string;
  datePublish: string;
  user: CurrentUser;
  Reactions: Reaction;
}
