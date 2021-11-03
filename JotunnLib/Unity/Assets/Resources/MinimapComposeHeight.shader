﻿Shader "MinimapCompose"
{
    Properties
    {
        _MainTex("Texture", 2D) = "blue" {}
        _OvlTex("Texture", 2D) = "green" {}
    }
        SubShader
        {
            Tags {"Queue"="Transparent" "RenderType"="Transparent" }
            LOD 100

            Pass 
            {
                CGPROGRAM
                #pragma vertex vert 
                #pragma fragment frag
                #pragma target 2.0

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

                sampler2D _MainTex, _OvlTex;
                float4 _MainTex_ST;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                float4 frag(v2f i) : SV_Target
                {
                    float4 col = tex2D(_MainTex, i.uv);
                    float4 col2 = tex2D(_OvlTex, i.uv);

                    if(col.r != 0){
                        col2.r = col.r;
                    }
                    return col2;
                }
                ENDCG
            }
        }
}