var Shopper = /** @class */ (function () {
    function Shopper(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    Shopper.prototype.showName = function () {
        alert(this.firstName + " " + this.lastName);
    };
    return Shopper;
}());
//# sourceMappingURL=shop.js.map