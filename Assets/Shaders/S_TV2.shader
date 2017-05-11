// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:34027,y:32740,varname:node_3138,prsc:2|emission-8774-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32841,y:32796,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6904736,c2:0.9485294,c3:0.7242878,c4:1;n:type:ShaderForge.SFN_TexCoord,id:7715,x:31248,y:32967,varname:node_7715,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:3699,x:31421,y:33005,varname:node_3699,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7715-V;n:type:ShaderForge.SFN_Time,id:1554,x:31278,y:33435,varname:node_1554,prsc:2;n:type:ShaderForge.SFN_Add,id:5115,x:31596,y:33104,varname:node_5115,prsc:2|A-3699-OUT,B-1554-TSL;n:type:ShaderForge.SFN_Multiply,id:8531,x:31761,y:33027,varname:node_8531,prsc:2|A-8094-OUT,B-5115-OUT,C-732-OUT;n:type:ShaderForge.SFN_Vector1,id:8094,x:31563,y:32852,varname:node_8094,prsc:2,v1:100;n:type:ShaderForge.SFN_Sin,id:7836,x:31907,y:33027,varname:node_7836,prsc:2|IN-8531-OUT;n:type:ShaderForge.SFN_RemapRange,id:5576,x:32090,y:33027,varname:node_5576,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7836-OUT;n:type:ShaderForge.SFN_Tau,id:732,x:31659,y:33318,varname:node_732,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:3199,x:32774,y:33194,varname:node_3199,prsc:2|IN-5576-OUT;n:type:ShaderForge.SFN_Tex2d,id:8980,x:32994,y:32551,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_8980,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5276,x:32815,y:32973,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_5276,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.05903979,c2:0.2058824,c3:0.1390437,c4:1;n:type:ShaderForge.SFN_Lerp,id:4968,x:33191,y:33004,varname:node_4968,prsc:2|A-7241-RGB,B-5276-RGB,T-5517-OUT;n:type:ShaderForge.SFN_Multiply,id:787,x:33438,y:32976,varname:node_787,prsc:2|A-4968-OUT,B-8381-OUT;n:type:ShaderForge.SFN_Slider,id:8381,x:33221,y:33227,ptovrint:False,ptlb:opacity_,ptin:_opacity_,varname:node_8381,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:1542,x:32064,y:33358,varname:node_1542,prsc:2|A-3699-OUT,B-5042-OUT;n:type:ShaderForge.SFN_Multiply,id:3935,x:32388,y:33400,varname:node_3935,prsc:2|A-1542-OUT,B-7393-OUT,C-732-OUT;n:type:ShaderForge.SFN_Vector1,id:7393,x:32182,y:33192,varname:node_7393,prsc:2,v1:4;n:type:ShaderForge.SFN_Cos,id:3903,x:32574,y:33384,varname:node_3903,prsc:2|IN-3935-OUT;n:type:ShaderForge.SFN_RemapRange,id:5105,x:32739,y:33384,varname:node_5105,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:0|IN-3903-OUT;n:type:ShaderForge.SFN_Clamp01,id:9287,x:32905,y:33368,varname:node_9287,prsc:2|IN-5105-OUT;n:type:ShaderForge.SFN_Multiply,id:5517,x:32991,y:33193,varname:node_5517,prsc:2|A-3199-OUT,B-9287-OUT;n:type:ShaderForge.SFN_Add,id:8774,x:33644,y:32852,varname:node_8774,prsc:2|A-8980-RGB,B-787-OUT;n:type:ShaderForge.SFN_Multiply,id:5042,x:31806,y:33512,varname:node_5042,prsc:2|A-1554-TSL,B-4484-OUT;n:type:ShaderForge.SFN_Vector1,id:4484,x:31646,y:33668,varname:node_4484,prsc:2,v1:-1;proporder:7241-8980-5276-8381;pass:END;sub:END;*/

Shader "Shader Forge/S_TV2" {
    Properties {
        _Color ("Color", Color) = (0.6904736,0.9485294,0.7242878,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _Color2 ("Color2", Color) = (0.05903979,0.2058824,0.1390437,1)
        _opacity_ ("opacity_", Range(-1, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color2;
            uniform float _opacity_;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_3699 = i.uv0.g.r;
                float4 node_1554 = _Time + _TimeEditor;
                float node_732 = 6.28318530718;
                float3 emissive = (_MainTex_var.rgb+(lerp(_Color.rgb,_Color2.rgb,(saturate((sin((100.0*(node_3699+node_1554.r)*node_732))*0.5+0.5))*saturate((cos(((node_3699+(node_1554.r*(-1.0)))*4.0*node_732))*-0.5+0.5))))*_opacity_));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
