let form = document.getElementById("registrationForm");
let peselTextBoxFor = document.getElementById("pesel");
let peselInfoLabel = document.getElementById("peselInfoLabel");

let sendButton = document.getElementById("sendButton");
sendButton.disabled = true;
peselInfoLabel.style.visibility = "hidden";

console.log(peselInfoLabel.innerHTML);

peselTextBoxFor.addEventListener("input", e => {
    peselInfoLabel.style.visibility = "visible";
    let regPesel = /^[0-9]{11}$/g;
    let isCorrectPesel = regPesel.test(peselTextBoxFor.value);
    if (isCorrectPesel) {
        sendButton.disabled = false;
        peselInfoLabel.style.visibility = "hidden";
    } else {
        sendButton.disabled = true;
    } 
});