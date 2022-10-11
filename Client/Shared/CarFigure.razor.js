export function drawCar(type, length, width, height,
    wheelBase, treadFront, treadRear, minRoadClearance
) {
    console.log(type);
    var canvas = document.getElementById("car_figure");
    var c = canvas.getContext("2d");

    // Draw top view
    drawCarTopView(c, type);

    // Draw side view
    drawCarSideView(c, type, 50, 745, 650, 295);

    // Draw front view
    drawCarFrontView(c, type);

    // Draw rear view
    drawCarRearView(c, type);
}

function drawCarTopView(c, type) {
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
    // サイドガラス右
    c.beginPath();
    c.moveTo(290, 70);
    c.lineTo(380, 100);
    c.lineTo(550, 100);
    c.lineTo(580, 85);
    c.lineTo(550, 70);
    c.closePath();
    c.fill();
    c.stroke();
    // サイドガラス左
    c.beginPath();
    c.moveTo(290, 330);
    c.lineTo(380, 300);
    c.lineTo(550, 300);
    c.lineTo(580, 315);
    c.lineTo(550, 330);
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
    drawDimensionLineVertical(c, 20, 50, 100, 350, 30, 'body width'); // 全幅
}

// fx: フロントX座標
// bl: 長さ（描画座標）
// gy: 地面Y座標
// bh: 高さ（描画座標）
// rc: 最低地上高（描画座標）
function drawCarSideView(c, type, fx, gy, bl, bh) {
    // ガイドライン
    // c.lineWidth = 2;
    // c.moveTo(0, 480);
    // c.lineTo(800, 480);
    // c.stroke();
    // 外周
    let frx = fx + (bl * 0.48);     // front roof X
    let rrx = fx + (bl * 0.85);     // rear roof X
    let ry = gy - bh;               // roof Y
    let fgbx = fx + (bl * 0.28)     // front glass bottom X
    let fgby = gy - (bh * 0.66);    // front glass bottom Y
    let rtx = fx + bl;              // rear top X
    let rty = gy - (bh * 0.66);     // rear top Y
    c.lineWidth = 2;
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(fx, gy - (bh * 0.53));             // grill top
    c.lineTo(fx, gy - (bh * 0.22));             // grill bottom
    c.lineTo(fx + (bl * 0.15), gy - (bh * 0.15));  // body bottom
    c.lineTo(fx + (bl * 0.77), gy - (bh * 0.15));  // body bottom
    c.lineTo(fx + bl, gy - (bh * 0.22));        // rear bottom
    c.lineTo(rtx, rty);                         // rear top
    c.lineTo(rrx, ry);                          // rear roof
    c.lineTo(frx, ry);                          // front roof
    c.lineTo(fgbx, fgby);                       // front glass bottom
    c.closePath();
    c.fill();
    c.stroke();
    // フロントガラス
    let fgtx = fgbx + (frx - fgbx) * 0.9;   // front glass top X
    let fgty = fgby - (fgby - ry) * 0.9;    // front glass top Y
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(fgtx, fgty);       // front glass top
    c.lineTo(fgbx, fgby);       // front glass bottom
    c.lineTo(fgbx + 40, fgby);  // front glass bottom
    c.lineTo(fgtx + 15, fgty);  // front glass top
    c.closePath();
    c.fill();
    c.stroke();
    // サイドガラス
    c.beginPath();
    c.moveTo(fgtx + 33, fgty);                  // side glass top
    c.lineTo(fgbx + 58, fgby);                  // side glass front bottom
    c.lineTo(fgbx + 318, fgby);                 // side glass rear bottom
    c.lineTo(fgbx + 348, (fgty + fgby) / 2);    // side glass under
    c.lineTo(fgbx + 318, fgty);                 // side glass rear top
    c.closePath();
    c.fill();
    c.stroke();
    // リアガラス
    let rgtx = rrx + (rtx - rrx) * 0.1; // rear glass top X
    let rgbx = rrx + (rtx - rrx) * 0.8; // rear glass bottom X
    c.beginPath();
    c.moveTo(rgtx - 25, fgty);      // rear glass top
    c.lineTo(rgbx - 40, fgby - 20); // rear glass bottom
    c.lineTo(rgbx, fgby - 20);      // rear glass bottom
    c.lineTo(rgtx, fgty);           // rear glass top
    c.closePath();
    c.fill();
    c.stroke();
    // ヘッドライト
    let hlty = gy - (bh * 0.50); // head light top Y
    let hlby = gy - (bh * 0.43); // head light bottom Y
    c.beginPath();
    c.moveTo(fx, hlty);  // front top
    c.lineTo(fx, hlby);
    c.lineTo(fx + 70, hlby);
    c.lineTo(fx + 70, hlty);
    c.closePath();
    c.stroke();
    // リアランプ
    let rlty = gy - (bh * 0.69); // rear lamp top Y
    let rlby = gy - (bh * 0.62); // rear lamp bottom Y
    let rlrx = fx + bl - 10;    // rear lamp rear X
    let rlfx = fx + bl - 80;    // rear lamp front X
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(rlrx, rlty);
    c.lineTo(rlrx, rlby);
    c.lineTo(rlfx, rlby);
    c.lineTo(rlfx, rlty);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー
    let dmfx = fgbx + 68;   // door mirror front X
    let dmty = fgby - 20;   // door mirror top Y
    let dmrx = fgbx + 88;  // door mirror rear X
    let dmby = fgby + 10;   // door mirror bottom Y
    c.fillStyle = "white";
    c.beginPath();
    c.moveTo(dmfx, dmty);
    c.lineTo(dmfx, dmby);
    c.lineTo(dmrx, dmby);
    c.lineTo(dmrx, dmty);
    c.closePath();
    c.fill();
    c.stroke();
    // 前輪
    let ftcx = fx + bl * 0.20;   // front tire center X
    let tcy = gy - bh * 0.22;   // tire center Y
    drawTireSideView(c, ftcx, tcy, 64, 44);
    // 後輪
    let rtcx = fx + bl * 0.82;   // rear tire center X
    drawTireSideView(c, rtcx, tcy, 64, 44);
    // 地面
    c.lineWidth = 2;
    c.moveTo(fx - 30, gy);
    c.lineTo(fx + bl + 30, gy);
    c.stroke();
    // 寸法表記
    drawDimensionLineHorizontal(c, ftcx, gy, rtcx, gy + 30, gy + 25, 'wheelbase');    // ホイールベース
    drawDimensionLineHorizontal(c, fx, gy - (bh * 0.22), fx + bl, gy + 55, gy + 50, 'body length2');     // 全長
    drawDimensionLineVertical(c, rrx, ry, fx + bl + 50, gy, fx + bl + 45, 'body height');      // 全高
    drawDimensionLineVertical(c, fx + (bl * 0.15) - 50, gy - (bh * 0.15), fx + (bl * 0.15) - 20, gy, fx + (bl * 0.15) - 45, 'min body height');      // 最低地上高
}


function drawCarFrontView(c, type) {
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

function drawCarRearView(c, type) {
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
    drawDimensionLineHorizontal(c, x - 128, y, x + 128, y + 30, y + 25, 'tred');    // トレッド前
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

function drawDimensionLineVertical(c, sx, sy, ex, ey, lx, text) {
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
    // 寸法
    c.textAlign = 'center';
    c.font = '16px sans-serif';
    c.translate(lx, (sy + ey) / 2);
    c.rotate(-Math.PI / 2);
    c.fillText(text, 0, -4);
    c.rotate(Math.PI / 2);
    c.translate(-lx, -(sy + ey) / 2);
}

function drawDimensionLineHorizontal(c, sx, sy, ex, ey, ly, text) {
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
    // 寸法
    c.textAlign = 'center';
    c.font = '16px sans-serif';
    c.fillText(text, (sx + ex) / 2, ly - 4);
}