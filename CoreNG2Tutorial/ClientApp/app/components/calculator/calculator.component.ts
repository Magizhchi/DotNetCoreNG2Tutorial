import { Component } from "@angular/core";

@
Component({
    selector: "calculator",
    template: require("./calculator.component.html")
}) 
export class CalculatorComponent {
    title: string = "Welcome to Calculator from Component";
    constructor() {}
}