export class UserForRegistration {
    email: string;
    password: string;
    firstname:string;
    lastname:string;
    constructor(password: string, email: string,firstname:string,lastname:string) {
      this.email = email;
      this.password = password;
      this.firstname=firstname;
      this.lastname=lastname;
    }
  }
  