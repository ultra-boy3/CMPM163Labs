//Outputs pixel color for the fragment we are shading
uniform sampler2D texture1;
varying vec2 vUv; //Changed from vecc3 to vec2 for UV coordinates

void main(){
    // sample from the texture based on the uv coordinates
    gl_FragColor = texture2D(texture1, vUv); //rgba
    //Similar to how texture handling would be done without THREE
}