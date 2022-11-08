let form = document.getElementById("startVisitForm");
let peselTextBoxFor = document.getElementById("pesel");
let peselInfoLabel = document.getElementById("peselInfoLabel");

let startButton = document.getElementById("startButton");
startButton.disabled = true;
peselInfoLabel.style.visibility = "hidden";

console.log(peselInfoLabel.innerHTML);

peselTextBoxFor.addEventListener("input", e => {
    peselInfoLabel.style.visibility = "visible";
    let regPesel = /^[0-9]{11}$/g;
    let isCorrectPesel = regPesel.test(peselTextBoxFor.value);
    if (isCorrectPesel) {
        startButton.disabled = false;
        peselInfoLabel.style.visibility = "hidden";
    } else {
        startButton.disabled = true;
    }
});