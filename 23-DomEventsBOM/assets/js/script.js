let num1 = document.querySelector('.num1');
let num2 = document.querySelector('.num2');
const result = document.querySelector('.result-input');

const plus = document.querySelector('.plus');
const minus = document.querySelector('.minus');
const multiply = document.querySelector('.mult');
const divide = document.querySelector('.divide');


function GetInputValues() {
    if (num1.value === '' || num2.value === '') {
        alert('Fill both inputs!');
        ResetInputs();
        return false;
    }
    return true;
}

function ResetInputs() {
    num1.value = '';
    num2.value = '';
}


plus.addEventListener('click', () => {
    if (!GetInputValues()) return;

    result.value = Number(num1.value) + Number(num2.value);
    ResetInputs();
});

minus.addEventListener('click', () => {
    if (!GetInputValues()) return;

    result.value = Number(num1.value) - Number(num2.value);
    ResetInputs();
})

multiply.addEventListener('click', () => {
    if (!GetInputValues()) return;

    result.value = Number(num1.value) * Number(num2.value)
    ResetInputs();
});

divide.addEventListener('click', () => {
    if (!GetInputValues()) return;

    const val1 = Number(num1.value);
    const val2 = Number(num2.value);

    if (val2 === 0) {
        alert('Cannot divide by zero');
        ResetInputs();
        return;
    }

    result.value = val1 / val2;
    ResetInputs();

});

