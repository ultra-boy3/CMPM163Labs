Shader "Custom/Waves"{
	Properties{
		_Color("Colour", Color) = (0, 0, 0, 1)
		_Strength("Strength", Range(0, 2)) = 1.0
		_Speed("Speed", Range(-200, 200)) = 100 //Negative makes the effect go backwards
	}

	SubShader{
		Tags{
		"RenderType"= "transparent"

		Pass

		Cull Off //Do not ignore pixes behind others (due to transparency)

		CGPROGRAM

#pragma vertex vertexFunc
#pragma fragment fragFunc

		ENDCG
		}
	}
}