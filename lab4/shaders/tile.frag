//Outputs pixel color for the fragment we are shading
uniform sampler2D texture1;
varying vec2 vUv; //Changed from vecc3 to vec2 for UV coordinates
//vec2 adjust = (0.5, 0.5);

void main(){
    vec2 adjust = vUv;
    // sample from the texture based on the uv coordinates
    gl_FragColor = texture2D(texture1, vUv);
    /*
    if(vUv.x < 1.0 && vUv.y < 1.0)
    {
        gl_FragColor = texture2D(texture1, vUv);
    }
    else
    {
        
        gl_FragColor = texture2D(texture1, vUv - 0.5);
    }
    */
    //Similar to how texture handling would be done without THREE
}