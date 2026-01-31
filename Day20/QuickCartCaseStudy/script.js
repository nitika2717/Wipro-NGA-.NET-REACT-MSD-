//US-1 weLCOME MESSAGE
const showWelcome = () => console.log("Welcome to QuickCart! Your one-stop shop for all your needs.");
showWelcome();

//US-2 Apply Discount
const applydiscount = price => price * 0.9; // 10% discount
console.log(applydiscount(100)); 

//US-3 Calculate Total Bill
const calculateTotalBill = (price, tax) => price+ tax;
console.log(calculateTotalBill(100, 5));

//US-4 Billing Summary
const summary = (price, discount) =>{
    return{final: price- discount};
};
console.log(summary(100, 10));

// US-5: Create product
const createProduct = (id, name) => ({ id, name });// returns an object
console.log(createProduct(1, "Laptop"));

//US-6 Discounted Price list
const prices = [100, 200, 300];
const discounted = prices.map(p => p * 0.9);
console.log(discounted);

// US-7: Session timer
let session = {
  sec: 0,
  start() {
    setInterval(() => {
      this.sec++;
      console.log("Session time:", this.sec);
    }, 1000);
  }
};
session.start();


