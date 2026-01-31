// Step 1: Append value to input
function appendValue(value) {
    document.getElementById("result").value += value;
}

// Step 2: Clear input
function clearResult() {
    document.getElementById("result").value = "";
}

// Step 3: Calculate expression
function calculate() {
    let expression = document.getElementById("result").value;
    if (expression === "") return;
    try {
        let output = eval(expression);
        document.getElementById("result").value = output;
    } catch (error) {
        alert("Invalid Expression");
    }
}
