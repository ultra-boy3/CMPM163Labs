//Runs for every vertex of a mesh of geometry
//Base code: Maintains potisiiton of the verticies of the mesh
varying vec3 vUv;

void main(){
    vUv = position;

    vec4 modelViewPosition = modelViewMatrix * vec4(position, 1.0);
    gl_Position = projectionMatrix * modelViewPosition;
}