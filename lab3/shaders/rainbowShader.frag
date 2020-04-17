//Outputs pixel color for the fragment we are shading
varying vec3 vUv;

void main(){
    //Interpolate between two input colors
    vec3 position = vUv;

    //Coloring each fragment based on position
    //Not sure what the last one does
    gl_FragColor = vec4(position.x, position.y, position.z, 1.0);
}