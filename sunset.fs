#ifdef GL_FRAGMENT_PRECISION_HIGH
precision highp float;
#else
precision mediump float;
#endif

uniform vec2 resolution;
uniform float startRandom;
uniform float subsecond;
uniform float time;
uniform vec3 daytime;


float rand(vec2 uv) {
    return fract(sin(dot(uv, vec2(12.9898, 78.233))) * 43758.5453);
}
float square(float a) {return a*a;}
void main(void) {

   float h=daytime.x;
   float light=0.;

   if(h>=19. ||  h<6.){
     light=0.;
     }else{
       light=1.;

       }
  vec2 uv = (gl_FragCoord.xy* 2.0 - resolution.xy) / resolution.y;
  float r= rand(uv*startRandom);
  vec4 skyColor;
  vec4 fc;
  float d = 1.;// 0.3-length(uv);


  skyColor=  fc = mix(vec4(1.,0.5,0.5,1.),vec4(0.,0.,1.,1.),(uv.y-1.)/2.)*light;

  //sun || moon
  if(length(uv)<.9){
      fc=mix(vec4(1.,1.,0.8,1)*0.9,skyColor,length(uv))*light;

  }
  if(light==0.){

      if(rand(uv*startRandom)>0.998){

      fc=vec4(1.);

        }

    }

  if(length(uv)<=0.35){

    fc =vec4(1.,1.,.9,1);


  }

  if(uv.y<= 1.2*cos(ceil(uv.x*9.+time*2.)*15.)*0.1){

  fc= mix(vec4(1.,0.,0.1,1.),vec4(.9,0.5,.0,1.),1.-abs(uv.y))*light;

    }
  if(uv.y+0.5<=0.2){
       fc= vec4(0.7,0.3,0.1,0.1)*light;
  }if(uv.y+0.6<=0.2){
       fc= vec4(0.3,0.15,.1,0.1)*light;
  }if(uv.y+0.8<=0.2){
       fc= vec4(0.1,0.08,0.06,0.1)*light;
  }

  gl_FragColor=fc;
}
