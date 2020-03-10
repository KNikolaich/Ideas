"use strict";

var model = (function () {

    var diceSet = [];
    var diceToRemove = 0;
    var totalDiceRemoved = 0;
    var selectedDiceVal = 0;
    var permDiceLength = 0;

    return {
        diceSet: diceSet,
        diceToRemove: diceToRemove,
        totalDiceRemoved: totalDiceRemoved,
        selectedDiceVal: selectedDiceVal,
        permDiceLength: permDiceLength
    }

})();



var view = (function () {

    var domEl = {
        genDiceDOM: document.getElementById("trigger-gen-dice"),
        rollDiceDOM: document.getElementById("trigger-roll-dice"),
        diceContainerDOM: document.getElementById("dice-container"),
        messageDOM: document.getElementById("message"),
        genDiceContDOM: document.getElementById("container-init"),
        mainGameDOM: document.getElementById("container-main-game"),
        valueSelector: document.getElementById('choose-dice'),
        gameControllerDOM: document.getElementById('game-controller'),
        inputNumDice: document.getElementById("input-num-dice"),
        diceRollingDOM: document.getElementById("rolling-dice-anim")
    }

    var diceImages = {
        dice1: "https://image.ibb.co/mARW6J/dice_1.png",
        dice2: "https://image.ibb.co/ckY00d/dice_2.png",
        dice3: "https://image.ibb.co/gJ0DLd/dice_3.png",
        dice4: "https://image.ibb.co/drDpty/dice_4.png",
        dice5: "https://image.ibb.co/kqChDy/dice_5.png",
        dice6: "https://image.ibb.co/duJ00d/dice_6.png"
    }

    return {
        domEl: domEl,
        displayDiceSet: function (dataSet) {

            domEl.diceContainerDOM.innerHTML = "";

            dataSet.forEach(function (dice) {

                var diceDOM = document.createElement("div");
                var diceNumDOM = document.createElement("span");
                var diceDOMFrag = document.createDocumentFragment();

                diceDOM.className = "dice";
                domEl.diceContainerDOM.appendChild(diceDOM);
                diceDOM.appendChild(diceNumDOM);
                diceNumDOM.innerHTML = `<img src="${diceImages["dice" + dice.value]}" width="40">`;

                if (dice.selected == true) {
                    diceDOM.className += " selected";
                }

            });
        }
    }

})();



var controller = (function (viewCont, modelCont) {

    // Event Handlers
    viewCont.domEl.genDiceDOM.addEventListener("click", genNumDice);
    viewCont.domEl.rollDiceDOM.addEventListener("click", rollDice);
    viewCont.domEl.valueSelector.onclick = getSelectedVal;


    function Dice(name, value, selected, diceImage) {
        this.name = name;
        this.value = value;
        this.selected = selected;
        this.diceImage = diceImage;
    }


    function getSelectedVal(e) {

        var target = e.target;

        for (var i = 0; i < viewCont.domEl.valueSelector.children.length; i++) {
            viewCont.domEl.valueSelector.children[i].className = "";
        }

        target.className = "dice-selected";
        modelCont.selectedDiceVal = e.target.innerHTML;

    }


    function genNumDice() {

        viewCont.domEl.messageDOM.style.display = "block";

        if (viewCont.domEl.inputNumDice.value === "") {

            viewCont.domEl.messageDOM.innerHTML = `Please enter a number!`;

        } else {

            var diceNumDOM = parseInt((view.domEl.inputNumDice).value, 10);

            viewCont.domEl.messageDOM.innerHTML = `Okay, I've generated ${diceNumDOM} pieces of dice!`;

            for (var i = 0; i < diceNumDOM; i++) {
                modelCont.diceSet[i] = new Dice("dice" + (i + 1), null, false, null);
            }

            modelCont.permDiceLength = modelCont.diceSet.length;

            viewCont.domEl.genDiceContDOM.style.display = "none";
            viewCont.domEl.mainGameDOM.style.display = "block";

        }

    }



    function rollDice() {

        viewCont.domEl.messageDOM.style.display = "block";
        viewCont.domEl.diceContainerDOM.style.display = "none";

        viewCont.domEl.messageDOM.innerHTML = "Rolling the dice...";
        viewCont.domEl.diceRollingDOM.style.display = "block";

        playAudio();

        function playAudio() {
            var audio = new Audio('http://cd.textfiles.com/itcontinues/WIN/YTB22/MANYDICE.WAV');
            audio.play();
        }

        setTimeout(function () {

            viewCont.domEl.diceRollingDOM.style.display = "none";

            viewCont.domEl.diceContainerDOM.style.display = "block";
            viewCont.domEl.messageDOM.style.display = "block";

            modelCont.diceSet.splice(0, modelCont.diceToRemove);
            modelCont.diceToRemove = 0;

            var diceValueDOM = parseInt(modelCont.selectedDiceVal);

            modelCont.diceSet.forEach(function (dice, index) {
                var randomNum = Math.floor((Math.random() * 6) + 1);
                dice.value = randomNum;
                if (diceValueDOM === dice.value) {
                    modelCont.diceToRemove++;
                    modelCont.totalDiceRemoved++;
                    dice.selected = true;
                } else {
                    dice.selected = false;
                }
            });

            if (modelCont.diceToRemove > 0) {
                if (modelCont.totalDiceRemoved === modelCont.permDiceLength) {
                    viewCont.domEl.messageDOM.innerHTML = `I bet you drank a ton! No worries, you got it! Game has ended.`;
                    viewCont.domEl.gameControllerDOM.style.display = "none";
                } else {
                    viewCont.domEl.messageDOM.innerHTML = `Good guess! There's a "${diceValueDOM}" in the set!`;
                }
            } else {
                viewCont.domEl.messageDOM.innerHTML = `There's no "${diceValueDOM}" in the set. Drink, drink, drink!`;
            }

            viewCont.displayDiceSet(modelCont.diceSet);

        }, 1000);

    }

})(view, model);