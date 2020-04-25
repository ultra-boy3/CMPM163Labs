//Outputs pixel color for the fragment we are shading
uniform sampler2D texture1;
varying vec2 vUv; //Changed from vecc3 to vec2 for UV coordinates
vec2 adjust = vec2(1.0, 0.0);

void main(){
    //vec2 adjust = vUv;
    // sample from the texture based on the uv coordinates
    //gl_FragColor = texture2D(texture1, vUv * 2.0 - 1.0);
    
    if(vUv.x < 0.5 && vUv.y < 0.5)
    {
        gl_FragColor = texture2D(texture1, vUv * 2.0);
    }
    else if(vUv.x > 0.5 && vUv.y < 0.5)
    {
        gl_FragColor = texture2D(texture1, vUv * 2.0 - adjust);
    }
    
    //Similar to how texture handling would be done without THREE
}