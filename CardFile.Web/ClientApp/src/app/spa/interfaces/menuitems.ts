import { Role } from "src/app/models/role.enum";

export interface MenuItems {
    text: string;
    icon: string;
    role:Role;
    route: string;
   
}
