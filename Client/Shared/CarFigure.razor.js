export function drawCar() {
    var canvas = document.getElementById("car_figure");
    var c = canvas.getContext("2d");

    // Draw top view
    drawCarTopView(c);

    // Draw side view
    drawCarSideView(c);

    // Draw front view
    drawCarFrontView(c);

    // Draw rear view
    drawCarRearView(c);
}

function drawCarTopView(c) {
    // 外周
    c.fillStyle = 'white';
    c.lineWidth = 2;
    c.beginPath();
    c.moveTo(90, 50);   // front right
    c.lineTo(50, 100);
    c.lineTo(50, 300);
    c.lineTo(90, 350);  // front left
    c.lineTo(640, 350); // rear left
    c.lineTo(700, 290);
    c.lineTo(700, 110);
    c.lineTo(640, 50);  // rear right
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー左
    c.beginPath();
    c.moveTo(300, 30);
    c.lineTo(300, 60);
    c.lineTo(320, 60);
    c.lineTo(320, 30);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー右
    c.beginPath();
    c.moveTo(300, 340);
    c.lineTo(300, 370);
    c.lineTo(320, 370);
    c.lineTo(320, 340);
    c.closePath();
    c.fill();
    c.stroke();
    // フロントガラス
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(270, 80);  // bottom right
    c.lineTo(230, 140);
    c.lineTo(230, 260);
    c.lineTo(270, 320); // bottom left
    c.lineTo(360, 290); // top left
    c.lineTo(350, 240);
    c.lineTo(350, 160);
    c.lineTo(360, 110); // top right
    c.closePath();
    c.fill();
    c.stroke();
    // サイドフロントガラス右
    c.beginPath();
    c.moveTo(290, 70);
    c.lineTo(380, 100);
    c.lineTo(430, 100);
    c.lineTo(410, 70);
    c.closePath();
    c.fill();
    c.stroke();
    // サイドフロントガラス左
    c.beginPath();
    c.moveTo(290, 330);
    c.lineTo(410, 330);
    c.lineTo(430, 300);
    c.lineTo(380, 300);
    c.closePath();
    c.fill();
    c.stroke();
    // サイドリアガラス右
    c.beginPath();
    c.moveTo(440, 70);
    c.lineTo(450, 100);
    c.lineTo(550, 100);
    c.lineTo(580, 85);
    c.lineTo(550, 70);
    c.closePath();
    c.fill();
    c.stroke();
    // サイドリアガラス左
    c.beginPath();
    c.moveTo(450, 300);
    c.lineTo(440, 330);
    c.lineTo(550, 330);
    c.lineTo(580, 315);
    c.lineTo(550, 300);
    c.closePath();
    c.fill();
    c.stroke();
    // リアガラス
    c.beginPath();
    c.moveTo(585, 110);
    c.lineTo(610, 160);
    c.lineTo(610, 240);
    c.lineTo(585, 290);
    c.lineTo(640, 320);
    c.lineTo(680, 270);
    c.lineTo(680, 130);
    c.lineTo(640, 80);
    c.closePath();
    c.fill();
    c.stroke();
    // 寸法表記
    drawArrowLineVertical(c, 20, 50, 100, 350, 30); // 全幅
}

function drawCarSideView(c) {
    // 外周
    c.lineWidth = 2;
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(50, 590);  // grill top
    c.lineTo(50, 680);  // grill under
    c.lineTo(150, 700);
    c.lineTo(600, 700);
    c.lineTo(700, 670); // rear under
    c.lineTo(700, 550); // rear top
    c.lineTo(600, 450); // spoiler top
    c.lineTo(360, 450); // front glass top
    c.lineTo(230, 550); // front glass under
    c.closePath();
    c.fill();
    c.stroke();
    // フロントガラス
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(347, 460); // front glass top
    c.lineTo(230, 550); // front glass under
    c.lineTo(270, 550); // front glass under
    c.lineTo(360, 460); // front glass top
    c.closePath();
    c.fill();
    c.stroke();
    // サイドフロントガラス
    c.beginPath();
    c.moveTo(380, 460); // side front glass top
    c.lineTo(290, 550); // side front glass under
    c.lineTo(410, 550); // side front glass under
    c.lineTo(430, 460); // side front glass under
    c.closePath();
    c.fill();
    c.stroke();
    // サイドリアガラス
    c.beginPath();
    c.moveTo(450, 460); // side front glass top
    c.lineTo(440, 550); // side front glass under
    c.lineTo(550, 550); // side front glass under
    c.lineTo(580, 500); // side front glass under
    c.lineTo(550, 460); // side front glass under
    c.closePath();
    c.fill();
    c.stroke();
    // リアガラス
    c.beginPath();
    c.moveTo(585, 460); // side front glass top
    c.lineTo(640, 530); // side front glass under
    c.lineTo(680, 530); // side front glass under
    c.lineTo(610, 460); // side front glass under
    c.closePath();
    c.fill();
    c.stroke();
    // ヘッドライト
    c.beginPath();
    c.moveTo(50, 595);  // front top
    c.lineTo(50, 620);
    c.lineTo(120, 620);
    c.lineTo(120, 595);
    c.closePath();
    c.stroke();
    // リアランプ
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(690, 540);
    c.lineTo(690, 565);
    c.lineTo(620, 565);
    c.lineTo(620, 540);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー
    c.fillStyle = "white";
    c.beginPath();
    c.moveTo(300, 530);
    c.lineTo(300, 560);
    c.lineTo(320, 560);
    c.lineTo(320, 530);
    c.closePath();
    c.fill();
    c.stroke();
    // 前輪
    drawTireSideView(c, 180, 680, 64, 44);
    // 後輪
    drawTireSideView(c, 580, 680, 64, 44);
    // 地面
    c.lineWidth = 2;
    c.moveTo(20, 745);
    c.lineTo(730, 745);
    c.stroke();
    // 寸法表記
    drawArrowLineHorizontal(c, 180, 745, 580, 775, 770);    // ホイールベース
    drawArrowLineHorizontal(c, 50, 670, 700, 800, 795);     // 全長
    drawArrowLineVertical(c, 600, 450, 750, 745, 745);      // 全幅
    drawArrowLineVertical(c, 100, 700, 120, 745, 105);      // 最低地上高
}

function drawCarFrontView(c) {
    // 外周
    drawOuterFrontView(c, 975, 350, 0, 0);
    // フロントガラス
    c.lineWidth = 2;
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(885, 65);     // left top+180
    c.lineTo(855, 155);    // left bottom+240
    c.lineTo(1095, 155);    // right bottom
    c.lineTo(1065, 65);     // right top
    c.closePath();
    c.fill();
    c.stroke();
    // グリル
    c.beginPath();
    c.moveTo(900, 185); // left top
    c.lineTo(900, 250);
    c.lineTo(1050, 250);
    c.lineTo(1050, 185);
    c.closePath();
    c.stroke();
    // ヘッドライト左
    c.beginPath();
    c.moveTo(835, 185); // left top
    c.lineTo(835, 210);
    c.lineTo(900, 210);
    c.lineTo(900, 185);
    c.closePath();
    c.stroke();
    // ヘッドライト右
    c.beginPath();
    c.moveTo(1050, 185); // left top
    c.lineTo(1050, 210);
    c.lineTo(1115, 210);
    c.lineTo(1115, 185);
    c.closePath();
    c.stroke();
    // ナンバープレート
    c.beginPath();
    c.moveTo(945, 260); // left top
    c.lineTo(945, 290);
    c.lineTo(1005, 290);
    c.lineTo(1005, 260);
    c.closePath();
    c.stroke();
}

function drawCarRearView(c) {
    // 外周
    drawOuterFrontView(c, 975, 745, 0, 0);
    // リアガラス
    c.lineWidth = 2;
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(885, 460);     // left top
    c.lineTo(855, 530);    // left bottom
    c.lineTo(1095, 530);    // right bottom
    c.lineTo(1065, 460);     // right top
    c.closePath();
    c.fill();
    c.stroke();
    // リアランプ左
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(840, 540); // left top
    c.lineTo(840, 565);
    c.lineTo(905, 565);
    c.lineTo(905, 540);
    c.closePath();
    c.fill();
    c.stroke();
    // リアランプ右
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(1045, 540); // left top
    c.lineTo(1045, 565);
    c.lineTo(1110, 565);
    c.lineTo(1110, 540);
    c.closePath();
    c.fill();
    c.stroke();
    // ナンバープレート
    c.beginPath();
    c.moveTo(945, 580); // left top
    c.lineTo(945, 610);
    c.lineTo(1005, 610);
    c.lineTo(1005, 580);
    c.closePath();
    c.stroke();
}

function drawOuterFrontView(c, x, y, w, h) {
    // 左輪
    drawTireFrontView(c, x - 128, y - 65, 64, 44);
    // 右輪
    drawTireFrontView(c, x + 128, y - 65, 64, 44);
    // 外周
    c.lineWidth = 2;
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(x - 100, y - 295);     // left top
    c.lineTo(x - 150, y - 175);     // left side
    c.lineTo(x - 144, y - 45);      // left under
    c.lineTo(x + 144, y - 45);      // right under
    c.lineTo(x + 150, y - 175);     // right side
    c.lineTo(x + 100, y - 295);     // right top
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー左
    c.beginPath();
    c.moveTo(x - 175, y - 230);      // left top
    c.lineTo(x - 175, y - 200);
    c.lineTo(x - 140, y - 200);
    c.lineTo(x - 140, y - 230);
    c.closePath();
    c.fill();
    c.stroke();
    c.beginPath();
    c.moveTo(x - 157, y - 200);      // left top
    c.lineTo(x - 145, y - 186);
    c.lineTo(x - 141, y - 196);
    c.lineTo(x - 145, y - 200);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー右
    c.beginPath();
    c.moveTo(x + 140, y - 230);      // left top
    c.lineTo(x + 140, y - 200);
    c.lineTo(x + 175, y - 200);
    c.lineTo(x + 175, y - 230);
    c.closePath();
    c.fill();
    c.stroke();
    c.beginPath();
    c.moveTo(x + 145, y - 200);      // left top
    c.lineTo(x + 141, y - 196);
    c.lineTo(x + 145, y - 186);
    c.lineTo(x + 157, y - 200);
    c.closePath();
    c.fill();
    c.stroke();
    // 地面
    c.moveTo(x - 205, y);
    c.lineTo(x + 205, y);
    c.stroke();
    // 寸法線
    drawArrowLineHorizontal(c, x - 128, y, x + 128, y + 30, y + 25);    // トレッド前
}

// Draw tire front view
function drawTireFrontView(c, x, y, rad, wid) {
    var l = x - wid / 2;
    var r = x + wid / 2;
    var t = y - rad;
    var b = y + rad;
    var tr = 6; // タイヤの潰れ
    // c.lineWidth = 1;
    c.fillStyle = 'black';
    c.beginPath();
    c.moveTo(l + tr, t);    // left top
    c.quadraticCurveTo(l, t, l, t + tr);
    c.lineTo(l, b - tr);
    c.quadraticCurveTo(l, b, l + tr, b);
    c.lineTo(r - tr, b);
    c.quadraticCurveTo(r, b, r, b - tr);
    c.lineTo(r, t + tr);
    c.quadraticCurveTo(r, t, r - tr, t);
    c.closePath();
    c.fill();
}

function drawTireSideView(c, x, y, tireRad, wheelRad) {
    c.lineWidth = 2;
    c.beginPath();
    c.fillStyle = 'black';
    c.arc(x, y, tireRad, 0, 2 * Math.PI, true);
    c.closePath();
    c.fill();
    c.beginPath();
    c.fillStyle = 'white';
    c.arc(x, y, wheelRad, 0, 2 * Math.PI, true);
    c.closePath();
    c.fill();
}

function drawArrowLineVertical(c, sx, sy, ex, ey, lx) {
    c.lineWidth = 1;
    c.fillStyle = 'black';
    // 寸法補助線上
    c.moveTo(sx, sy);
    c.lineTo(ex, sy);
    c.stroke();
    // 寸法補助線下
    c.moveTo(sx, ey);
    c.lineTo(ex, ey);
    c.stroke();
    // 寸法線
    c.moveTo(lx, sy);
    c.lineTo(lx, ey);
    c.stroke();
    // 矢印開始点
    c.beginPath();
    c.moveTo(lx, sy);
    c.lineTo(lx - 3, sy + 12);
    c.lineTo(lx + 3, sy + 12);
    c.closePath();
    c.fill();
    // 矢印終了点
    c.beginPath();
    c.moveTo(lx, ey);
    c.lineTo(lx - 3, ey - 12);
    c.lineTo(lx + 3, ey - 12);
    c.closePath();
    c.fill();
}

function drawArrowLineHorizontal(c, sx, sy, ex, ey, ly) {
    c.lineWidth = 1;
    c.fillStyle = 'black';
    // 寸法補助線左
    c.moveTo(sx, sy);
    c.lineTo(sx, ey);
    c.stroke();
    // 寸法補助線右
    c.moveTo(ex, sy);
    c.lineTo(ex, ey);
    c.stroke();
    // 寸法線
    c.moveTo(sx, ly);
    c.lineTo(ex, ly);
    c.stroke();
    // 矢印開始点
    c.beginPath();
    c.moveTo(sx, ly);
    c.lineTo(sx + 12, ly + 3);
    c.lineTo(sx + 12, ly - 3);
    c.closePath();
    c.fill();
    // 矢印終了点
    c.beginPath();
    c.moveTo(ex, ly);
    c.lineTo(ex - 12, ly - 3);
    c.lineTo(ex - 12, ly + 3);
    c.closePath();
    c.fill();
}