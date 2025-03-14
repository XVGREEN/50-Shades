#ifdef GL_FRAGMENT_PRECISION_HIGH
precision highp float;

precision mediump float;
#endif

uniform vec2 resolution;
uniform float time;
uniform float battery;
uniform float subsecond;
uniform int powerConnected;

uniform float ftime;

void main(void) {

 float bat=battery;
 float t=time;
    if(powerConnected==1)t=time;
    vec2 uv = (gl_FragCoord.xy* 2.0 - resolution.xy) / resolution.y;
   vec4 col1=vec4(1.0,0.15,vec2(0.1));
    vec4 col2 = vec4(0,1.0,0.0,1);
    vec4 col3 = vec4(0.6, 0., 0., 1.0);
    vec4 col4 = vec4(0.2, 0.1, 1.0, 1.0);



    float v= abs(ftime*3.14*0.5)*0.07;
    vec4 c1= mix(col1,col3,sin(v));
    vec4 c2= mix(col2,col4,sin(v));

      uv.y+=1.0;

   vec4 col;
col=mix(c1,c2,uv.y/2.);
   if(uv.y<=cos(3.0*uv.x+8.4*t)*sin(t)*0.05+2.0*bat){

       gl_FragColor = mix(c1,c2,abs(uv.y/2.0));

     }
     else if(uv.y>=(2.0*bat-6.0*bat-0.25) +sin(uv.x+8.0*t)*sin(t)*0.05 && uv.y<(bat*2.0+0.2)+sin(uv.x+8.0*t)*sin(t)*0.05){
       gl_FragColor =  mix(col*0.30, vec4(0.02,0.06,0,0), smoothstep(0.0, 0.2, uv.y - (2.0 * bat)));
    }
   else{

   gl_FragColor= vec4(0.06,0.06,0,1);;
   }


}
