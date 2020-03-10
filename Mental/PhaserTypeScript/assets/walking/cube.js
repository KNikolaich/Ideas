function get55() {

    if (document.getElementById("rang").value == '1') {
            myClasses1 = document.querySelectorAll('.dieC');
        //myClasses[0].style.display = 'none';
        myClasses1[0].style.display = 'none';
    }
        if (document.getElementById("rang").value == '1') {
            var myClasses = document.querySelectorAll('.dieA'),
                myClasses1 = document.querySelectorAll('.dieB');
            myClasses[0].style.display = 'none';
            myClasses1[0].style.display = 'none';
        }
        if (document.getElementById("rang").value == '2') {
            var myClasses = document.querySelectorAll('.dieA'),
                myClasses1 = document.querySelectorAll('.dieB');
            myClasses[0].style.display = 'none';
            myClasses1[0].style.display = 'block';
        }

        if (document.getElementById("rang").value == '3') {
            var myClasses = document.querySelectorAll('.dieA'),
                myClasses1 = document.querySelectorAll('.dieB');
            myClasses[0].style.display = 'block';
            myClasses1[0].style.display = 'block';
        }


    }


    function randomInteger(min, max) {
        var rand = min - 0.5 + Math.random() * (max - min + 1)
        rand = Math.round(rand);
        return rand;
    }

    class Die {
        constructor($container) {
            this._createElement($container);
            this._loadElements();
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.step = 0;
            this.results = { win: 0, lose: 0, tie: 0, total: 0 };
        }

        output() {
            this.index = Math.floor(Math.random() * 6);
            this.__rolling = false;
            this.$el.classList.remove('rolling');
            this._setFinalCoords();
        }


        rotate() {
            if (!this.__rolling) {
                this.__rolling = true;
                this.$el.classList.add('rolling');
            }
            this.step += 0.01;
            this.x += 5;
            this.y += 20;
            this.z += 10;
            this._setTransform();
        }

        get value() { return this.sides[this.index]; }

        _createElement($container) {
            this.$el = document.createElement('div');
            this.$el.className = `die ${this.type}`;
            for (let i = 0; i < 6; i++) {
                let $side = document.createElement('div'),
                    value = this.sides[i];
                $side.setAttribute('value', value);
                for (let j = 0; j < value; j++)
                    $side.innerHTML += '<span></span>';
                this.$el.appendChild($side);
            }
            $container.appendChild(this.$el);
        }

        _loadElements() {
            let $results = document.querySelector(`.${this.type}-results`);
            this.$win = $results.querySelector('p:last-child > span:nth-child(1) span:nth-child(2)');
            this.$wrate = $results.querySelector('p:last-child > span:nth-child(1) span:nth-child(3)');
            this.$lose = $results.querySelector('p:last-child > span:nth-child(2) span:nth-child(2)');
            this.$lrate = $results.querySelector('p:last-child > span:nth-child(2) span:nth-child(3)');
            this.$tie = $results.querySelector('p:last-child > span:nth-child(3) span:nth-child(2)');
            this.$trate = $results.querySelector('p:last-child > span:nth-child(3) span:nth-child(3)');
        }


        _setFinalCoords() {
            var www = randomInteger(1, 4);
            if (www == 1) {
                let coords = [
                    [85, 0, -5],
                    [-5, 275, -0],
                    [-5, 95, -5],
                    [-5, 5, 0],
                    [-5, 95, 175],
                    [-95, 0, 5],
                    [-5, 175, 0]
                ][
                    this.index];
                this.x = coords[0];
                this.y = coords[1];
                this.z = coords[2];

                this._setTransform();

            }
            if (www == 2) {
                let coords = [
                    [-5, 185, 0],
                    [85, 0, -5],
                    [-5, 95, 0],
                    [-5, 5, 0],
                    [-5, 95, 0],
                    [-95, 0, 5],
                    [-5, 185, 0]
                ][
                    this.index];
                this.x = coords[0];
                this.y = coords[1];
                this.z = coords[2];

                this._setTransform();

            }

            if (www == 3) {
                let coords = [
                    [-5, 185, 0],
                    [85, 0, -5],
                    [-5, 95, 0],
                    [-5, 5, 0],
                    [-5, 95, 0],
                    [-95, 0, 5]
                ][
                    this.index];
                this.x = coords[0];
                this.y = coords[1];
                this.z = coords[2];

                this._setTransform();

            }

            if (www == 4) {
                let coords = [
                    [-5, 185, 0],
                    [85, 0, -5],
                    [-5, 95, 0],
                    [-5, 5, 0],
                    [-5, 95, 0],
                    [-5, 185, 0],
                    [-5, 185, 0],
                    [85, 0, -5]
                ][
                    this.index];
                this.x = coords[0];
                this.y = coords[1];
                this.z = coords[2];

                this._setTransform();

            }


        }

        _setTransform() {
            let transform =
                `rotateX(${this.x}deg) rotateY(${this.y}deg) rotateZ(${this.z}deg)`;
            this.$el.style.webkitTransform = transform;
            this.$el.style.transform = transform;
        }
    }


    class DieA extends Die {
        get sides() { return [1, 2, 3, 4, 5, 6]; }

        get type() { return 'dieA'; }
    }

    class DieB extends Die {
        get sides() { return [1, 2, 3, 4, 5, 6]; }

        get type() { return 'dieB'; }
    }

    class DieC extends Die {
        get sides() { return [1, 2, 3, 4, 5, 6]; }

        get type() { return 'dieC'; }
    }


    let $container = document.querySelector('section1'),
        dieA = new DieA($container),
        dieB = new DieB($container),
        dieC = new DieC($container),
        rolling = false,
        power = false;


    rollDice(0);


    function rollDice(count) {
        if (!power) rotate();
        if (count < 20 || power && count < 1)
            window.requestAnimationFrame(() => rollDice(count + 1));
        else
            output();
    }

    function output() {
        dieA.output();
        dieB.output();
        dieC.output();
        dieA.complete(dieB);
        dieB.complete(dieC);
        dieC.complete(dieA);
        let ms = power ? 150 : 1000;
        setTimeout(() => rollDice(0), ms);
    }

    function rotate() {
        dieA.rotate();
        dieB.rotate();
        dieC.rotate();
    }
