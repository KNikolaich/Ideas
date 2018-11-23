
document.addEventListener("DOMContentLoaded", function () {
    var element = document.createElement("p");
    element.textContent = "Это элемент  из файла third.js";
    document.querySelector("body").appendChild(element);
})