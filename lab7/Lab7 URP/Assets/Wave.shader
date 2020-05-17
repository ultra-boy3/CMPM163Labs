Shader "Custom/Waves"{
	Properties{
		_Color("Colour", Color) = (0, 0, 0, 1)
		_Strength("Strength", Range(0, 2)) = 1.0
		_Speed("Speed", Range(-200, 200)) = 100 //Negative makes the effect go backwards
	}

	SubShader{
		Tags{
			"RenderType" = "transparent"
		}


		Pass{

			Cull Off //Do not ignore pixes behind others (due to transparency)

			CGPROGRAM

			#pragma vertex vertexFunc
			#pragma fragment fragmentFunc

			float4 _Color;
			float _Strength;
			float _Speed;

			struct vertexInput {
				float4 vertex : POSITION;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
			};

			vertexOutput vertexFunc(vertexInput IN) {
				vertexOutput o;

				float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);
				float displacement = (cos(worldPos.y) + cos(worldPos.x + (_Speed * _Time)));
				worldPos.y = worldPos.y + (displacement * _Strength);

				o.pos = mul(UNITY_MATRIX_VP, worldPos);
				return o;
			}

			float4 fragmentFunc(vertexOutput IN) : COLOR{
				return _Color;
			}

			ENDCG
		}
	}
}

/*
Output variable vertexFunc contains a system-interpreted value (SV_POSITION) which must be written in every execution path of the shader.  Unconditional initialization may help.
Compiling Vertex program
Platform defines: UNITY_ENABLE_REFLECTION_BUFFERS UNITY_USE_DITHER_MASK_FOR_ALPHABLENDED_SHADOWS UNITY_PBS_USE_BRDF1 UNITY_SPECCUBE_BOX_PROJECTION UNITY_SPECCUBE_BLENDING UNITY_ENABLE_DETAIL_NORMALMAP SHADER_API_DESKTOP UNITY_LIGHT_PROBE_PROXY_VOLUME UNITY_LIGHTMAP_FULL_HDR
*/