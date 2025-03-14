#ifdef GL_FRAGMENT_PRECISION_HIGH
precision highp float;
#else
precision mediump float;
#endif

uniform vec2 resolution;
uniform float time;
uniform float subsecond;

vec4 palette(float t) {
    return vec4(
        0.5 + 0.5 * cos(6.2831 * (t + 0.0)),
        0.5 + 0.5 * cos(6.2831 * (t + 0.33)),
        0.5 + 0.5 * cos(6.2831 * (t + 0.67)),
        1.0
    );
}

float fun1(vec2 uv,float t){

    float x= uv.x;
    float y= uv.y;
    return pow(cos(y),3.)+exp(cos(6.*x*t)+cos(5.*y*t))-cos(x);

  }
  float fun2(vec2 uv,float t){

    float x= uv.x;
    float y= uv.y;
    return pow(cos(y),3.)-exp(cos(6.*x*t)+cos(6.*y*t))-cos(x);

  }
void main(void) {
  //vec2 uv = gl_FragCoord.xy / resolution.xy;
  vec2 uv = (gl_FragCoord.xy* 2.0 - resolution.xy) / resolution.y;
    vec4 col= palette(sin(time)*.1)*.18;
    vec2 uv2= uv;
    uv*=15.;
    float d = length(uv2);
    float t= sin(time*.3)*.5+.5;
    float line=max(.15,cos(time)*.3);
   if(abs(fun1(uv,t))<=line){
     col=palette(length(uv2)*.15);
    }
    if(abs(fun2(uv,t))<=line ){
     col=palette(length(uv2)*.5)*(1. -d/4.);
    }
  gl_FragColor = col;
}
