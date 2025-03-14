#ifdef GL_FRAGMENT_PRECISION_HIGH
precision highp float;
#else
precision mediump float;
#endif

uniform vec2 resolution;
uniform float time;
void main(void) {
  vec2 uv = (gl_FragCoord.xy* 2.0 - resolution.xy) / resolution.y;
  vec4 color=vec4(1.);
    // uv*= 1.+abs(sin(time)+sqrt(0.0001));


  uv.y+=.2;

   if(uv.y>=abs(uv.x*.8) && uv.y-0.3<=abs(.8*uv.x)
      &&  abs(uv.x)<=0.19 && uv.y-0.5<=-abs(uv.x) || uv.y>=1.14){
     color=vec4(0.);
    }


  gl_FragColor = color;
}
