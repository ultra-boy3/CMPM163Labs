//Outputs pixel color for the fragment we are shading
uniform sampler2D texture1;
varying vec2 vUv; //Changed from vecc3 to vec2 for UV coordinates
//ec2 adjust;

void main(){
    vec2 adjust = vUv;
    // sample from the texture based on the uv coordinates
    //adjust = vec2(0.0, 0.0);
    
    adjust.x = floor((vUv.x + 0.5));
    adjust.y = floor((vUv.y + 0.5));

    gl_FragColor = texture2D(texture1, vUv * 2.0 - adjust);
    /*
    if(vUv.x < 0.5 && vUv.y < 0.5)
    {
        gl_FragColor = texture2D(texture1, vUv * 2.0);
    }
    else if(vUv.x > 0.5 && vUv.y < 0.5)
    {
        gl_FragColor = texture2D(texture1, vUv * 2.0 - vec2(1.0, 0.0));
    }
    else if(vUv.x < 0.5 && vUv.y > 0.5)
    {
        gl_FragColor = texture2D(texture1, vUv * 2.0 - vec2(0.0, 1.0));
    }
    else
    {
        gl_FragColor = texture2D(texture1, vUv * 2.0 - vec2(1.0, 1.0));
    }
    */
    //Similar to how texture handling would be done without THREE
}