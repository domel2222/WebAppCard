import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "../services/store.service";
import { LoginRequest } from "../shared/LoginRequest";

@Component({
    selector: 'login-page',
    templateUrl: 'loginPage.component.html'
})

export class LoginPage{
    constructor(private store: Store, private router: Router){

    }

    public credentials: LoginRequest = {
        username: '',
        password:'',
    }

    public errorMessage = "";

    onLogin() {
        this.store.login(this.credentials)
            .subscribe(() => { //do something successfuly logged in
                if (this.store.order.items.length > 0) {
                    this.router.navigate(["checkout"])
                } else {
                    this.router.navigate([""])
                }
            }, error => { //do something
            this.errorMessage = "Luigii Atencione"
            });
        }
    }


