// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|diff-1544-OUT,normal-7486-OUT,emission-1544-OUT,alpha-3850-OUT,refract-47-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32632,y:33111,ptovrint:False,ptlb:Form,ptin:_Form,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5f77c98c6e57a9349af032cd3ef78d0c,ntxv:0,isnm:False|UVIN-2504-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9339,x:32219,y:32961,varname:node_9339,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2504,x:32399,y:32950,cmnt:controll water flow,varname:node_2504,prsc:2,spu:0.01,spv:-0.01|UVIN-9339-UVOUT;n:type:ShaderForge.SFN_Color,id:8946,x:32917,y:32402,ptovrint:False,ptlb:water_color,ptin:_water_color,varname:node_8946,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:3850,x:32852,y:32991,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_3850,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5299146,max:1;n:type:ShaderForge.SFN_ComponentMask,id:2736,x:32812,y:33129,varname:node_2736,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-851-RGB;n:type:ShaderForge.SFN_Normalize,id:7486,x:32812,y:32763,varname:node_7486,prsc:2|IN-7413-RGB;n:type:ShaderForge.SFN_Tex2d,id:7413,x:32568,y:32788,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_7413,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3fad59ec9c95fcd4fb7aea3bacac0de7,ntxv:3,isnm:False|UVIN-2504-UVOUT;n:type:ShaderForge.SFN_Multiply,id:47,x:33022,y:33174,varname:node_47,prsc:2|A-2736-OUT,B-1398-OUT;n:type:ShaderForge.SFN_Slider,id:1398,x:32632,y:33313,ptovrint:False,ptlb:reflection,ptin:_reflection,cmnt:controll reflection of water,varname:node_1398,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Fresnel,id:7702,x:32748,y:32511,varname:node_7702,prsc:2|EXP-6160-OUT;n:type:ShaderForge.SFN_Multiply,id:1544,x:32998,y:32626,varname:node_1544,prsc:2|A-8946-RGB,B-7702-OUT,C-5830-OUT;n:type:ShaderForge.SFN_Slider,id:5830,x:32553,y:32668,ptovrint:False,ptlb:Transparent,ptin:_Transparent,varname:node_5830,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9337273,max:1;n:type:ShaderForge.SFN_Slider,id:6160,x:32430,y:32562,ptovrint:False,ptlb:Frenelstretch,ptin:_Frenelstretch,varname:node_6160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.027251,max:3;proporder:851-8946-3850-7413-1398-5830-6160;pass:END;sub:END;*/

Shader "Shader Forge/water" {
    Properties {
        _Form ("Form", 2D) = "white" {}
        _water_color ("water_color", Color) = (1,1,1,1)
        _Opacity ("Opacity", Range(0, 1)) = 0.5299146
        _Normal ("Normal", 2D) = "bump" {}
        _reflection ("reflection", Range(0, 1)) = 1
        _Transparent ("Transparent", Range(0, 1)) = 0.9337273
        _Frenelstretch ("Frenelstretch", Range(0, 3)) = 1.027251
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDBASE
               #define UNITY_PASS_FORWARDBASE
            #endif
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Form; uniform float4 _Form_ST;
            uniform float4 _water_color;
            uniform float _Opacity;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _reflection;
            uniform float _Transparent;
            uniform float _Frenelstretch;
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
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_6380 = _Time;
                float2 node_2504 = (i.uv0+node_6380.g*float2(0.01,-0.01)); // controll water flow
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(node_2504, _Normal));
                float3 normalLocal = normalize(_Normal_var.rgb);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Form_var = tex2D(_Form,TRANSFORM_TEX(node_2504, _Form));
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (_Form_var.rgb.rg*_reflection);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 node_1544 = (_water_color.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_Frenelstretch)*_Transparent);
                float3 diffuseColor = node_1544;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_1544;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,_Opacity),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDADD
               #define UNITY_PASS_FORWARDADD
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Form; uniform float4 _Form_ST;
            uniform float4 _water_color;
            uniform float _Opacity;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _reflection;
            uniform float _Transparent;
            uniform float _Frenelstretch;
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
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_4841 = _Time;
                float2 node_2504 = (i.uv0+node_4841.g*float2(0.01,-0.01)); // controll water flow
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(node_2504, _Normal));
                float3 normalLocal = normalize(_Normal_var.rgb);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Form_var = tex2D(_Form,TRANSFORM_TEX(node_2504, _Form));
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (_Form_var.rgb.rg*_reflection);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 node_1544 = (_water_color.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_Frenelstretch)*_Transparent);
                float3 diffuseColor = node_1544;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _Opacity,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
