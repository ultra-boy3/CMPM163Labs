# CMPM163Labs
LAB 2
Part 1 Video: https://drive.google.com/file/d/1_DB0JUPH8TkMiO0voPH5Cuohx5Hr33dy/view?usp=sharing

![](Images/lab2part2.png)

LAB 3
Video: https://drive.google.com/file/d/1Ijrx45119McJHbOBVCSIvfvnGQzZzDel/view?usp=sharing

How each cube was made (Top-left to bottom-right):
- Basic material with orange color, transparent = true and wireframe = true. Inspired by one of the example spheres: https://threejs.org/examples/#webgl_materials
- Extra shader added by me. This one uses rainbowShader.frag, which assigns fragment color based its position, creating a rainbow effect.
- Built using the part 1 instructions. Uses Phong material and specularity.
- Built using the part 2 instructions. Uses vertexShader.vert and fragmentShader.frag, assigning the two uniform vec3 colors to pink and purple.
- Normal material with no assigned values. Also inspired by an example sphere: https://threejs.org/examples/#webgl_materials

LAB 4
a. u * 8 - 1 = x or u * 8 = x?
b. |v * 8 - 8| = y or |v * 8 - 8| + 1 = y?
c. 0.375 * 8 = 3 - 1 = 2
   0.25 * 8 = 2 - 8 = 6
   (3, 5) or (2, 6) = blue, grey