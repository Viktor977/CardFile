import { Role } from "./role.enum";

export class CurrentUser {
  firstname: string;
  lastname: string;
  email: string;
  password: string;
  id: number;
  role: Role;
  token:string;
}
