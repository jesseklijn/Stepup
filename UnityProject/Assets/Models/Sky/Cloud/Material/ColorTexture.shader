﻿Shader "Unlit/ColorTexture"
{
	Properties
	{
		_MainColor("MainColor",Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
	}
		LOD 100
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _MainColor;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 texcol = tex2D(_MainTex, i.uv);
				fixed4 col = fixed4(_MainColor.r*texcol.r, _MainColor.g*texcol.g, _MainColor.b*texcol.b, texcol.a);
				return col;
			}
			ENDCG
		}
	}
}
