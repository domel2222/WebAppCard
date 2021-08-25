import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "../services/store.service";


@Component({
    selector: 'checkout',
    templateUrl: 'checkout.component.html',
    styleUrls:['checkout.component.scss']
})

export class Checkout{
    public errorMessage ="";

    constructor (public store: Store, private router: Router){

    }

    onCheckout()  {
        this.errorMessage = "";
        this.store.checkout()
        .subscribe(() => {
            this.router.navigate(['/']);
        }, err => {
            this.errorMessage = `Failed to checkout : ${err}`
        })
    }
}

