// here we will create a class calculator which will have 4 methods add, sub, mul, div
// and we will export this class and then we will import this class in another file and use it  
export class Calculator {
    add(a: number, b: number): number {
        return a + b;
    }
    sub(a: number, b: number): number { 3
        return a - b;
    }
    mul(a: number, b: number): number {
        return a * b;
    }
    div(a: number, b: number): number {
        if (b === 0) {
            throw new Error("Division by zero is not allowed");
        }
        return a / b;
    }
}