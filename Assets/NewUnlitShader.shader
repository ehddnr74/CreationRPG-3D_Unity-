Shader "Unlit/NewUnlitShader"
{
Properties {
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineThickness ("Outline Thickness", Range (0.0, 0.03)) = 0.003
    }
    SubShader {
        Tags {"RenderPipeline"="UniversalRenderPipeline"}
        Pass {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Front
            ZWrite On
            ZTest LEqual
            ColorMask RGB

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float _OutlineThickness;
            float4 _OutlineColor;

            struct Attributes {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings {
                float4 positionHCS : SV_POSITION;
                float4 color : COLOR;
            };

            Varyings vert (Attributes v) {
                Varyings o;
                float3 normWS = TransformObjectToWorldNormal(v.normalOS);
                float3 posWS = TransformObjectToWorld(v.positionOS.xyz);
                posWS += normWS * _OutlineThickness;
                o.positionHCS = TransformWorldToHClip(posWS);
                o.color = _OutlineColor;
                return o;
            }

            half4 frag (Varyings i) : SV_Target {
                return i.color;
            }
            ENDHLSL
        }
    }
    FallBack "Unlit/Color"
}