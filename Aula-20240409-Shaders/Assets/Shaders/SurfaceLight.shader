Shader "PJD3/SurfaceLight"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _RimColor ("Rim Color", Color) = (1,0,0,1)
        _Ramp ("Ramp", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline", float) = 1.0
        _RampV ("RampV", Range(0.02, 0.99)) = 0.02
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        //Cull Front
        //CGPROGRAM
        //#pragma surface surf Standard vertex:vert

        //half4 _OutlineColor;
        //half _Outline;

        //struct Input
        //{
        //    float2 uv_MainTex;
        //};

        //void vert (inout appdata_full v) {
        //    v.vertex.xyz += v.normal * _Outline;
        //}

        //void surf (Input IN, inout SurfaceOutputStandard o)
        //{
        //    // Albedo comes from a texture tinted by color
            
        //    o.Albedo = _OutlineColor.rgb;
        //    // Metallic and smoothness come from slider variables
        //    //o.Metallic = _Metallic;
        //    //o.Smoothness = _Glossiness;
        //    o.Alpha = _OutlineColor.a;
        //}
        //ENDCG


        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Toon fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _Ramp;
        float _RampV;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _RimColor;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        half4 LightingToon (SurfaceOutput s, half3 lightDir, half atten) {
            float NdotL = dot(s.Normal,lightDir);
            float diff = NdotL * 0.5 + 0.5;
            half3 a;
            //float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - s.Vertex.xyz);
            //float rimDir = dot(s.Normal, viewDir);
            //a = lerp(s.Albedo.rgb, _RimColor.rgb, rimDir);
            half4 c;
            //c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten);
            //c.rgb = a * _LightColor0.rgb * (NdotL * atten);
            half3 rampColor = tex2D(_Ramp, float2(diff,_RampV)).rgb;
            //c.rgb = s.Albedo * _LightColor0.rgb * (rampColor * atten);
            c.rgb = s.Albedo * _LightColor0.rgb * rampColor * atten;
            c.a = s.Alpha;
            return c;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
