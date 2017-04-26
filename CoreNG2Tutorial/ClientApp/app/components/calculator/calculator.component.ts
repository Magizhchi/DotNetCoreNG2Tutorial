import { Component } from "@angular/core";

import { CalculatorService } from "./calculator.service";

@
Component({
    selector: "calculator",
    template: require("./calculator.component.html")
}) 
export class CalculatorComponent {
    title: string = "Welcome to Calculator from Component";
    first: number;
    second: number;
    result: number;
    constructor(
        private calculatorService: CalculatorService
    ) { }

    add(): void {
        this.calculatorService
            .addNumbers(this.first, this.second)
            .then(res => console.log(res));
    }
}