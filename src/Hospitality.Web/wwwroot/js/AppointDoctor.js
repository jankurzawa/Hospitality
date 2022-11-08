let form = document.getElementById("appointForm");
let specialistDropDownList = document.getElementById("specialistDropDownList");
let modalForm = document.getElementById("exampleModal2");

let sendButton = document.querySelector('#sendButton');


sendButton.addEventListener("click", e => {
    console.log("Inside");
    console.log(specialistDropDownList.value);
    let informationMessage = modalForm.querySelector(".informationMessage");
if (specialistDropDownList.value == "none") {
        informationMessage.innerHTML = "Select specialist";
        e.preventDefault();
    } else {
        modalForm.style.visibility = 'hidden';
    }
});


function clearTextBoxFor() {
    specialistTextBoxFor.value = "none";
}



