Shader "PJD3/Pulse" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.03, 1)) = 0.078125
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_Extrude ("Extrude widths",Vector) = (1,1,1,1)
		_Speeds ("Speeds", Vector) = (0.2,0.5,0.7,1)
		_FallOff ("Falloff", Vector) = (6,6,6,6)
		_ExtrudeScale ("Extrude scale",float) = 0.25
	
	}
	
SubShader { 
	Tags { "RenderType"="Opaque" }
	LOD 400
	
CGPROGRAM
#pragma surface surf BlinnPhong vertex:vert


sampler2D _MainTex;
sampler2D _BumpMap;
fixed4 _Color;
half _Shininess;

half4 _Extrude;
half4 _Speeds;
half4 _FallOff;
half _ExtrudeScale;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float4 color : COLOR;
};

void vert(inout appdata_full v)
{
	v.vertex.xyz += v.normal * v.color.x * _Extrude.x * _ExtrudeScale * pow(sin(_Time.y * _Speeds.x),_FallOff.x);
	v.vertex.xyz += v.normal * v.color.y * _Extrude.y * _ExtrudeScale * pow(sin(_Time.y * _Speeds.y),_FallOff.y);
	v.vertex.xyz += v.normal * v.color.z * _Extrude.z * _ExtrudeScale * pow(sin(_Time.y * _Speeds.z),_FallOff.z);
	v.vertex.xyz += v.normal * v.color.w * _Extrude.w * _ExtrudeScale * pow(sin(_Time.y * _Speeds.w),_FallOff.w);
}

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	o.Albedo = tex.rgb * _Color.rgb;
	o.Gloss = tex.a;
	o.Alpha = tex.a * _Color.a;
	o.Specular = _Shininess;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG
}

FallBack "Specular"
}