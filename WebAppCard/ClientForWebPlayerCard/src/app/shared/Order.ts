import  {OrderItem}  from "./OrderItem";

export class Order {
    minValue : number = 1;
    maxValue : number = 1000000;
    orderId!: number;
    orderDate: Date = new Date();
    orderNumber : number = Math.floor(Math.random() * (this.maxValue - this.minValue + 1)) + this.minValue;
    items: OrderItem[] = [];


    
    public get subtotal() : number {

        const result = this.items.reduce((acc, value) => {
            return acc + (value.unitPrice * value.quantity)
        }, 0) // start at 0
        return result;
    }
        
    
    
}