import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { map } from "rxjs/operators";
import { Card } from "../shared/Card";
import { LoginRequest } from "../shared/LoginRequest";
import { LoginResult } from "../shared/LoginResult";
import { Order} from "../shared/Order";
import { OrderItem } from "../shared/OrderItem";

@Injectable()
export class Store {
    

constructor(private http: HttpClient){
    
}

    public cards: Card[] = [];
    public order: Order = new Order();
    public token ="";
    public expiration = new Date(); 

    get loginRequired(): boolean {
        return this.token.length === 0 || this.expiration > new Date();
    }

    checkout(){
        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`)
        return this.http.post("/api/orders", this.order, {
            headers: headers,
        })
        .pipe(map(() => {
            this.order = new Order();
        }));
    }

    login(credentials: LoginRequest) {
        return this.http.post<LoginResult>("/account/createtoken", credentials)
            .pipe(map(data => {
                this.token = data.token;
                this.expiration = data.expiration;
            }));
    }

    loadProducts(): Observable<void>{
        return this.http.get<[]>("/api/card")
        .pipe(map(data => {
            this.cards = data
            return;
        }))
    }
  
    addToOrder(card: Card) {

        let  item: OrderItem|undefined;

        item = this.order.items.find(order => order.playerCardId === card.id);
        if (item){
            item.quantity++;
        }
        else{
            item = new OrderItem();
            item.playerCardId = card.id
            item.playerCardCategory = card.category;
            item.playerCardNationality = card.nationality;
            item.playerCardPlayerName = card.playerName;
            item.playerCardCardId = card.cardId
            item.unitPrice = card.price;
            item.quantity = 1;
            this.order.items.push(item);
        }
    }
}

