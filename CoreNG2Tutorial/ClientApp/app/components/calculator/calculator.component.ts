import { Component } from "@angular/core";

@
Component({
    selector: "calculator",
    template: require("./calculator.component.html")
}) 
export class CalculatorComponent {
    title: string = "Welcome to Calculator from Component";
    first: number;
    second: number;
    constructor() { }

    add(): void {
        console.log("First Number is "+ this.first);
        console.log("Second Number is " + this.second);
    }
}