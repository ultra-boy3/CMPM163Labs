//Outputs pixel color for the fragment we are shading
varying vec2 vUv; //Changed from vecc3 to vec2 for UV coordinates

void main(){
    gl_FragColor = vec4(vUv.x, vUv.y, 0.0, 1.0); //rgba
}