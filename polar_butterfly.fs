#ifdef GL_FRAGMENT_PRECISION_HIGH
precision highp float;
#else
precision mediump float;
#endif
#define PI 3.141592653589793
vec4 pallete(float x){

  vec4 A = vec4(0.8,.3,.2,1.);
  vec4 B = vec4(0.4,.8,.2,1.);
  vec4 C = vec4(0.1,.3,.4,1);

  return A+(B-C)*cos(x);
}
float angle(vec2 u, vec2 v) {
    float dotProd = dot(u, v);
    float magU = length(u);
    float magV = length(v);
    return acos(dotProd / (magU * magV));
}

mat2 rot (float a){// angles in rad
   return mat2(cos(a),sin(a),-sin(a),cos(a));
}
vec2 complex(vec2 a, vec2 b) {
    return vec2(a.x * b.x - a.y * b.y, a.x * b.y + a.y * b.x);
}
vec2 bezier(float t){
  vec2 a = vec2(-0.8, -0.5); // Start point
vec2 b = vec2(-0.4,  0.8); // Control point 1
vec2 c = vec2( 0.4, -0.8); // Control point 2
vec2 d = vec2( 0.8,  0.5); // End point
  vec2 p1= mix(a,b,t);
  vec2 p2= mix(b,c,t);
  vec2 p3= mix(c,d,t);

  vec2 p4= mix(p1,p2,t);
  vec2 p5= mix(p2,p3,t);
  vec2 p6 = mix(p4,p5,t);
  return p6;
}

uniform vec2 resolution;
uniform float time;
uniform float subsecond;
vec2 polar(vec2 uv){
     float r= length(uv);
     float a = atan(uv.x/uv.y);
     return vec2(r,a);
  }
void main(void) {
  vec2 uv = (gl_FragCoord.xy* 2.0 - resolution.xy) / resolution.y;
//   uv*=rot(asin(sin(time)));
  // uv+=1.;
    vec4  col= mix(pallete(1.7),pallete(2.),sin(time));;
    if ((uv.x * uv.x) + (uv.y - 0.15) * (uv.y - 0.1) <= 0.006 ||
    (uv.x * uv.x) + (uv.y + 0.15) * (uv.y + 0.1) <= 0.0007 ||
    (abs(uv.x) <= 0.025 && abs(uv.y) <= 0.12)) {
    col = vec4(0.);
}

    if ((uv.x * uv.x) + (uv.y - 0.15) * (uv.y - 0.1) <= 0.005 ||
    (uv.x * uv.x) + (uv.y + 0.15) * (uv.y + 0.1) <= 0.0005 ||
    (abs(uv.x) <= 0.02 && abs(uv.y) <= 0.1)) {
    col = pallete(1.7)*.7;
}

    uv*=2.;


    uv.r*=1.5*sin(8.*time)+3.;

     float  size=5.;
    if(abs(uv.x)>=.02){

    for(float i=0.;i<size;i++){

    vec2 uv2=uv*(1.+i*.5);


     for(float j=0.;j<size;j++){
         vec2  uvr = rot(2.*PI/size*pow(-1.,j))*uv2;
         vec2  uvp= polar(uvr);
         float val= uvp.r-cos(2.*uvp.g);
         float len= length(vec2(i,i));
         if(val<=0.) {
          col=pallete(len/2.9);
        }
        if(abs(val)<=.025){
          col=vec4(0.);

        }
     }
   }
   }
     col= mix(col,pallete(2.),+sin(time)*.1);



  gl_FragColor = col;
}
