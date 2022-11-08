let form = document.getElementById("checkUpForm");
let descriptionTextArea = document.getElementById("descriptionTextArea");

let finishButton = document.getElementById("finishButton");
finishButton.disabled = true;

descriptionTextArea.addEventListener("input", e => {
  
    if (descriptionTextArea.value.length > 3) {
        finishButton.disabled = false;
    } else {
        finishButton.disabled = true;
    }
});