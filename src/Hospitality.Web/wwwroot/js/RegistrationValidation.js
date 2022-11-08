'use strict';

let form = document.getElementById("registrationForm");
let surnameTextBoxFor = document.getElementById("surname");
let nameTextBoxFor = document.getElementById("nameTextBoxFor");
let specialistTextBoxFor = document.getElementById("specialist");
let addressTextBoxFor = document.getElementById("address");
let peselTextBoxFor = document.getElementById("pesel");
let emailTextBoxFor = document.getElementById("email");
let phoneTextBoxFor = document.getElementById("phone");
let modalForm = document.getElementById("exampleModal");
let sendButton = document.querySelector('#sendButton');
let saveButton = document.querySelector('#saveButton');
let cancelButton = document.querySelector('#cancelButton');

sendButton.addEventListener("click", e => {
    console.log("Inside");
    saveButton.style.visibility = "hidden";

    let regEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$/g;
    let regName = /^[a-zA-Z\s]{2,50}$/g;
    let regSurname = /^[a-zA-Z\s]{2,50}$/g;
    let regAddress = /^[a-zA-Z\s-/0-9,]{4,150}$/g;
    let regPesel = /^[0-9]{11}$/g;
    let regPhone = /^[1-9][0-9]{8}$/g;
    console.log(nameTextBoxFor.value);
    console.log(surnameTextBoxFor.value);
    console.log(peselTextBoxFor.value);
    console.log(addressTextBoxFor.value);
    console.log(emailTextBoxFor.value);
    console.log(specialistTextBoxFor.value);
    let isCorrectEmail = regEmail.test(emailTextBoxFor.value);
    let isCorrectName = regName.test(nameTextBoxFor.value);
    let isCorrectSurname = regSurname.test(surnameTextBoxFor.value);
    let isCorrectAddress = regAddress.test(addressTextBoxFor.value);
    let isCorrectPesel = regPesel.test(peselTextBoxFor.value);
    let isCorrectPhone = regPhone.test(phoneTextBoxFor.value);
    console.log(isCorrectName);


    let errorMessage = modalForm.querySelector(".errorMessage");
    if (nameTextBoxFor.value.length < 2) {
        errorMessage.innerHTML = "Name is too short";
    } else if (!isCorrectName) {
        errorMessage.innerHTML = "Name has wrong symbol";
    } else if (surnameTextBoxFor.value.length < 2) {
        errorMessage.innerHTML = "Surname is too short";
    } else if (!isCorrectSurname) {
        errorMessage.innerHTML = "Surname has wrong symbol";
    } else if (!isCorrectPesel) {
        errorMessage.innerHTML = "Pesel shoud has 11 numbers";
    } else if (addressTextBoxFor.value.length < 4) {
        errorMessage.innerHTML = "Address is too short";
    } else if (addressTextBoxFor.value.length > 150) {
        errorMessage.innerHTML = "Address is too long";
    } else if (!isCorrectAddress) {
        errorMessage.innerHTML = "Address has wrong symbol";
    } else if (!isCorrectEmail) {
        errorMessage.innerHTML = "Wrong email format";
    } else if (!isCorrectPhone) {
        errorMessage.innerHTML = "Phone number shoud has 9 numbers";
    } else if (specialistTextBoxFor.value == "none") {
        errorMessage.innerHTML = "Select specialist";
    } else {
        errorMessage.innerHTML = "Would you like to save patient visit?";
        saveButton.style.visibility = "visible";
    }
});




