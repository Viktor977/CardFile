import { Reaction } from "./reaction";
import { User } from "./user";
export class CardModel {
  id: number;
  title: string;
  article: string;
  author: string;
  datePublish: string;
  user: User;
  Reactions: Reaction;
}
