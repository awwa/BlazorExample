export function drawCar(type, length, width, height,
    wheelBase, treadFront, treadRear, minRoadClearance
) {
    console.log(type);
    var canvas = document.getElementById("car_figure");
    var c = canvas.getContext("2d");

    // パラメータ
    let fxtv = 50;    // フロントX座標 for top view
    let cytv = 200;   // センターY座標 for top view
    let bl = 650;   // 全長（描画座標）
    let bw = 300;   // 全幅（描画座標）
    let bh = 295;   // 全高（描画座標）

    let gysv = 745;   // 地面Y座標 for side view
    let rbytv = cytv - bw / 2;  // right body Y
    let lbytv = cytv + bw / 2;  // left body Y
    let frxsv = fxtv + (bl * 0.48);     // front roof X for side view
    let rrxsv = fxtv + (bl * 0.85);     // rear roof X for side view
    let rysv = gysv - bh;               // roof Y for side view
    let rtxsv = fxtv + bl;              // rear top X for side view
    let rtysv = gysv - (bh * 0.66);     // rear top Y for side view
    let fgbxsv = fxtv + (bl * 0.28)     // front glass bottom X for side view
    let fgbysv = gysv - (bh * 0.66);    // front glass bottom Y for side view
    let fgtxsv = fgbxsv + (frxsv - fgbxsv) * 0.9;   // front glass top X for side view
    let fgtysv = fgbysv - (fgbysv - rysv) * 0.9;    // front glass top Y for side view

    // door mirror
    let ow = 350;   // outer width
    let dml = 20;   // door mirror length
    let dmh = 30;   // door mirror height
    let dmw = 35;   // door mirror width
    let dmfx = fgbxsv + 68;           // door mirror front X
    let dmrx = fgbxsv + 68 + dml;           // door mirror rear X

    let rgtxsv = rrxsv + (rtxsv - rrxsv) * 0.1;     // rear glass top X for side view
    let rgbxsv = rrxsv + (rtxsv - rrxsv) * 0.8;     // rear glass bottom X for side view
    let hltysv = gysv - (bh * 0.50);    // head light top Y for side view
    let hlbysv = gysv - (bh * 0.43);    // head light bottom Y for side view
    let rltysv = gysv - (bh * 0.69);    // rear lamp top Y for side view
    let rlbysv = gysv - (bh * 0.62);    // rear lamp bottom Y for side view
    let rlrxsv = fxtv + bl - 10;        // rear lamp rear X for side view
    let rlfxsv = fxtv + bl - 80;        // rear lamp front X for side view
    let ftcx = fxtv + bl * 0.20;      // front tire center X
    let tcy = gysv - bh * 0.22;       // tire center Y
    let rtcx = fxtv + bl * 0.82;      // rear tire center X

    // Draw top view
    // 外周
    c.fillStyle = 'white';
    c.lineWidth = 2;
    c.beginPath();
    c.moveTo(fxtv + 40, rbytv);   // front right
    c.lineTo(fxtv, cytv - 100);
    c.lineTo(fxtv, cytv + 100);
    c.lineTo(fxtv + 40, lbytv);  // front left
    c.lineTo(fxtv + bl - 60, lbytv); // rear left
    c.lineTo(fxtv + bl, cytv + 90);
    c.lineTo(fxtv + bl, cytv - 90);
    c.lineTo(fxtv + bl - 60, rbytv);  // rear right
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー右
    let rdmytv = cytv - ow / 2;    // right door mirror Y for top view
    let ldmytv = cytv + ow / 2;    // left door mirror Y for top view
    c.beginPath();
    c.moveTo(dmfx, rdmytv);
    c.lineTo(dmfx, rdmytv + dmw);
    c.lineTo(dmrx, rdmytv + dmw);
    c.lineTo(dmrx, rdmytv);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー左
    c.beginPath();
    c.moveTo(dmfx, ldmytv);
    c.lineTo(dmfx, ldmytv - dmw);
    c.lineTo(dmrx, ldmytv - dmw);
    c.lineTo(dmrx, ldmytv);
    c.closePath();
    c.fill();
    c.stroke();
    // フロントガラス
    let fgbw = 240;
    let fgtw = 180;
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(fgbxsv + 40, cytv - fgbw / 2);  // bottom right
    c.lineTo(fgbxsv, cytv - 60);
    c.lineTo(fgbxsv, cytv + 60);
    c.lineTo(fgbxsv + 40, cytv + fgbw / 2); // bottom left
    c.lineTo(fgtxsv + 15, cytv + fgtw / 2); // top left
    c.lineTo(fgtxsv, cytv + 40);
    c.lineTo(fgtxsv, cytv - 40);
    c.lineTo(fgtxsv + 15, cytv - fgtw / 2); // top right
    c.closePath();
    c.fill();
    c.stroke();
    // サイドガラス右
    let sgftx = fgtxsv + 33;   // side glass front top X
    let sgfbx = fgbxsv + 58;   // side glass front bottom X
    let sgrbx = fgbxsv + 318;  // side glass rear bottom X
    let sgrmx = fgbxsv + 348;  // side glass rear middle X
    let sgrtx = fgbxsv + 318;  // side glass rear top X
    let rsgfby = cytv - 130;    // right side glass front bottom Y
    let rsgfty = cytv - 100;    // right side glass front top Y
    let rsgrty = cytv - 100;   // right side glass rear top Y
    let rsgrmy = cytv - 115;   // right side glass rear middle Y
    let rsgrby = cytv - 130;   // right side glass rear bottom Y
    c.beginPath();
    c.moveTo(sgfbx, rsgfby);
    c.lineTo(sgftx, rsgfty);
    c.lineTo(sgrtx, rsgrty);
    c.lineTo(sgrmx, rsgrmy);
    c.lineTo(sgrbx, rsgrby);
    c.closePath();
    c.fill();
    c.stroke();
    // サイドガラス左
    let lsgfby = cytv + 130;    // left side glass front bottom Y
    let lsgfty = cytv + 100;    // left side glass front top Y
    let lsgrty = cytv + 100;   // left side glass rear top Y
    let lsgrmy = cytv + 115;   // left side glass rear middle Y
    let lsgrby = cytv + 130;   // left side glass rear bottom Y
    c.beginPath();
    c.moveTo(sgfbx, lsgfby);
    c.lineTo(sgftx, lsgfty);
    c.lineTo(sgrtx, lsgrty);
    c.lineTo(sgrmx, lsgrmy);
    c.lineTo(sgrbx, lsgrby);
    c.closePath();
    c.fill();
    c.stroke();
    // リアガラス
    let rgbw = 240;
    let rgtw = 180;
    c.beginPath();
    c.moveTo(rgtxsv - 25, cytv - rgtw / 2/*90*/);
    c.lineTo(rgtxsv, cytv - 40);
    c.lineTo(rgtxsv, cytv + 40);
    c.lineTo(rgtxsv - 25, cytv + rgtw / 2/*90*/);
    c.lineTo(rgbxsv - 40, cytv + rgbw / 2/*120*/);
    c.lineTo(rgbxsv, cytv + 70);
    c.lineTo(rgbxsv, cytv - 70);
    c.lineTo(rgbxsv - 40, cytv - rgbw / 2/*120*/);
    c.closePath();
    c.fill();
    c.stroke();
    // 寸法表記
    drawDimensionLineVertical(c, fxtv - 30, rbytv, fxtv + 40, lbytv, fxtv - 25, 'body width'); // 全幅

    // Draw side view
    let mrcy = gysv - (bh * 0.15);    // min road clearance Y
    // 外周
    c.lineWidth = 2;
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(fxtv, gysv - (bh * 0.53));         // grill top
    c.lineTo(fxtv, gysv - (bh * 0.22));         // grill bottom
    c.lineTo(fxtv + (bl * 0.15), mrcy);         // body bottom
    c.lineTo(fxtv + (bl * 0.77), mrcy);         // body bottom
    c.lineTo(fxtv + bl, gysv - (bh * 0.22));    // rear bottom
    c.lineTo(rtxsv, rtysv);                     // rear top
    c.lineTo(rrxsv, rysv);                      // rear roof
    c.lineTo(frxsv, rysv);                      // front roof
    c.lineTo(fgbxsv, fgbysv);                   // front glass bottom
    c.closePath();
    c.fill();
    c.stroke();
    // フロントガラス
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(fgtxsv, fgtysv);       // front glass top
    c.lineTo(fgbxsv, fgbysv);       // front glass bottom
    c.lineTo(fgbxsv + 40, fgbysv);  // front glass bottom
    c.lineTo(fgtxsv + 15, fgtysv);  // front glass top
    c.closePath();
    c.fill();
    c.stroke();
    // サイドガラス
    c.beginPath();
    c.moveTo(sgftx, fgtysv);                // side glass top
    c.lineTo(sgfbx, fgbysv);                // side glass front bottom
    c.lineTo(sgrbx, fgbysv);                // side glass rear bottom
    c.lineTo(sgrmx, (fgtysv + fgbysv) / 2); // side glass under
    c.lineTo(sgrtx, fgtysv);                // side glass rear top
    c.closePath();
    c.fill();
    c.stroke();
    // リアガラス
    c.beginPath();
    c.moveTo(rgtxsv - 25, fgtysv);      // rear glass top
    c.lineTo(rgbxsv - 40, fgbysv - 20); // rear glass bottom
    c.lineTo(rgbxsv, fgbysv - 20);      // rear glass bottom
    c.lineTo(rgtxsv, fgtysv);           // rear glass top
    c.closePath();
    c.fill();
    c.stroke();
    // ヘッドライト
    c.beginPath();
    c.moveTo(fxtv, hltysv);  // front top
    c.lineTo(fxtv, hlbysv);
    c.lineTo(fxtv + 70, hlbysv);
    c.lineTo(fxtv + 70, hltysv);
    c.closePath();
    c.stroke();
    // リアランプ
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(rlrxsv, rltysv);
    c.lineTo(rlrxsv, rlbysv);
    c.lineTo(rlfxsv, rlbysv);
    c.lineTo(rlfxsv, rltysv);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー
    let dmtysv = fgbysv - 35;           // door mirror top Y for side view
    let dmbysv = fgbysv - 35 + dmh;           // door mirror bottom Y for side view
    c.fillStyle = "white";
    c.beginPath();
    c.moveTo(dmfx, dmtysv);
    c.lineTo(dmfx, dmbysv);
    c.lineTo(dmrx, dmbysv);
    c.lineTo(dmrx, dmtysv);
    c.closePath();
    c.fill();
    c.stroke();
    // 前輪
    drawTireSideView(c, ftcx, tcy, 64, 44);
    // 後輪
    drawTireSideView(c, rtcx, tcy, 64, 44);
    // 地面
    c.lineWidth = 2;
    c.moveTo(fxtv - 30, gysv);
    c.lineTo(fxtv + bl + 30, gysv);
    c.stroke();
    // 寸法表記
    drawDimensionLineHorizontal(c, ftcx, gysv, rtcx, gysv + 30, gysv + 25, 'wheelbase');    // ホイールベース
    drawDimensionLineHorizontal(c, fxtv, gysv - (bh * 0.22), fxtv + bl, gysv + 55, gysv + 50, 'body length2');     // 全長
    drawDimensionLineVertical(c, rrxsv, rysv, fxtv + bl + 50, gysv, fxtv + bl + 45, 'body height');      // 全高
    drawDimensionLineVertical(c, fxtv + (bl * 0.15) - 50, mrcy, fxtv + (bl * 0.15) - 20, gysv, fxtv + (bl * 0.15) - 45, 'min body height');      // 最低地上高

    // Draw front view
    let cxfv = 975;     // center X for front view
    let gyfv = 350;     // ground Y for front view
    // 外周
    drawOuterFrontView(c, cxfv, gyfv, bw, bh, dmw, dmh);
    // フロントガラス
    let fgtyfv = fgtysv - (gysv - gyfv);    // front glass top Y for front view
    let fgbyfv = fgbysv - (gysv - gyfv);    // front glass bottom Y for front view
    c.lineWidth = 2;
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(cxfv - fgtw / 2, fgtyfv);  // left top+180
    c.lineTo(cxfv - fgbw / 2, fgbyfv);  // left bottom+240
    c.lineTo(cxfv + fgbw / 2, fgbyfv);  // right bottom
    c.lineTo(cxfv + fgtw / 2, fgtyfv);  // right top
    c.closePath();
    c.fill();
    c.stroke();
    // グリル
    let gw = 150;   // grill width
    let gtyfv = gyfv - (bh * 0.50);    // grill top Y for front view
    let gbyfv = gyfv - (bh * 0.33);    // grill bottom Y for front view
    c.beginPath();
    c.moveTo(cxfv - gw / 2, gtyfv); // left top
    c.lineTo(cxfv - gw / 2, gbyfv);
    c.lineTo(cxfv + gw / 2, gbyfv);
    c.lineTo(cxfv + gw / 2, gtyfv);
    c.closePath();
    c.stroke();
    // ヘッドライト左
    let hlw = 65;                       // head light width
    let lhlxfv = cxfv - 75;             // left head light X for front view
    let hltyfv = gyfv - (bh * 0.50);    // head light top Y for front view
    let hlbyfv = gyfv - (bh * 0.43);    // head light bottom Y for front view
    c.beginPath();
    c.moveTo(lhlxfv - hlw, hltyfv); // left top
    c.lineTo(lhlxfv - hlw, hlbyfv);
    c.lineTo(lhlxfv, hlbyfv);
    c.lineTo(lhlxfv, hltyfv);
    c.closePath();
    c.stroke();
    // ヘッドライト右
    let rhlxfv = cxfv + 75; // right head light X for front view
    c.beginPath();
    c.moveTo(rhlxfv, hltyfv); // left top
    c.lineTo(rhlxfv, hlbyfv);
    c.lineTo(rhlxfv + hlw, hlbyfv);
    c.lineTo(rhlxfv + hlw, hltyfv);
    c.closePath();
    c.stroke();
    // ナンバープレート
    let npw = 60;   // number plate width
    let nph = 30;   // number plate height
    let npbyfv = gyfv - (bh * 0.20); // number plate bottom Y for front view
    c.beginPath();
    c.moveTo(cxfv - npw / 2, npbyfv - nph); // left top
    c.lineTo(cxfv - npw / 2, npbyfv);
    c.lineTo(cxfv + npw / 2, npbyfv);
    c.lineTo(cxfv + npw / 2, npbyfv - nph);
    c.closePath();
    c.stroke();

    // Draw rear view
    // 外周
    drawOuterFrontView(c, cxfv, gysv, bw, bh, dmw, dmh);
    // リアガラス
    c.lineWidth = 2;
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(cxfv - rgtw / 2, fgtysv);      // left top
    c.lineTo(cxfv - rgbw / 2, fgbysv - 20); // left bottom
    c.lineTo(cxfv + rgbw / 2, fgbysv - 20); // right bottom
    c.lineTo(cxfv + rgtw / 2, fgtysv);      // right top
    c.closePath();
    c.fill();
    c.stroke();
    // リアランプ左
    let rlw = 65;           // rear lamp width
    let lrlxrv = cxfv - 70; // left rear lamp X for rear view
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(lrlxrv - rlw, rltysv); // left top
    c.lineTo(lrlxrv - rlw, rlbysv);
    c.lineTo(lrlxrv, rlbysv);
    c.lineTo(lrlxrv, rltysv);
    c.closePath();
    c.fill();
    c.stroke();
    // リアランプ右
    let rrlxrv = cxfv + 70;  // right rear lamp X for rear view
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(rrlxrv, rltysv); // left top
    c.lineTo(rrlxrv, rlbysv);
    c.lineTo(rrlxrv + rlw, rlbysv);
    c.lineTo(rrlxrv + rlw, rltysv);
    c.closePath();
    c.fill();
    c.stroke();
    // ナンバープレート
    let npbyrv = gysv - (bh * 0.46);    // number plate bottom Y for rear view
    c.beginPath();
    c.moveTo(cxfv - npw / 2, npbyrv - nph); // left top
    c.lineTo(cxfv - npw / 2, npbyrv);
    c.lineTo(cxfv + npw / 2, npbyrv);
    c.lineTo(cxfv + npw / 2, npbyrv - nph);
    c.closePath();
    c.stroke();

}

function drawOuterFrontView(c, cx, gy, bw, bh, dmw, dmh) {
    let ow = 350;   // outer width
    // 左輪
    drawTireFrontView(c, cx - 128, gy - 65, 64, 44);
    // 右輪
    drawTireFrontView(c, cx + 128, gy - 65, 64, 44);
    // 外周
    let lrxfv = cx - bw / 2 + 50;    // left roof X for front view
    let lsxfv = cx - bw / 2;         // left side X for front view
    let lbxfv = cx - bw / 2 + 6;     // left bottom X for front view
    let rrxfv = cx + bw / 2 - 50;    // right top X for front view
    let rsxfv = cx + bw / 2;         // right side X for front view
    let rbxfv = cx + bw / 2 - 6;     // right bottom X for front view
    let ryfv = gy - bh;                // roof Y for front view
    let syfv = gy - bh * 0.59;       // side Y for front view
    let byfv = gy - bh * 0.15;     // bottom Y for front view
    c.lineWidth = 2;
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(lrxfv, ryfv);     // left top
    c.lineTo(lsxfv, syfv);     // left side
    c.lineTo(lbxfv, byfv);      // left bottom
    c.lineTo(rbxfv, byfv);      // right bottom
    c.lineTo(rsxfv, syfv);     // right side
    c.lineTo(rrxfv, ryfv);     // right top
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー左
    let fgbyfv = gy - bh * 0.66;    // front glass bottom Y for front view
    let dmtyfv = fgbyfv - 35;       // door mirror top Y for front view
    let dmbyfv = fgbyfv - 35 + dmh; // door mirror bottom Y for front view
    c.beginPath();
    c.moveTo(cx - ow / 2, dmtyfv);      // left top
    c.lineTo(cx - ow / 2, dmbyfv);
    c.lineTo(cx - ow / 2 + dmw, dmbyfv);
    c.lineTo(cx - ow / 2 + dmw, dmtyfv);
    c.closePath();
    c.fill();
    c.stroke();
    c.beginPath();
    c.moveTo(cx - (ow / 2 - dmw * 0.50), dmbyfv);      // left top
    c.lineTo(lsxfv + (lrxfv - lsxfv) * 0.08, syfv + (ryfv - syfv) * 0.08);
    c.lineTo(lsxfv + (lrxfv - lsxfv) * 0.18, syfv + (ryfv - syfv) * 0.18);
    c.lineTo(cx - (ow / 2 - dmw * 0.90), dmbyfv);
    c.closePath();
    c.fill();
    c.stroke();
    // ドアミラー右
    c.beginPath();
    c.moveTo(cx + ow / 2 - dmw, dmtyfv);      // left top
    c.lineTo(cx + ow / 2 - dmw, dmbyfv);
    c.lineTo(cx + ow / 2, dmbyfv);
    c.lineTo(cx + ow / 2, dmtyfv);
    c.closePath();
    c.fill();
    c.stroke();
    c.beginPath();
    c.moveTo(cx + (ow / 2 - dmw * 0.90), dmbyfv);      // left top
    c.lineTo(rsxfv + (rrxfv - rsxfv) * 0.18, syfv + (ryfv - syfv) * 0.18);
    c.lineTo(rsxfv + (rrxfv - rsxfv) * 0.08, syfv + (ryfv - syfv) * 0.08);
    c.lineTo(cx + (ow / 2 - dmw * 0.50), dmbyfv);
    c.closePath();
    c.fill();
    c.stroke();
    // 地面
    c.moveTo(cx - 205, gy);
    c.lineTo(cx + 205, gy);
    c.stroke();
    // 寸法線
    drawDimensionLineHorizontal(c, cx - 128, gy, cx + 128, gy + 30, gy + 25, 'tred');    // トレッド前
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