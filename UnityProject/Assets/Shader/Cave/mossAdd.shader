// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33280,y:32978,varname:node_2865,prsc:2|diff-9278-OUT,spec-358-OUT,gloss-1813-OUT,normal-1941-OUT,emission-3708-OUT,amdfl-9149-OUT,amspl-7951-RGB;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31571,y:32409,ptovrint:True,ptlb:Base ColorA,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:13ce61196f81de841b25408efa630c4c,ntxv:0,isnm:False|UVIN-2680-UVOUT;n:type:ShaderForge.SFN_Slider,id:358,x:33690,y:32918,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:33690,y:32824,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9997,x:31745,y:32789,ptovrint:False,ptlb:Base ColorB,ptin:_BaseColorB,varname:node_9997,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:efb54819b9603c84c9cc8b13c0633251,ntxv:3,isnm:False|UVIN-7667-OUT;n:type:ShaderForge.SFN_Lerp,id:7451,x:32083,y:32407,varname:node_7451,prsc:2|A-891-RGB,B-2864-RGB,T-462-OUT;n:type:ShaderForge.SFN_Normalize,id:1941,x:32351,y:32402,varname:node_1941,prsc:2|IN-7451-OUT;n:type:ShaderForge.SFN_Lerp,id:9278,x:32281,y:32657,varname:node_9278,prsc:2|A-7736-RGB,B-9997-RGB,T-462-OUT;n:type:ShaderForge.SFN_Tex2d,id:891,x:31555,y:32202,ptovrint:False,ptlb:A_normal map,ptin:_A_normalmap,varname:node_891,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e6a7ae5b357374d4d847d6930c56434f,ntxv:3,isnm:True|UVIN-2680-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2864,x:31745,y:32597,ptovrint:False,ptlb:B_normal map,ptin:_B_normalmap,varname:node_2864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:718f1d6dea003634c88cadff740c62ea,ntxv:3,isnm:True|UVIN-7667-OUT;n:type:ShaderForge.SFN_NormalVector,id:5735,x:32089,y:33012,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:8560,x:32089,y:33173,varname:node_8560,prsc:2;n:type:ShaderForge.SFN_Dot,id:5769,x:32360,y:33058,varname:node_5769,prsc:2,dt:0|A-5735-OUT,B-8560-OUT;n:type:ShaderForge.SFN_LightColor,id:7336,x:32107,y:33459,varname:node_7336,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:3607,x:32107,y:33628,varname:node_3607,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1944,x:32342,y:33459,varname:node_1944,prsc:2|A-7336-RGB,B-3607-OUT;n:type:ShaderForge.SFN_TexCoord,id:2680,x:31111,y:32587,varname:node_2680,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:5770,x:33526,y:33283,ptovrint:False,ptlb:EmissionTex,ptin:_EmissionTex,varname:node_5770,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:1635,x:33368,y:33814,ptovrint:False,ptlb:EmissionValue,ptin:_EmissionValue,varname:node_1635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:8714,x:33526,y:33479,ptovrint:False,ptlb:Emission_Color,ptin:_Emission_Color,varname:node_8714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:4384,x:33992,y:33382,varname:node_4384,prsc:2|A-5335-RGB,B-2663-OUT,T-9683-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:3708,x:33983,y:33076,ptovrint:False,ptlb:EmissionSwitch,ptin:_EmissionSwitch,varname:node_3708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5335-RGB,B-4384-OUT;n:type:ShaderForge.SFN_Color,id:5335,x:33526,y:33116,ptovrint:False,ptlb:EmissionOff,ptin:_EmissionOff,varname:node_5335,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4198,x:31555,y:33009,ptovrint:False,ptlb:mask(Green),ptin:_maskGreen,varname:node_4198,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c5c6552ba31916143bfba0e60c4fd6ab,ntxv:0,isnm:False|UVIN-2680-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:462,x:31859,y:33059,varname:node_462,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-4198-RGB;n:type:ShaderForge.SFN_Multiply,id:9149,x:32673,y:33202,varname:node_9149,prsc:2|A-5769-OUT,B-1944-OUT;n:type:ShaderForge.SFN_AmbientLight,id:7951,x:32996,y:33268,varname:node_7951,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:8081,x:31300,y:32623,varname:node_8081,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:8264,x:31327,y:32840,ptovrint:False,ptlb:Tile_Value,ptin:_Tile_Value,varname:node_8264,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:6;n:type:ShaderForge.SFN_Multiply,id:7667,x:31555,y:32806,varname:node_7667,prsc:2|A-8081-UVOUT,B-8264-OUT;n:type:ShaderForge.SFN_Multiply,id:9683,x:33809,y:33734,varname:node_9683,prsc:2|A-7584-OUT,B-1635-OUT;n:type:ShaderForge.SFN_TexCoord,id:5067,x:32930,y:33596,varname:node_5067,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:831,x:33162,y:33610,ptovrint:False,ptlb:EmissionMask(Green),ptin:_EmissionMaskGreen,varname:node_831,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5067-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:7584,x:33368,y:33610,varname:node_7584,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-831-RGB;n:type:ShaderForge.SFN_Multiply,id:2663,x:33708,y:33442,varname:node_2663,prsc:2|A-5770-RGB,B-8714-RGB;proporder:7736-358-1813-9997-891-2864-5770-1635-8714-3708-5335-4198-8264-831;pass:END;sub:END;*/

Shader "Shader Forge/mossAdd" {
    Properties {
        _MainTex ("Base ColorA", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0.5
        _Gloss ("Gloss", Range(0, 1)) = 0
        _BaseColorB ("Base ColorB", 2D) = "bump" {}
        _A_normalmap ("A_normal map", 2D) = "bump" {}
        _B_normalmap ("B_normal map", 2D) = "bump" {}
        _EmissionTex ("EmissionTex", 2D) = "white" {}
        _EmissionValue ("EmissionValue", Range(0, 1)) = 1
        _Emission_Color ("Emission_Color", Color) = (0,0,0,1)
        [MaterialToggle] _EmissionSwitch ("EmissionSwitch", Float ) = 0
        _EmissionOff ("EmissionOff", Color) = (0,0,0,1)
        _maskGreen ("mask(Green)", 2D) = "white" {}
        _Tile_Value ("Tile_Value", Float ) = 6
        _EmissionMaskGreen ("EmissionMask(Green)", 2D) = "white" {}
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
            #ifndef UNITY_PASS_FORWARDBASE
               #define UNITY_PASS_FORWARDBASE
            #endif
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _BaseColorB; uniform float4 _BaseColorB_ST;
            uniform sampler2D _A_normalmap; uniform float4 _A_normalmap_ST;
            uniform sampler2D _B_normalmap; uniform float4 _B_normalmap_ST;
            uniform sampler2D _EmissionTex; uniform float4 _EmissionTex_ST;
            uniform float _EmissionValue;
            uniform float4 _Emission_Color;
            uniform fixed _EmissionSwitch;
            uniform float4 _EmissionOff;
            uniform sampler2D _maskGreen; uniform float4 _maskGreen_ST;
            uniform float _Tile_Value;
            uniform sampler2D _EmissionMaskGreen; uniform float4 _EmissionMaskGreen_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _A_normalmap_var = UnpackNormal(tex2D(_A_normalmap,TRANSFORM_TEX(i.uv0, _A_normalmap)));
                float2 node_7667 = (i.uv0*_Tile_Value);
                float3 _B_normalmap_var = UnpackNormal(tex2D(_B_normalmap,TRANSFORM_TEX(node_7667, _B_normalmap)));
                float4 _maskGreen_var = tex2D(_maskGreen,TRANSFORM_TEX(i.uv0, _maskGreen));
                float node_462 = _maskGreen_var.rgb.g;
                float3 normalLocal = normalize(lerp(_A_normalmap_var.rgb,_B_normalmap_var.rgb,node_462));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _BaseColorB_var = tex2D(_BaseColorB,TRANSFORM_TEX(node_7667, _BaseColorB));
                float3 diffuseColor = lerp(_MainTex_var.rgb,_BaseColorB_var.rgb,node_462); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular + UNITY_LIGHTMODEL_AMBIENT.rgb);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += (dot(i.normalDir,lightDirection)*(_LightColor0.rgb*attenuation)); // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _EmissionTex_var = tex2D(_EmissionTex,TRANSFORM_TEX(i.uv0, _EmissionTex));
                float4 _EmissionMaskGreen_var = tex2D(_EmissionMaskGreen,TRANSFORM_TEX(i.uv0, _EmissionMaskGreen));
                float3 emissive = lerp( _EmissionOff.rgb, lerp(_EmissionOff.rgb,(_EmissionTex_var.rgb*_Emission_Color.rgb),(_EmissionMaskGreen_var.rgb.g*_EmissionValue)), _EmissionSwitch );
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDADD
               #define UNITY_PASS_FORWARDADD
            #endif
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _BaseColorB; uniform float4 _BaseColorB_ST;
            uniform sampler2D _A_normalmap; uniform float4 _A_normalmap_ST;
            uniform sampler2D _B_normalmap; uniform float4 _B_normalmap_ST;
            uniform sampler2D _EmissionTex; uniform float4 _EmissionTex_ST;
            uniform float _EmissionValue;
            uniform float4 _Emission_Color;
            uniform fixed _EmissionSwitch;
            uniform float4 _EmissionOff;
            uniform sampler2D _maskGreen; uniform float4 _maskGreen_ST;
            uniform float _Tile_Value;
            uniform sampler2D _EmissionMaskGreen; uniform float4 _EmissionMaskGreen_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _A_normalmap_var = UnpackNormal(tex2D(_A_normalmap,TRANSFORM_TEX(i.uv0, _A_normalmap)));
                float2 node_7667 = (i.uv0*_Tile_Value);
                float3 _B_normalmap_var = UnpackNormal(tex2D(_B_normalmap,TRANSFORM_TEX(node_7667, _B_normalmap)));
                float4 _maskGreen_var = tex2D(_maskGreen,TRANSFORM_TEX(i.uv0, _maskGreen));
                float node_462 = _maskGreen_var.rgb.g;
                float3 normalLocal = normalize(lerp(_A_normalmap_var.rgb,_B_normalmap_var.rgb,node_462));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _BaseColorB_var = tex2D(_BaseColorB,TRANSFORM_TEX(node_7667, _BaseColorB));
                float3 diffuseColor = lerp(_MainTex_var.rgb,_BaseColorB_var.rgb,node_462); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _BaseColorB; uniform float4 _BaseColorB_ST;
            uniform sampler2D _EmissionTex; uniform float4 _EmissionTex_ST;
            uniform float _EmissionValue;
            uniform float4 _Emission_Color;
            uniform fixed _EmissionSwitch;
            uniform float4 _EmissionOff;
            uniform sampler2D _maskGreen; uniform float4 _maskGreen_ST;
            uniform float _Tile_Value;
            uniform sampler2D _EmissionMaskGreen; uniform float4 _EmissionMaskGreen_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _EmissionTex_var = tex2D(_EmissionTex,TRANSFORM_TEX(i.uv0, _EmissionTex));
                float4 _EmissionMaskGreen_var = tex2D(_EmissionMaskGreen,TRANSFORM_TEX(i.uv0, _EmissionMaskGreen));
                o.Emission = lerp( _EmissionOff.rgb, lerp(_EmissionOff.rgb,(_EmissionTex_var.rgb*_Emission_Color.rgb),(_EmissionMaskGreen_var.rgb.g*_EmissionValue)), _EmissionSwitch );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float2 node_7667 = (i.uv0*_Tile_Value);
                float4 _BaseColorB_var = tex2D(_BaseColorB,TRANSFORM_TEX(node_7667, _BaseColorB));
                float4 _maskGreen_var = tex2D(_maskGreen,TRANSFORM_TEX(i.uv0, _maskGreen));
                float node_462 = _maskGreen_var.rgb.g;
                float3 diffColor = lerp(_MainTex_var.rgb,_BaseColorB_var.rgb,node_462);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
