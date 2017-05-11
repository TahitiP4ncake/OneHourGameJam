// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33638,y:32712,varname:node_3138,prsc:2|emission-2730-RGB;n:type:ShaderForge.SFN_ScreenPos,id:2126,x:32385,y:32626,varname:node_2126,prsc:2,sctp:2;n:type:ShaderForge.SFN_SceneColor,id:2730,x:33341,y:32763,varname:node_2730,prsc:2|UVIN-8680-OUT;n:type:ShaderForge.SFN_Vector1,id:5901,x:32534,y:33241,varname:node_5901,prsc:2,v1:0.2548;n:type:ShaderForge.SFN_Vector1,id:3757,x:32962,y:33380,varname:node_3757,prsc:2,v1:10;n:type:ShaderForge.SFN_Frac,id:1021,x:32566,y:32875,varname:node_1021,prsc:2|IN-2126-UVOUT;n:type:ShaderForge.SFN_Floor,id:8680,x:33088,y:32851,varname:node_8680,prsc:2|IN-805-OUT;n:type:ShaderForge.SFN_Multiply,id:3923,x:32783,y:32907,varname:node_3923,prsc:2|A-1021-OUT,B-5901-OUT,C-3757-OUT;n:type:ShaderForge.SFN_Frac,id:6101,x:33169,y:33118,varname:node_6101,prsc:2|IN-3923-OUT;n:type:ShaderForge.SFN_Multiply,id:805,x:33337,y:33173,varname:node_805,prsc:2|A-6101-OUT,B-5901-OUT,C-3757-OUT;n:type:ShaderForge.SFN_Frac,id:1813,x:33406,y:33058,varname:node_1813,prsc:2|IN-805-OUT;pass:END;sub:END;*/

Shader "Shader Forge/S_Pixel2" {
    Properties {
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float node_5901 = 0.2548;
                float node_3757 = 10.0;
                float2 node_805 = (frac((frac(sceneUVs.rg)*node_5901*node_3757))*node_5901*node_3757);
                float3 emissive = tex2D( _GrabTexture, floor(node_805)).rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
