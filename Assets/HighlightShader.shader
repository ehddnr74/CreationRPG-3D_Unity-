Shader "Unlit/URPHighlightShader" {
    Properties {
        _OutlineColor ("Outline Color", Color) = (1,0,0,1)
        _Outline ("Outline width", Range (0, 1)) = .1
    }
    
    SubShader {
        Tags { "RenderPipeline"="UniversalRenderPipeline" }
        Pass {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Front
            ZWrite On
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float _Outline;
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
                posWS += normWS * _Outline;
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