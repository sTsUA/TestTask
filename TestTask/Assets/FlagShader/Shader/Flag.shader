Shader "Unlit/Flag"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CropTex("Crop Texture", 2D) = "white" {}
        _WindSpeedX("Wind Speed x", Range(0, 3)) = 0
        _WindSpeedY("Wind Speed y", Range(0, 3)) = 0
    }
    SubShader
    {
        Cull Off
        Tags { "RenderType"="Opaque" "Queue"="Transparent"}
        
        Blend SrcAlpha OneMinusSrcAlpha
        
        LOD 100

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
            fixed4 _MainTex_ST;
            sampler2D _CropTex;
            fixed _WindSpeedX;
            fixed _WindSpeedY;

            v2f vert (appdata v)
            {
                v2f o;
                
                v.vertex.y += sin(_Time.z * _WindSpeedX + v.vertex.x) * v.uv.x;
                v.vertex.z += sin(_Time.z * _WindSpeedY + v.vertex.y) * v.uv.x;
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 crop = tex2D(_CropTex, i.uv);
                
                col.a = crop.r * crop.g * crop.b;
                
                return col;
            }
            ENDCG
        }
    }
}
