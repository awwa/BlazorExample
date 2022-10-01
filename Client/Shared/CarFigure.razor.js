export function drawTopView() {
    var canvas = document.getElementById("car_figure");
    var c = canvas.getContext("2d");

    c.lineWidth = 2;

    // Draw the top view
    c.beginPath();
    c.moveTo(100, 50);
    c.lineTo(50, 100);
    c.lineTo(50, 300);
    c.lineTo(100, 350);
    c.lineTo(650, 350);
    c.lineTo(700, 300);
    c.lineTo(700, 100);
    c.lineTo(650, 50);
    c.lineTo(100, 50);
    c.closePath();
    c.stroke();

    // Draw side view
    c.beginPath();
    c.moveTo(50, 600);
    c.lineTo(50, 700);
    c.lineTo(700, 700);
    c.lineTo(700, 550);
    c.lineTo(600, 450);
    c.lineTo(350, 450);
    c.lineTo(225, 550);

    c.closePath();
    c.stroke();

}