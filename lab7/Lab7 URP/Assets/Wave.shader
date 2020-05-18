Shader "Custom/Waves"{
	Properties{
		_Color("Color", Color) = (0, 0.568627, 1, 1)
		_Color2("Color2", Color) = (0, 0, 0, 1)
		_Strength("Strength", Range(0, 2)) = 1.0
		_Speed("Speed", Range(-200, 200)) = 100 //Negative makes the effect go backwards
		
		_HeightMin("Height Min", Float) = -1
		_HeightMax("Height Max", Float) = 1
		_ColorMin("Tint Color At Min", Color) = (0,0,0,1)
		_ColorMax("Tint Color At Max", Color) = (1,1,1,1)
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
			float4 _Color2;
			float _Strength;
			float _Speed;
			fixed4 _ColorMin;
			fixed4 _ColorMax;
			float _HeightMin;
			float _HeightMax;
			float save_displacement;

			struct vertexInput {
				float4 vertex : POSITION;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				//float4 pos2 : POSITION;
			};

			vertexOutput vertexFunc(vertexInput IN) {
				vertexOutput o;

				float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);
				float displacement = (cos(worldPos.y) + cos(worldPos.x + (_Speed * _Time)));

				save_displacement = displacement;

				worldPos.y = worldPos.y + (displacement * _Strength);

				o.pos = mul(UNITY_MATRIX_VP, worldPos);
				o.uv = float2(IN.vertex.x, IN.vertex.y);
				return o;
			}

			float4 fragmentFunc(vertexOutput IN) : COLOR{
				float add = (cos(IN.pos.y) + cos(IN.pos.x + (_Speed * _Time)));
				float4 offset = (1 * add, 1 * add, 0, 1);
				//float4 worldPos = IN / UNITY_MATRIX_VP;

				if (IN.pos.y > (IN.pos.y - (save_displacement * 0.5)))
				{
					_Color2 = (1, 1, 1, 1);
				}

				//float h = (_HeightMax - IN.worldPos.y) / (_HeightMax - _HeightMin);
				//fixed4 tintColor = lerp(_ColorMax.rgba, _ColorMin.rgba, h)

				return (_Color + +_Color2);
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