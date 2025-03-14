#ifdef GL_FRAGMENT_PRECISION_HIGH
precision highp float;
#else
precision mediump float;
#endif

uniform vec2 resolution;
uniform float time;
uniform float ftime;
uniform float subsecond;
uniform float battery;

float quadStep(float t){
  return (-4.*t*t +4.*t);}
float sdHeart(in vec2 p) {
    p.x = abs(p.x);

    if (p.y + p.x > 1.0)
        return sqrt(dot(p - vec2(0.25, 0.75), p - vec2(0.25, 0.75))) - sqrt(2.0) / 4.0;

    return sqrt(min(dot(p - vec2(0.00, 1.00), p - vec2(0.00, 1.00)),
                    dot(p - 0.5 * max(p.x + p.y, 0.0),
                        p - 0.5 * max(p.x + p.y, 0.0)))) * sign(p.x - p.y);
}

float smStep(float t){

  return (3.*t*t-2.*t*t*t);
  }

void main(void) {

  vec2 uv = (gl_FragCoord.xy* 2.0 - resolution.xy) / resolution.y;
  uv*=1.999999+sin(subsecond*3.14)*0.5;
  float  t= time;;
  float bat = 0.6;
   float speed=sin(subsecond*3.14);
  uv.y+=0.6;
  vec2 uv2=uv;
  uv2.y-=0.6;

     float scale =  length(uv2);
   if(sdHeart(uv)<=0.06){
     if(uv.y<=cos(3.0*uv.x+8.4*t)*sin(t)*0.05+1.3){
       vec4 c1= vec4(1.,0.,0.,1.);
       vec4 c2= vec4(1.,1.,0,1.);

      vec4 col= mix(c1,c2,abs(uv.y)+abs(uv.y*0.5)-0.4);
       if(uv.y<2.*uv.x+1.081 && uv.y>-2.*uv.x+0.3 || uv.y<2.*uv.x){
       gl_FragColor= col;
       }
         else

         gl_FragColor=col*0.6;


     }


   }
   else if(sdHeart(uv)<=0.06+speed){

     gl_FragColor = vec4(1.,0.6,0.1,1.)*scale;
     }
     else if(sdHeart(uv)<=0.5+speed){
    gl_FragColor = vec4(0.8,0.4,0.,1.)*scale;
     }
     else if(sdHeart(uv*0.3)<=1.2+speed){
     gl_FragColor = vec4(0.8,0.1,0.0,0.2)*scale;
     }
   else gl_FragColor= vec4(0.3,.2,0.2,1.)*scale;
//

}
