const loanAmountInput = document.getElementById('loanAmountInput');

// Add an event listener to format and validate the input value when it changes
loanAmountInput.addEventListener('change', function () {
    // Get the entered value
    let inputValue = this.value;

    // Remove currency symbol, thousand separators, and non-numeric characters
    inputValue = inputValue.replace(/[^0-9.]/g, '');

    // Convert the value to a number
    let amount = parseFloat(inputValue);

    // Check if the entered value is a valid number and within the specified range
    if (!isNaN(amount) && amount >= 20000 && amount <= 50000) {
        // Format the number as NGN currency with two decimal places
        let formattedAmount = new Intl.NumberFormat('en-NG', {
            style: 'currency',
            currency: 'NGN',
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        }).format(amount);

        // Update the input field value with the formatted amount
        this.value = formattedAmount;
    }
    else {
        // If the value is not valid or outside the range, clear the input field
        swal({
            title: "Invalid Input",
            text: "Amount cannot be less than NGN 20,000 and greater NGN 50,000",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
        this.value = '';
    }
});