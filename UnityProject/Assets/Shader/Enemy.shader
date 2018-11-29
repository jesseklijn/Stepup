// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:34788,y:32565,varname:node_9361,prsc:2|normal-9378-RGB,emission-259-OUT,custl-544-OUT,clip-2196-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:33446,y:32780,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0552c4e403f8ed74e8eff04d8f977712,ntxv:0,isnm:False|UVIN-6051-OUT;n:type:ShaderForge.SFN_Color,id:5927,x:33280,y:32971,ptovrint:False,ptlb:AddColor,ptin:_AddColor,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:544,x:33725,y:32905,cmnt:Diffuse Color,varname:node_544,prsc:2|A-851-RGB,B-5927-RGB;n:type:ShaderForge.SFN_TexCoord,id:3640,x:32335,y:31698,varname:node_3640,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:9378,x:32522,y:31676,ptovrint:False,ptlb:NormalMap,ptin:_NormalMap,varname:node_9378,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bac3888b891718344bf46cd02333f247,ntxv:3,isnm:True|UVIN-3640-UVOUT;n:type:ShaderForge.SFN_Fresnel,id:6159,x:33125,y:32125,varname:node_6159,prsc:2|NRM-6233-OUT;n:type:ShaderForge.SFN_NormalVector,id:7005,x:32421,y:32155,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:5319,x:33837,y:32345,varname:node_5319,prsc:2|A-3173-OUT,B-6457-RGB;n:type:ShaderForge.SFN_Color,id:6457,x:33586,y:32434,ptovrint:False,ptlb:FrenelColor,ptin:_FrenelColor,varname:node_6457,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:3087,x:33165,y:31843,ptovrint:False,ptlb:FrenelValue,ptin:_FrenelValue,varname:node_3087,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1.900859,max:5;n:type:ShaderForge.SFN_Multiply,id:3173,x:33586,y:32205,varname:node_3173,prsc:2|A-3087-OUT,B-6159-OUT;n:type:ShaderForge.SFN_TexCoord,id:4585,x:32685,y:32702,varname:node_4585,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:9523,x:32685,y:32875,varname:node_9523,prsc:2;n:type:ShaderForge.SFN_Add,id:6051,x:33108,y:32735,varname:node_6051,prsc:2|A-7842-OUT,B-7246-OUT;n:type:ShaderForge.SFN_Vector1,id:7656,x:32685,y:32634,varname:node_7656,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:7842,x:32930,y:32675,varname:node_7842,prsc:2|A-7656-OUT,B-4585-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7246,x:32930,y:32821,varname:node_7246,prsc:2|A-9523-TSL,B-7656-OUT;n:type:ShaderForge.SFN_Transform,id:6182,x:32423,y:31867,varname:node_6182,prsc:2,tffrom:0,tfto:2|IN-9378-RGB;n:type:ShaderForge.SFN_ComponentMask,id:921,x:32633,y:31885,varname:node_921,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-6182-XYZ;n:type:ShaderForge.SFN_Vector1,id:8150,x:32497,y:32083,varname:node_8150,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:6233,x:32895,y:32063,varname:node_6233,prsc:2|A-921-OUT,B-7005-OUT,T-8150-OUT;n:type:ShaderForge.SFN_Slider,id:1032,x:33064,y:32569,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_1032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:6301,x:33446,y:32581,varname:node_6301,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.5|IN-1032-OUT;n:type:ShaderForge.SFN_Add,id:2196,x:33848,y:32735,varname:node_2196,prsc:2|A-6301-OUT,B-851-R;n:type:ShaderForge.SFN_Add,id:259,x:34552,y:32574,varname:node_259,prsc:2|A-5319-OUT,B-1993-OUT;n:type:ShaderForge.SFN_Color,id:2072,x:34094,y:32770,ptovrint:False,ptlb:EmmisionColor,ptin:_EmmisionColor,varname:node_2072,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3018868,c2:0.2093272,c3:0.2093272,c4:1;n:type:ShaderForge.SFN_Multiply,id:1993,x:34348,y:32662,varname:node_1993,prsc:2|A-6939-OUT,B-2072-RGB;n:type:ShaderForge.SFN_ComponentMask,id:6939,x:34064,y:32591,varname:node_6939,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-851-RGB;proporder:851-5927-9378-6457-3087-1032-2072;pass:END;sub:END;*/

Shader "Shader Forge/Enemy" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _AddColor ("AddColor", Color) = (0.5,0.5,0.5,1)
        _NormalMap ("NormalMap", 2D) = "bump" {}
        _FrenelColor ("FrenelColor", Color) = (0.5,0.5,0.5,1)
        _FrenelValue ("FrenelValue", Range(1, 5)) = 1.900859
        _Opacity ("Opacity", Range(0, 1)) = 1
        _EmmisionColor ("EmmisionColor", Color) = (0.3018868,0.2093272,0.2093272,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDBASE
               #define UNITY_PASS_FORWARDBASE
            #endif
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _AddColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float4 _FrenelColor;
            uniform float _FrenelValue;
            uniform float _Opacity;
            uniform float4 _EmmisionColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float node_7656 = 3.0;
                float4 node_9523 = _Time;
                float2 node_6051 = ((node_7656*i.uv0)+(node_9523.r*node_7656));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_6051, _Diffuse));
                clip(((_Opacity*0.6+-0.1)+_Diffuse_var.r) - 0.5);
////// Lighting:
////// Emissive:
                float node_921 = mul( tangentTransform, _NormalMap_var.rgb ).xyz.rgb.b;
                float3 emissive = (((_FrenelValue*(1.0-max(0,dot(lerp(float3(node_921,node_921,node_921),normalDirection,1.0), viewDirection))))*_FrenelColor.rgb)+(_Diffuse_var.rgb.b*_EmmisionColor.rgb));
                float3 finalColor = emissive + (_Diffuse_var.rgb*_AddColor.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_SHADOWCASTER
               #define UNITY_PASS_SHADOWCASTER
            #endif
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_7656 = 3.0;
                float4 node_9523 = _Time;
                float2 node_6051 = ((node_7656*i.uv0)+(node_9523.r*node_7656));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_6051, _Diffuse));
                clip(((_Opacity*0.6+-0.1)+_Diffuse_var.r) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
