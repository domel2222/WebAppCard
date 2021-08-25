import { Component, OnInit } from "@angular/core";
import { Store } from "../services/store.service";

@Component({
    selector: 'cards-list',
    templateUrl: 'cardListView.component.html',
    styleUrls: ['./cardListView.component.scss']
})


export default class CardListView implements OnInit {

    constructor(public store: Store) {
        
    }

    ngOnInit(): void {
        this.store.loadProducts()
        .subscribe(() => { //do something}
        // kicks off the operation 
        });
    }
}
