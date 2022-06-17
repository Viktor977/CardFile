"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.appRouters = void 0;
var home_component_1 = require("../routes/home/home.component");
var card_component_1 = require("../routes/card/card.component");
var authenticated_component_1 = require("./authenticated/authenticated.component");
var sign_in_component_1 = require("../spa/users/sign-in/sign-in.component");
var registration_component_1 = require("../spa/users/registration/registration.component");
var auth_guard_service_1 = require("../spa/services/auth-guard.service");
exports.appRouters = [
    { path: 'sign-in', component: sign_in_component_1.SignInComponent },
    { path: 'register', component: registration_component_1.RegistrationComponent },
    {
        path: 'authenticated', component: authenticated_component_1.AuthenticatedComponent, canActivate: [auth_guard_service_1.AuthGuard], children: [
            {
                path: '', canActivateChild: [auth_guard_service_1.AuthGuard], children: [
                    { path: 'home', component: home_component_1.HomeComponent },
                    { path: 'card', component: card_component_1.CardComponent },
                ]
            }
        ]
    },
    { path: '', redirectTo: 'sign-in', pathMatch: 'full' },
    { path: '**', component: sign_in_component_1.SignInComponent }
];
//# sourceMappingURL=app.routes.js.map