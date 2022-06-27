import { Assessment } from "./assessment";
export class Reaction {
  id:number
  userId: number;
  textId: number;
  comment: string;
  assessments: Assessment;
}
