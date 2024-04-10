Shader "PJD3/HeatDistortion" {
    Properties {
	    _Color("Color",Color) = (1,1,1,1)
        _NoiseTex ("Noise Texture (RG)", 2D) = "white" {}
        strength("strength", Range(0.1, 0.3)) = 0.2
        transparency("transparency", Range(0.01, 0.1)) = 0.05
    }

    
    SubShader {
        //GrabPass {
        //    Tags { "Queue" = "Transparent+10" }
	       // Name "BASE"
        //    Tags { "LightMode" = "Always" }
        //}
       
        Pass {
            Tags { "Queue" = "Transparent+10" }
			Name "BASE"
			Tags { "LightMode" = "Always" }
	        Lighting Off
		    Cull Back
			ZWrite On
			ZTest LEqual
			Blend SrcAlpha OneMinusSrcAlpha
			AlphaTest Greater 0
         
         
CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members viewAngle,distortion)
#pragma exclude_renderers d3d11
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members viewAngle,distortion)
//#pragma exclude_renderers d3d11
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members viewAngle,distortion)
//#pragma exclude_renderers d3d11
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members viewAngle,distortion)
//#pragma exclude_renderers d3d11
// Upgrade NOTE: excluded shader from Xbox360; has structs without semantics (struct v2f members distortion)
//#pragma exclude_renderers xbox360
#pragma vertex vert
#pragma fragment frag
//#pragma fragmentoption ARB_precision_hint_fastest
//#pragma fragmentoption ARB_fog_exp2
#include "UnityCG.cginc"

sampler2D _GrabTexture : register(s0);
float4 _NoiseTex_ST;
sampler2D _NoiseTex;
float strength;
float transparency;
half4 _Color;

struct data {
    float4 vertex : POSITION;
    float3 normal : NORMAL;
    float4 texcoord : TEXCOORD0;
};

struct v2f {
    float4 position : POSITION;
    float4 screenPos : TEXCOORD0;
    float2 uvmain : TEXCOORD2;
    float viewAngle;
	float distortion;
};

v2f vert(data i){
    v2f o;
    o.position = UnityObjectToClipPos(i.vertex);      // compute transformed vertex position
    o.uvmain = TRANSFORM_TEX(i.texcoord, _NoiseTex);   // compute the texcoords of the noise
    //float viewAngle = dot(normalize(mul((float3x3)glstate.matrix.invtrans.modelview[0], i.normal)),
	//					 float3(0,0,1));
	
	float viewAngle = dot(normalize(ObjSpaceViewDir(i.vertex)), i.normal);
	//float viewAngle = dot(normalize(ObjSpaceViewDir(i.vertex)), i.normal);
	o.viewAngle = viewAngle;
	
	//o.distortion = o.viewAngle * o.viewAngle;	// square viewAngle to make the effect fall off stronger
	o.distortion = viewAngle * viewAngle;
	
	float depth = -mul( UNITY_MATRIX_MV, i.vertex ).z;	// compute vertex depth
	o.distortion /= 1+depth;		// scale effect with vertex depth
	o.distortion *= strength;	// multiply with user controlled strength
	o.screenPos = o.position;   // pass the position to the pixel shader
	return o;
}

half4 frag( v2f i ) : COLOR
{   
    // compute the texture coordinates
    float2 screenPos = i.screenPos.xy / i.screenPos.w;   // screenpos ranges from -1 to 1
    screenPos.x = (screenPos.x + 1) * 0.5;   // I need 0 to 1
    screenPos.y = (screenPos.y + 1) * 0.5;   // I need 0 to 1

//    if (_ProjectionParams.x < 0)
//        screenPos.y = 1 - screenPos.y;
        
    #if !UNITY_UV_STARTS_AT_TOP
    	screenPos.y = 1 - screenPos.y;
    #endif
   
    // get two offset values by looking up the noise texture shifted in different directions
    half4 offsetColor1 = tex2D(_NoiseTex, i.uvmain + _Time.xz);
    half4 offsetColor2 = tex2D(_NoiseTex, i.uvmain - _Time.yx);
   
    // use the r values from the noise texture lookups and combine them for x offset
    // use the g values from the noise texture lookups and combine them for y offset
    // use minus one to shift the texture back to the center
    // scale with distortion amount
    screenPos.x += ((offsetColor1.r + offsetColor2.r) - 1) * i.distortion;
    screenPos.y += ((offsetColor1.g + offsetColor2.g) - 1) * i.distortion;
   
    float2 uv = float2(screenPos.x,1-screenPos.y);
    //half4 col = tex2D( _GrabTexture, screenPos );
    half4 col = tex2D( _GrabTexture, uv ) * _Color;
    //col.rgb = _Color.rgb;
    col.a = (i.distortion/transparency) * (i.viewAngle * i.viewAngle) * _Color.a;
    col.a = i.viewAngle * i.viewAngle * i.viewAngle * i.viewAngle * _Color.a;
	return col;
}

ENDCG
        }
    }

}