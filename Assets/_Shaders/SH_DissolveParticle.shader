Shader "Particles/Specific/Dissolve Unlit"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		[NoScaleOffset]_DissolveMap ("Dissolve Map", 2D) = "black" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transaprent"}
        LOD 100
		
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		ZTest LEqual

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float4 color : COLOR;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float4 color : COLOR;
                float4 vertex : SV_POSITION;
				float custom1 : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			sampler2D _DissolveMap;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
                o.uv = TRANSFORM_TEX(v.uv.xy, _MainTex);
				o.custom1 = v.uv.z;
				
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * i.color;
				fixed dissolveMap = tex2D(_DissolveMap, i.uv).r;
				
				fixed dissolveAmount = dissolveMap - i.custom1;
				dissolveAmount = ceil(dissolveAmount);
				dissolveAmount = saturate(dissolveAmount);
				col.a *= dissolveAmount;
				
                return col;
            }
            ENDCG
        }
    }
}
