<<<<<<< HEAD
import { Observable } from "rxjs";
=======
﻿import { Observable } from 'rxjs';


>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f

export abstract class UserApi {
    signIn: (email: string, password: string) => Observable<any>;
    signOut: () => Observable<any>;
<<<<<<< HEAD
}
=======
}
>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
