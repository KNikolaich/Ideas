
var canvas = document.getElementById("myCanvas");
var coordinat = document.getElementById("lcoordinat");
        context = canvas.getContext("2d");
    // Создаем объект изображения
    var img = new Image();
    img.onload = function () {
        context.drawImage(img, 0, 0);
    };
    // Загружаем файл изображения
    img.src = "/Content/img/game1/field1.jpg";

canvas.onmousedown = function (e) {
    //var loc = windowToCanvas(canvas, e.clientX, e.clientY);
    //drawBackground();
    //drawSpritesheet();
    //drawGuidelines(loc.x, loc.y);
    var updateReadout = function (x, y) { coordinat.innerText = x +", " + y; };
    updateReadout(e.clientX, e.clientY);
        // Код для нажатия мыши
};

    //context.drawImage(img);
    /*context.beginPath();
    context.moveTo(30, 20);
    context.lineTo(100, 80);
    context.lineTo(150, 30);
    context.closePath();*/
    //context.beginPath();

    // здесь инструкции по созданию фигур
 /*   var x = 10, y = 10;

    function drawRect() {
        context.fillStyle = 'black';
        context.clearRect(0, 0, 600, 300);
        context.fillRect(x, y, 50, 50);
    }

    function gameLoop() {
        drawRect();
        x += 2;
        requestAnimationFrame(gameLoop);
    };

    gameLoop();
    */

/*for (var i = 0; i < 10; i++) {
drawRect();
x += 55;
}*/
//context.closePath();