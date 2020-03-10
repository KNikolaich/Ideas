var canvas;
var gl;

var NumVertices = 24;

var vertices = [
    vec4(-0.5, -0.5, 1.5, 1.0),//1
    vec4(-0.5, 0.5, 1.5, 1.0),//2
    vec4(-0.5, -0.5, 1.5, 1.0),//1
    vec4(0.5, -0.5, 1.5, 1.0),//4
    vec4(-0.5, -0.5, 1.5, 1.0),//1
    vec4(-0.5, -0.5, 0.5, 1.0),//5
    vec4(-0.5, 0.5, 1.5, 1.0),//2
    vec4(0.5, 0.5, 1.5, 1.0),//3
    vec4(-0.5, 0.5, 1.5, 1.0),//2
    vec4(-0.5, 0.5, 0.5, 1.0),//6
    vec4(0.5, 0.5, 1.5, 1.0),//3
    vec4(0.5, -0.5, 1.5, 1.0),//4
    vec4(0.5, 0.5, 1.5, 1.0),//3
    vec4(0.5, 0.5, 0.5, 1.0),//7
    vec4(0.5, -0.5, 1.5, 1.0),//4
    vec4(0.5, -0.5, 0.5, 1.0), //8
    vec4(-0.5, -0.5, 0.5, 1.0),//5
    vec4(-0.5, 0.5, 0.5, 1.0),//6
    vec4(-0.5, -0.5, 0.5, 1.0),//5
    vec4(0.5, -0.5, 0.5, 1.0), //8
    vec4(-0.5, 0.5, 0.5, 1.0),//6
    vec4(0.5, 0.5, 0.5, 1.0),//7
    vec4(0.5, 0.5, 0.5, 1.0),//7
    vec4(0.5, -0.5, 0.5, 1.0) //8
];

var vertexColors = [
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red

    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
    vec4(1.0, 0.0, 0.0, 1.0),  // red
];

var near = 0.3;
var far = 10.0;
var radius = 4.0;
var theta = 0.0;
var phi = 0.0;
var dr = 5.0 * Math.PI / 180.0;

var fovy = 90.0;  // Field-of-view in Y direction angle (in degrees)
var aspect;       // Viewport aspect ratio

var modelViewMatrix, projectionMatrix;
var modelViewMatrixLoc, projectionMatrixLoc;
var eye;
const at = vec3(0.0, 0.0, 0.0);
const up = vec3(0.0, 1.0, 0.0);


var program;
var program_originline;

var cBuffer;
var vColor;
var vBuffer;
var vPosition;

var l_vBuffer;
var l_vPosition;
var l_cBuffer;
var l_vColor;

window.onload = function init() {

    canvas = document.getElementById("gl-canvas");

    gl = WebGLUtils.setupWebGL(canvas);
    if (!gl) { alert("WebGL isn't available"); }

    gl.viewport(0, 0, canvas.width, canvas.height);

    aspect = canvas.width / canvas.height;

    gl.clearColor(0.0, 0.0, 0.0, 1.0);

    gl.enable(gl.DEPTH_TEST);

    //  Load shaders and initialize attribute buffers
    program_originline = initShaders(gl, "vertex-shader", "fragment-shader");
    program = initShaders(gl, "vertex-shader", "fragment-shader");

    //CUBE Buffers
    cBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, cBuffer);
    //gl.bufferData( gl.ARRAY_BUFFER, flatten(colorsArray), gl.STATIC_DRAW );
    gl.bufferData(gl.ARRAY_BUFFER, flatten(vertexColors), gl.STATIC_DRAW);

    vColor = gl.getAttribLocation(program, "vColor");
    //gl.vertexAttribPointer( vColor, 4, gl.FLOAT, false, 0, 0 );
    //gl.enableVertexAttribArray( vColor);

    vBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, vBuffer);
    //gl.bufferData( gl.ARRAY_BUFFER, flatten(pointsArray), gl.STATIC_DRAW );
    gl.bufferData(gl.ARRAY_BUFFER, flatten(vertices), gl.STATIC_DRAW);

    vPosition = gl.getAttribLocation(program, "vPosition");


    //Static Line
    var l_vertices = [
        vec4(0.0, 0.0, 0.0, 1.0),
        vec4(5.0, 0.0, 0.0, 1.0),
        vec4(0.0, 0.0, 0.0, 1.0),
        vec4(0.0, 5.0, 0.0, 1.0),
        vec4(0.0, 0.0, 0.0, 1.0),
        vec4(0.0, 0.0, 5.0, 1.0),
        vec4(0.0, 0.0, 0.0, 1.0),
        vec4(-5.0, 0.0, 0.0, 1.0),
        vec4(0.0, 0.0, 0.0, 1.0),
        vec4(0.0, -5.0, 0.0, 1.0),
        vec4(0.0, 0.0, 0.0, 1.0),
        vec4(0.0, 0.0, -5.0, 1.0),
    ];
    // Load the data into the GPU
    l_vBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, l_vBuffer);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(l_vertices), gl.STATIC_DRAW);
    // Associate out shader variables with our data buffer
    l_vPosition = gl.getAttribLocation(program_originline, "vPosition");


    var l_colors = [
        vec4(1.0, 1.0, 0.0, 1.0),
        vec4(1.0, 1.0, 0.0, 1.0),
        vec4(1.0, 1.0, 0.0, 1.0),
        vec4(1.0, 1.0, 0.0, 1.0),
        vec4(1.0, 1.0, 0.0, 1.0),
        vec4(1.0, 1.0, 0.0, 1.0),

        vec4(0.0, 0.0, 1.0, 1.0),
        vec4(0.0, 0.0, 1.0, 1.0),
        vec4(0.0, 0.0, 1.0, 1.0),
        vec4(0.0, 0.0, 1.0, 1.0),
        vec4(0.0, 0.0, 1.0, 1.0),
        vec4(0.0, 0.0, 1.0, 1.0),
    ];
    l_cBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, l_cBuffer);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(l_colors), gl.STATIC_DRAW);

    l_vColor = gl.getAttribLocation(program_originline, "vColor");


    // buttons for viewing parameters
    document.getElementById("Button1").onclick = function () { near *= 1.1; far *= 1.1; };
    document.getElementById("Button2").onclick = function () { near *= 0.9; far *= 0.9; };
    document.getElementById("Button3").onclick = function () { radius *= 2.0; };
    document.getElementById("Button4").onclick = function () { radius *= 0.5; };
    document.getElementById("Button5").onclick = function () { theta += dr; };
    document.getElementById("Button6").onclick = function () { theta -= dr; };
    document.getElementById("Button7").onclick = function () { phi += dr; };
    document.getElementById("Button8").onclick = function () { phi -= dr; };

    render();
}


var render = function () {
    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);


    //LINE PROGRAM
    gl.useProgram(program_originline);
    gl.enableVertexAttribArray(l_vPosition);
    gl.bindBuffer(gl.ARRAY_BUFFER, l_vBuffer);
    gl.vertexAttribPointer(l_vPosition, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(l_vColor);
    gl.bindBuffer(gl.ARRAY_BUFFER, l_cBuffer);
    gl.vertexAttribPointer(l_vColor, 4, gl.FLOAT, false, 0, 0);

    gl.drawArrays(gl.LINES, 0, 12);

    modelViewMatrixLoc = gl.getUniformLocation(program_originline, "modelViewMatrix");
    projectionMatrixLoc = gl.getUniformLocation(program_originline, "projectionMatrix");

    eye = vec3(radius * Math.sin(theta) * Math.cos(phi),
        radius * Math.sin(theta) * Math.sin(phi), radius * Math.cos(theta));
    modelViewMatrix = lookAt(eye, at, up);
    projectionMatrix = perspective(fovy, aspect, near, far);

    gl.uniformMatrix4fv(modelViewMatrixLoc, false, flatten(modelViewMatrix));
    gl.uniformMatrix4fv(projectionMatrixLoc, false, flatten(projectionMatrix));


    //CUBE PROGRAM
    gl.useProgram(program);
    gl.enableVertexAttribArray(vPosition);
    gl.bindBuffer(gl.ARRAY_BUFFER, vBuffer);
    gl.vertexAttribPointer(vPosition, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vColor);
    gl.bindBuffer(gl.ARRAY_BUFFER, cBuffer);
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.drawArrays(gl.LINES, 0, 24);

    modelViewMatrixLoc = gl.getUniformLocation(program, "modelViewMatrix");
    projectionMatrixLoc = gl.getUniformLocation(program, "projectionMatrix");

    eye = vec3(radius * Math.sin(theta) * Math.cos(phi), radius * Math.sin(theta) * Math.sin(phi), radius * Math.cos(theta));
    modelViewMatrix = lookAt(eye, at, up);
    projectionMatrix = perspective(fovy, aspect, near, far);

    gl.uniformMatrix4fv(modelViewMatrixLoc, false, flatten(modelViewMatrix));
    gl.uniformMatrix4fv(projectionMatrixLoc, false, flatten(projectionMatrix));

    requestAnimFrame(render);
}