//Outputs pixel color for the fragment we are shading
varying vec3 vUv;

uniform vec3 colorA;
uniform vec3 colorB;

void main(){
    //Interpolate between two input colors
    gl_FragColor = vec4(mix(colorA, colorB, vUv.z), 1.0);
}