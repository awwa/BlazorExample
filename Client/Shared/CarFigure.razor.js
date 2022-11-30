export function drawCar(type, length, width, height,
    wheelBase, treadFront, treadRear, minRoadClearance
) {
    var canvas = document.getElementById("car_figure");
    var c = canvas.getContext("2d");
    c.clearRect(0, 0, canvas.width, canvas.height);

    // values
    let value = {
        length: length,
        width: width,
        height: height,
        wheelBase: wheelBase,
        treadFront: treadFront,
        treadRear: treadRear,
        minRoadClearance: minRoadClearance,
    };

    // パラメータ
    let param = {
        // body
        lB: 675,    // length body
        wRf: 200,   // width roof
        wB: 300,    // width body
        wR: 180,    // width rear
        hBm: 145,   // height body middle
        wBb: 288,   // height body bottom
        // roof
        hFgb: 160,  // height front glass bottom
        hRf: 245,   // height Roof
        hRgb: 180,  // height rear glass bottom
        hRt: 160,   // height rear top
        // road clearance
        hRcGb: 50, // height road clearance grill bottom
        hRc: 37,   // height road clearance
        hRcRb: 50, // height road clearance rear bottom
        // front set back
        fsbF: 40,  // front set back front
        fsbRf: 320, // front set back roof
        fsbFgb: 190,// front set back glass bottom
        fsbGt: 0, // front set back grill top
        fsbGb: 0, // front set back grill bottom
        // rear set back
        rsbR: 60,   // rear set back rear
        rsbRf: 100, // rear set back roof
        rsbRgb: 25,// rear set back glass bottom
        rsbRt: 999, // rear set back rear top
        rsbRb: 999, // rear set back rear bottom
        // door mirror
        wO: 350,    // width outer
        wDm: 35,    // width door mirror
        lDm: 20,    // length door mirror
        hDm: 30,    // height door mirror
        hDmt: 170,   // height door mirror top
        fsbDm: 260, // front set back door mirror
        // glass
        tRf: 8,    // thickness roof
        // front glass
        lFgt: 20,  // length front glass top
        lFgb: 40,  // length front glass bottom
        wFgt1: 80, // width front glass top 1
        wFgt2: 180, // width front glass top 2
        wFgb1: 120, // width front glass bottom 1
        wFgb2: 240, // width front glass bottom 2
        // A pillar
        lApt: 18,  // length A pillar top
        lApb: 18,  // length A pillar bottom
        // side glass
        lSgt: 280,  // length side glass top
        lSgm: 290,  // length side glass middle
        lSgb: 260,  // length side glass bottom
        wSgt: 200,  // width side glass top
        wSgb: 260,  // width side glass bottom
        hSgm: 200,  // height side glass middle
        // C pillar
        lCpt: 50,  // length C pillar top
        lCpb: 105,  // length C pillar bottom
        // rear glass
        wRgt1: 80, // width rear glass top 1
        wRgt2: 180, // width rear glass top 2
        wRgb1: 140, // width rear glass bottom 1
        wRgb2: 240, // width rear glass bottom 2
        // tire
        rT: 54,    // radius tire
        rW: 36,    // radius wheel
        wT: 44,    // width tire
        wTr: 256,   // width tread
        fsbFt: 135, // front set back front tire
        lWb: 400,   // length wheel base
        // grill
        wG: 150,    // width grill
        hG: 60,    // height grill
        hGt: 130,   // height grill top
        // head lamp
        wHl: 66,   // width head lamp
        hHl: 16,   // height head lamp
        hHlt: 120,  // height head lamp top
        // rear lamp
        wRl: 66,   // width rear lamp
        wIRl: 140,  // width inter rear lamp
        hRl: 16,   // height rear lamp
        hRlt: 150,  // height rear lamp top
        // number plate
        hNp: 30,   // height number plate
        wNp: 60,   // width number plate
        hFnpt: 80,  // height front number plate top
        hRnpt: 140,  // height rear number plate top
    }

    switch (type) {
        case "SEDAN":
        case "COUPE":
            // rear set back
            param.rsbRf = 170;
            param.rsbRgb = 70;
            // side glass
            param.lSgt = 250;
            param.lSgm = 270;
            param.lSgb = 310;
            // C pillar
            param.lCpt = 20;
            param.lCpb = 10;
            break;
        case "HATCHBACK":
            // body
            param.lB = 650;
            // front set back
            param.fsbRf = 310;
            param.fsbFgb = 182;
            // door mirror
            param.fsbDm = 250;
            // C pillar
            param.lCpt = 40;
            param.lCpb = 90;
            break;
        case "SUV":
            // body
            param.lB = 650;
            param.hBm = 170;
            param.hRgb = 215;
            // roof
            param.hFgb = 195;
            param.hRf = 295;
            param.hRt = 195;
            // road clearance
            param.hRcGb = 64;
            param.hRc = 44;
            param.hRcRb = 64;
            // front set back
            param.fsbRf = 310;
            param.fsbFgb = 182;
            // rear set back
            param.rsbRgb = 20;
            // door mirror
            param.hDmt = 200;
            param.fsbDm = 250;
            // front glass
            param.lFgt = 14;
            // side glass
            param.hSgm = 240;
            // C pillar
            param.lCpt = 40;
            param.lCpb = 90;
            // tire
            param.rT = 64;
            param.rW = 44;
            // grill
            param.hGt = 158;
            // head lamp
            param.hHl = 20;
            param.hHlt = 145;
            // rear lamp
            param.hRl = 20;
            param.hRlt = 185;
            // number plate
            param.hFnpt = 90;
            param.hRnpt = 166;
            break;
        case "CROSS_COUNTRY":
            // body
            param.lB = 675;
            param.wR = 230;
            param.hBm = 170;
            // roof
            param.hFgb = 195;
            param.hRf = 295;
            param.hRgb = 195;
            param.hRt = 195;
            // road clearance
            param.hRcGb = 50;
            param.hRc = 44;
            param.hRcRb = 50;
            // front set back
            param.fsbRf = 310;
            param.fsbFgb = 182;
            // rear set back
            param.rsbR = 30;
            param.rsbRf = 30;
            param.rsbRgb = 0;
            // door mirror
            param.hDmt = 200;
            param.fsbDm = 250;
            // front glass
            param.lFgt = 14;
            // side glass
            param.lSgt = 385;
            param.lSgm = 370;
            param.lSgb = 380;
            param.hSgm = 240;
            // C pillar
            param.lCpt = 20;
            param.lCpb = 20;
            // tire
            param.rT = 64;
            param.rW = 44;
            // grill
            param.hG = 80;
            param.hGt = 175;
            // head lamp
            param.hHl = 25;
            param.hHlt = 145;
            // rear lamp
            param.hRl = 25;
            param.hRlt = 185;
            // number plate
            param.hFnpt = 90;
            param.hRnpt = 166;
            break;
        case "ONEBOX":
            // body
            param.lB = 675;
            param.wR = 230;
            param.hBm = 170;
            // roof
            param.hFgb = 195;
            param.hRf = 295;
            param.hRgb = 195;
            param.hRt = 195;
            // road clearance
            param.hRcGb = 44;
            param.hRc = 44;
            param.hRcRb = 44;
            // front set back
            param.fsbRf = 200;
            param.fsbFgb = 70;
            // rear set back
            param.rsbR = 30;
            param.rsbRf = 20;
            param.rsbRgb = 0;
            // door mirror
            param.hDmt = 200;
            param.fsbDm = 140;
            // front glass
            param.lFgt = 14;
            // side glass
            param.lSgt = 505;
            param.lSgm = 483;
            param.lSgb = 485;
            param.hSgm = 240;
            // C pillar
            param.lCpt = 20;
            param.lCpb = 20;
            // grill
            param.hG = 80;
            param.hGt = 170;
            // head lamp
            param.hHl = 25;
            param.hHlt = 145;
            // rear lamp
            param.hRl = 25;
            param.hRlt = 185;
            // number plate
            param.hFnpt = 90;
            param.hRnpt = 166;
            break;
        case "OPEN":
        case "K_OPEN":
            // body
            param.hBm = 130;
            // roof
            param.hFgb = 140;
            param.hRf = 220;
            param.hRgb = 150;
            param.hRt = 140;
            // road clearance
            param.hRcGb = 37;
            // front set back
            param.fsbF = 60;
            param.fsbRf = 390;
            param.fsbFgb = 260;
            // rear set back
            param.rsbRf = 200;
            param.rsbRgb = 110;
            // door mirror
            param.hDmt = 145;
            param.fsbDm = 320;
            // side glass
            param.lSgt = 155;
            param.lSgm = 160;
            param.lSgb = 150;
            param.hSgm = 180;
            // C pillar
            param.lCpt = 30;
            param.lCpb = 97;
            // rear glass
            param.wRgt2 = 140;
            param.wRgb1 = 100;
            param.wRgb2 = 180;
            // grill
            param.hGt = 110;
            // head lamp
            param.hHlt = 110;
            // rear lamp
            param.hRlt = 130;
            // number plate
            param.hFnpt = 65;
            param.hRnpt = 100;
            break;
        case "PICKUP_TRUCK":
            // body
            param.lB = 675;
            param.wRf = 260;
            param.wR = 230;
            param.hBm = 170;
            param.wBb = 300;
            // roof
            param.hFgb = 195;
            param.hRf = 295;
            param.hRgb = 195;
            param.hRt = 195;
            // road clearance
            param.hRcGb = 64;
            param.hRc = 64;
            param.hRcRb = 64;
            // front set back
            param.fsbF = 60;
            // rear set back
            param.rsbR = 0;
            param.rsbRf = 200;
            param.rsbRgb = 200;
            // door mirror
            param.hDmt = 200;
            // front glass
            param.wFgt2 = 220;
            // side glass
            param.lSgt = 230;
            param.lSgm = 210;
            param.lSgb = 210;
            param.wSgt = 240;
            // C pillar
            param.lCpt = 17;
            param.lCpb = 17;
            // tire
            param.rT = 64;
            param.rW = 44;
            // grill
            param.hG = 80;
            param.hGt = 170;
            // head lamp
            param.hHl = 25;
            param.hHlt = 155;
            // rear lamp
            param.hRl = 25;
            param.hRlt = 180;
            // number plate
            param.hFnpt = 100;
            break;
        case "K":
            // body
            param.wRf = 260;
            param.lB = 540;
            param.wBb = 300;
            // roof
            param.hFgb = 170;
            param.hRf = 265;
            // road clearance
            param.hRcGb = 40;
            param.hRcRb = 40;
            // front set back
            param.fsbF = 30;
            param.fsbRf = 210;
            param.fsbFgb = 100;
            // rear set back
            param.rsbR = 30;
            param.rsbRf = 40;
            param.rsbRgb = 6;
            // door mirror
            param.hDmt = 180;
            param.fsbDm = 170;
            // front glass
            param.wFgt2 = 250;
            param.wFgb2 = 280;
            // side glass
            param.lSgt = 330;
            param.lSgm = 330;
            param.lSgb = 330;
            param.wSgt = 260;
            param.wSgb = 290;
            // rear glass
            param.wRgt2 = 250;
            param.wRgb2 = 280;
            // C pillar
            param.lCpt = 25;
            param.lCpb = 25;
            // head lamp
            param.hHl = 30;
            param.hHlt = 155;
            // rear lamp
            param.hRl = 30;
            // tire
            param.fsbFt = 70;
            // grill
            param.hGt = 160;
            break;
        case "K_ONEBOX":
            // body
            param.wRf = 260;
            param.lB = 540;
            param.wBb = 300;
            // roof
            param.hFgb = 170;
            param.hRf = 265;
            // road clearance
            param.hRcGb = 40;
            param.hRcRb = 40;
            // front set back
            param.fsbF = 30;
            param.fsbRf = 150;
            param.fsbFgb = 100;
            // rear set back
            param.rsbR = 30;
            param.rsbRf = 10;
            param.rsbRgb = 2;
            // door mirror
            param.hDmt = 180;
            param.fsbDm = 150;
            // front glass
            param.wFgt2 = 250;
            param.wFgb2 = 280;
            // side glass
            param.lSgt = 368;
            param.lSgm = 355;
            param.lSgb = 355;
            param.wSgt = 260;
            param.wSgb = 290;
            // rear glass
            param.wRgt2 = 200;
            param.wRgb2 = 200;
            // C pillar
            param.lCpt = 25;
            param.lCpb = 25;
            // head lamp
            param.hHl = 30;
            param.hHlt = 155;
            // rear lamp
            param.hRl = 30;
            // tire
            param.fsbFt = 70;
            // grill
            param.hGt = 160;
            break;
    }

    drawTopView(c, param, value);
    drawSideView(c, param, value);
    drawFrontView(c, param, value);
    drawRearView(c, param, value);

}

function drawTopView(c, p, v) {
    let ox = 50;    // origin X
    let oy = 200;   // origin Y
    c.lineWidth = 1;
    c.strokeStyle = 'black';

    // body
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.fsbF, oy - p.wB / 2);
    c.lineTo(ox, oy - p.wG / 2);
    c.lineTo(ox, oy + p.wG / 2);
    c.lineTo(ox + p.fsbF, oy + p.wB / 2);
    c.lineTo(ox + p.lB - p.rsbR, oy + p.wB / 2);
    c.lineTo(ox + p.lB, oy + p.wR / 2);
    c.lineTo(ox + p.lB, oy - p.wR / 2);
    c.lineTo(ox + p.lB - p.rsbR, oy - p.wB / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // right door mirror
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.fsbDm, oy - p.wO / 2);
    c.lineTo(ox + p.fsbDm, oy - p.wO / 2 + p.wDm);
    c.lineTo(ox + p.fsbDm + p.lDm, oy - p.wO / 2 + p.wDm);
    c.lineTo(ox + p.fsbDm + p.lDm, oy - p.wO / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // left door mirror
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.fsbDm, oy + p.wO / 2);
    c.lineTo(ox + p.fsbDm, oy + p.wO / 2 - p.wDm);
    c.lineTo(ox + p.fsbDm + p.lDm, oy + p.wO / 2 - p.wDm);
    c.lineTo(ox + p.fsbDm + p.lDm, oy + p.wO / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // front glass
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(ox + p.fsbFgb + p.lFgb, oy - p.wFgb2 / 2);
    c.lineTo(ox + p.fsbFgb, oy - p.wFgb1 / 2);
    c.lineTo(ox + p.fsbFgb, oy + p.wFgb1 / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgb, oy + p.wFgb2 / 2);
    let fsbFgt1 = p.fsbFgb + (p.fsbRf - p.fsbFgb) * (p.hRf - p.hFgb - p.tRf) / (p.hRf - p.hFgb);
    c.lineTo(ox + fsbFgt1 + p.lFgt, oy + p.wFgt2 / 2);
    c.lineTo(ox + fsbFgt1, oy + p.wFgt1 / 2);
    c.lineTo(ox + fsbFgt1, oy - p.wFgt1 / 2);
    c.lineTo(ox + fsbFgt1 + p.lFgt, oy - p.wFgt2 / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // right side glass
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(ox + p.fsbFgb + p.lFgb + p.lApb, oy - p.wSgb / 2);
    c.lineTo(ox + fsbFgt1 + p.lFgt + p.lApt, oy - p.wSgt / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgt + p.lApt + p.lSgt, oy - p.wSgt / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgm, oy - (p.wSgb + p.wSgt) / 4);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgb, oy - p.wSgb / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // left side glass
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(ox + p.fsbFgb + p.lFgb + p.lApb, oy + p.wSgb / 2);
    c.lineTo(ox + fsbFgt1 + p.lFgt + p.lApt, oy + p.wSgt / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgt + p.lApt + p.lSgt, oy + p.wSgt / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgm, oy + (p.wSgb + p.wSgt) / 4);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgb, oy + p.wSgb / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // rear glass
    c.fillStyle = 'lightgray';
    let rsbRgt1 = p.rsbRgb + (p.rsbRf - p.rsbRgb) * (p.hRf - p.hRgb - p.tRf) / (p.hRf - p.hRgb);
    c.beginPath();
    c.moveTo(ox + p.fsbFgb + p.lFgt + p.lApt + p.lSgt + p.lCpt, oy - p.wRgt2 / 2);
    c.lineTo(ox + p.lB - rsbRgt1, oy - p.wRgt1 / 2);
    c.lineTo(ox + p.lB - rsbRgt1, oy + p.wRgt1 / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgt + p.lApt + p.lSgt + p.lCpt, oy + p.wRgt2 / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgb + p.lCpb, oy + p.wRgb2 / 2);
    c.lineTo(ox + p.lB - p.rsbRgb, oy + p.wRgb1 / 2);
    c.lineTo(ox + p.lB - p.rsbRgb, oy - p.wRgb1 / 2);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgb + p.lCpb, oy - p.wRgb2 / 2);
    c.closePath();
    c.fill();
    c.stroke();

    // 寸法表記
    drawDimensionLineVertical(c, ox - 30, oy - p.wB / 2, ox + p.fsbF, oy + p.wB / 2, ox - 25, `${v.width}mm`); // 全幅
}

function drawSideView(c, p, v) {
    let ox = 50;    // origin X
    let oy = 745;   // origin Y
    c.lineWidth = 1;
    c.strokeStyle = 'black';

    // body
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.fsbGb, oy - p.hRcGb);
    c.lineTo(ox + p.fsbFt, oy - p.hRc);
    c.lineTo(ox + p.fsbFt + p.lWb, oy - p.hRc);
    c.lineTo(ox + p.lB, oy - p.hRcRb);
    c.lineTo(ox + p.lB, oy - p.hRt);
    c.lineTo(ox + p.lB - p.rsbRgb, oy - p.hRgb);
    c.lineTo(ox + p.lB - p.rsbRf, oy - p.hRf);
    c.lineTo(ox + p.fsbRf, oy - p.hRf);
    c.lineTo(ox + p.fsbFgb, oy - p.hFgb);
    c.lineTo(ox + p.fsbGt, oy - p.hGt);
    c.closePath();
    c.fill();
    c.stroke();

    // front glass
    c.fillStyle = 'lightgray';
    let fsbFgt1 = p.fsbFgb + (p.fsbRf - p.fsbFgb) * (p.hRf - p.hFgb - p.tRf) / (p.hRf - p.hFgb);
    c.beginPath();
    c.moveTo(ox + fsbFgt1, oy - p.hRf + p.tRf);
    c.lineTo(ox + p.fsbFgb, oy - p.hFgb);
    c.lineTo(ox + p.fsbFgb + p.lFgb, oy - p.hFgb);
    c.lineTo(ox + fsbFgt1 + p.lFgt, oy - p.hRf + p.tRf);
    c.closePath();
    c.fill();
    c.stroke();

    // side glass
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(ox + fsbFgt1 + p.lFgt + p.lApt, oy - p.hRf + p.tRf);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb, oy - p.hFgb);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgb, oy - p.hFgb);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgm, oy - p.hSgm);
    c.lineTo(ox + p.fsbFgb + p.lFgt + p.lApt + p.lSgt, oy - p.hRf + p.tRf);
    c.closePath();
    c.fill();
    c.stroke();

    // rear glass
    c.fillStyle = 'lightgray';
    let rsbRgt1 = p.rsbRgb + (p.rsbRf - p.rsbRgb) * (p.hRf - p.hRgb - p.tRf) / (p.hRf - p.hRgb);
    c.beginPath();
    c.moveTo(ox + p.lB - rsbRgt1, oy - p.hRf + p.tRf);
    c.lineTo(ox + p.fsbFgb + p.lFgt + p.lApt + p.lSgt + p.lCpt, oy - p.hRf + p.tRf);
    c.lineTo(ox + p.fsbFgb + p.lFgb + p.lApb + p.lSgb + p.lCpb, oy - p.hRgb);
    c.lineTo(ox + p.lB - p.rsbRgb, oy - p.hRgb);
    c.closePath();
    c.fill();
    c.stroke();

    // door mirror
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.fsbDm, oy - p.hDmt);
    c.lineTo(ox + p.fsbDm, oy - p.hDmt - p.hDm);
    c.lineTo(ox + p.fsbDm + p.lDm, oy - p.hDmt - p.hDm);
    c.lineTo(ox + p.fsbDm + p.lDm, oy - p.hDmt);
    c.closePath();
    c.fill();
    c.stroke();

    // head lamp
    c.beginPath();
    c.moveTo(ox, oy - p.hHlt);
    c.lineTo(ox, oy - p.hHlt + p.hHl);
    c.lineTo(ox + p.fsbF, oy - p.hHlt + p.hHl);
    c.lineTo(ox + p.fsbF, oy - p.hHlt);
    c.closePath();
    c.stroke();

    // rear lamp
    c.fillStyle = "darkred";
    c.beginPath();
    c.moveTo(ox + p.lB, oy - p.hRlt);
    c.lineTo(ox + p.lB - p.rsbR, oy - p.hRlt);
    c.lineTo(ox + p.lB - p.rsbR, oy - p.hRlt + p.hRl);
    c.lineTo(ox + p.lB, oy - p.hRlt + p.hRl);
    c.closePath();
    c.fill();
    c.stroke();

    // ground
    c.beginPath();
    c.moveTo(ox - 30, oy);
    c.lineTo(ox + p.lB + 30, oy);
    c.closePath();
    c.stroke();

    // 寸法表記
    drawDimensionLineHorizontal(c, ox + p.fsbFt, oy, ox + p.fsbFt + p.lWb, oy + 30, oy + 25, `${v.wheelBase}mm`);    // ホイールベース
    drawDimensionLineHorizontal(c, ox, oy - p.hRcGb, ox + p.lB, oy + 55, oy + 50, `${v.length}mm`);     // 全長
    drawDimensionLineVertical(c, ox + p.lB - p.rsbRf, oy - p.hRf, ox + p.lB + 55, oy, ox + p.lB + 45, `${v.height}mm`);      // 全高
    drawDimensionLineVertical(c, ox + p.fsbFt - 70, oy - p.hRc, ox + p.fsbFt, oy, ox + p.fsbFt - 65, `${v.minRoadClearance}mm`);      // 最低地上高

    // front tire
    drawTireSideView(c, ox + p.fsbFt, oy - p.rT, p.rT, p.rW);

    // rear tire
    drawTireSideView(c, ox + p.fsbFt + p.lWb, oy - p.rT, p.rT, p.rW);
}

function drawFrontView(c, p) {
    let ox = 1000;  // origin X
    let oy = 350;   // origin Y
    c.lineWidth = 1;
    c.strokeStyle = 'black';

    drawOuterFrontView2(c, p, ox, oy);

    // front glass
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(ox - p.wFgt2 / 2, oy - p.hRf + p.tRf);
    c.lineTo(ox - p.wFgb2 / 2, oy - p.hFgb);
    c.lineTo(ox + p.wFgb2 / 2, oy - p.hFgb);
    c.lineTo(ox + p.wFgt2 / 2, oy - p.hRf + p.tRf);
    c.closePath();
    c.fill();
    c.stroke();

    // grill
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox - p.wG / 2, oy - p.hGt);
    c.lineTo(ox - p.wG / 2, oy - p.hGt + p.hG);
    c.lineTo(ox + p.wG / 2, oy - p.hGt + p.hG);
    c.lineTo(ox + p.wG / 2, oy - p.hGt);
    c.closePath();
    c.fill();
    c.stroke();

    // right head lamp
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox - p.wG / 2, oy - p.hHlt);
    c.lineTo(ox - p.wG / 2 - p.wHl, oy - p.hHlt);
    c.lineTo(ox - p.wG / 2 - p.wHl, oy - p.hHlt + p.hHl);
    c.lineTo(ox - p.wG / 2, oy - p.hHlt + p.hHl);
    c.closePath();
    c.fill();
    c.stroke();

    // left head lamp
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.wG / 2, oy - p.hHlt);
    c.lineTo(ox + p.wG / 2 + p.wHl, oy - p.hHlt);
    c.lineTo(ox + p.wG / 2 + p.wHl, oy - p.hHlt + p.hHl);
    c.lineTo(ox + p.wG / 2, oy - p.hHlt + p.hHl);
    c.closePath();
    c.fill();
    c.stroke();

    // number plate
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox - p.wNp / 2, oy - p.hFnpt);
    c.lineTo(ox - p.wNp / 2, oy - p.hFnpt + p.hNp);
    c.lineTo(ox + p.wNp / 2, oy - p.hFnpt + p.hNp);
    c.lineTo(ox + p.wNp / 2, oy - p.hFnpt);
    c.closePath();
    c.fill();
    c.stroke();
}

function drawRearView(c, p) {
    let ox = 1000;  // origin X
    let oy = 745;   // origin Y
    c.lineWidth = 1;
    c.strokeStyle = 'black';

    drawOuterFrontView2(c, p, ox, oy);

    // rear glass
    c.fillStyle = 'lightgray';
    c.beginPath();
    c.moveTo(ox - p.wRgt2 / 2, oy - p.hRf + p.tRf);
    c.lineTo(ox - p.wRgb2 / 2, oy - p.hRgb);
    c.lineTo(ox + p.wRgb2 / 2, oy - p.hRgb);
    c.lineTo(ox + p.wRgt2 / 2, oy - p.hRf + p.tRf);
    c.closePath();
    c.fill();
    c.stroke();

    // right rear lamp
    c.fillStyle = 'darkred';
    c.beginPath();
    c.moveTo(ox - p.wIRl / 2, oy - p.hRlt);
    c.lineTo(ox - p.wIRl / 2 - p.wRl, oy - p.hRlt);
    c.lineTo(ox - p.wIRl / 2 - p.wRl, oy - p.hRlt + p.hRl);
    c.lineTo(ox - p.wIRl / 2, oy - p.hRlt + p.hRl);
    c.closePath();
    c.fill();
    c.stroke();

    // left rear lamp
    c.fillStyle = 'darkred';
    c.beginPath();
    c.moveTo(ox + p.wIRl / 2, oy - p.hRlt);
    c.lineTo(ox + p.wIRl / 2 + p.wRl, oy - p.hRlt);
    c.lineTo(ox + p.wIRl / 2 + p.wRl, oy - p.hRlt + p.hRl);
    c.lineTo(ox + p.wIRl / 2, oy - p.hRlt + p.hRl);
    c.closePath();
    c.fill();
    c.stroke();

    // number plate
    c.beginPath();
    c.moveTo(ox - p.wNp / 2, oy - p.hRnpt);
    c.lineTo(ox - p.wNp / 2, oy - p.hRnpt + p.hNp);
    c.lineTo(ox + p.wNp / 2, oy - p.hRnpt + p.hNp);
    c.lineTo(ox + p.wNp / 2, oy - p.hRnpt);
    c.closePath();
    c.stroke();
}

function drawOuterFrontView2(c, p, ox, oy) {
    // right tire
    drawTireFrontView(c, ox - p.wTr / 2, oy - p.rT, p.rT, p.wT);

    // left tire
    drawTireFrontView(c, ox + p.wTr / 2, oy - p.rT, p.rT, p.wT);

    // body
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox - p.wRf / 2, oy - p.hRf);
    c.lineTo(ox - p.wB / 2, oy - p.hBm);
    c.lineTo(ox - p.wBb / 2, oy - p.hRc);
    c.lineTo(ox + p.wBb / 2, oy - p.hRc);
    c.lineTo(ox + p.wB / 2, oy - p.hBm);
    c.lineTo(ox + p.wRf / 2, oy - p.hRf);
    c.closePath();
    c.fill();
    c.stroke();

    // right door mirror
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox - p.wO / 2, oy - p.hDmt);
    c.lineTo(ox - p.wO / 2, oy - p.hDmt - p.hDm);
    c.lineTo(ox - p.wO / 2 + p.wDm, oy - p.hDmt - p.hDm);
    c.lineTo(ox - p.wO / 2 + p.wDm, oy - p.hDmt);
    c.closePath();
    c.fill();
    c.stroke();

    // left door mirror
    c.fillStyle = 'white';
    c.beginPath();
    c.moveTo(ox + p.wO / 2, oy - p.hDmt);
    c.lineTo(ox + p.wO / 2, oy - p.hDmt - p.hDm);
    c.lineTo(ox + p.wO / 2 - p.wDm, oy - p.hDmt - p.hDm);
    c.lineTo(ox + p.wO / 2 - p.wDm, oy - p.hDmt);
    c.closePath();
    c.fill();
    c.stroke();

    // ground
    c.beginPath();
    c.moveTo(ox - p.wO / 2, oy);
    c.lineTo(ox + p.wO / 2, oy);
    c.closePath();
    c.stroke();
}

// Draw tire front view
function drawTireFrontView(c, x, y, rad, wid) {
    var l = x - wid / 2;
    var r = x + wid / 2;
    var t = y - rad;
    var b = y + rad;
    var tr = 6; // タイヤの潰れ
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