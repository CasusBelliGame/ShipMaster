Shader "Deniz/snowtrack" {
        Properties {
            _Tess ("Tessellation", Range(1,32)) = 4
            _SnowColor ("Snow Color", color) = (1,1,1,1)
            _SnowTex ("Snow (RGB)", 2D) = "white" {}
            _GroundColor ("Ground Color", color) = (1,1,1,1)
            _GroundTex ("Ground (RGB)", 2D) = "white" {}
            _Splat ("Splat", 2D) = "gray" {}
            _Displacement ("Displacement", Range(0, 1.0)) = 0.3
            _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessFixed nolightmap
            //#pragma target 4.6

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            float _Tess;

            float4 tessFixed()
            {
                return _Tess;
            }

            sampler2D _Splat;
            float _Displacement;

            void disp (inout appdata v)
            {
                float d = tex2Dlod(_Splat, float4(v.texcoord.xy,0,0)).r * _Displacement;
                v.vertex.xyz -= v.normal * d;
                v.vertex.xyz += v.normal* _Displacement;
            }

            struct Input {
                float2 uv_GroundTex;
                float2 uv_SnowTex;
                float2 uv_Splat;
            };

            sampler2D _GroundTex;
            fixed4 _GroundColor;
            sampler2D _SnowTex;
            fixed4 _SnowColor;
            fixed4 _Color;

            void surf (Input IN, inout SurfaceOutput o) {
                half amount = tex2Dlod(_Splat, float4(IN.uv_Splat,0,0)).r;
                fixed4 c =lerp(tex2D (_SnowTex, IN.uv_SnowTex)*_SnowColor,tex2D(_GroundTex, IN.uv_GroundTex) * _GroundColor,amount);
                //half4 c = tex2D (_GroundTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Specular = 0.2;
                o.Gloss = 1.0;
            }
            ENDCG
        }
        FallBack "Diffuse"
    }