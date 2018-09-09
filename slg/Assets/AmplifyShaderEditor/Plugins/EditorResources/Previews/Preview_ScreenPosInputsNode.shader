Shader "Hidden/ScreenPosInputsNode"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			float4 frag( v2f_img i ) : SV_Target
			{
				float2 xy = 2 * i.uv - 1;
				float z = -sqrt(1-saturate(dot(xy,xy)));
				float3 vertexPos = float3(xy, z);
				float3 worldPos = mul(unity_ObjectToWorld, vertexPos).xyz;
				float4 change = float4(worldPos, 0);
				return float4 (ComputeScreenPos(change));
			}
			ENDCG
		}
	}
}
