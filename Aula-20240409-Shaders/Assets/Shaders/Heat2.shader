//Shader "PJD3/Heat2"
//{
//    Properties
//    {
//        _MainTex ("Texture", 2D) = "white" {}
//        _Color("Color",Color) = (1,1,1,1)
//        _NoiseTex ("Noise Texture (RG)", 2D) = "white" {}
//        strength("strength", Range(0.1, 0.3)) = 0.2
//        transparency("transparency", Range(0.01, 0.1)) = 0.05
//    }
//    SubShader
//    {
//        Tags { "Queue" = "Transparent" }
//        GrabPass
//        {
//            "_BackgroundTexture"
//        }

//        //sampler2D _GrabTexture : register(s0);
//        //sampler2D _GrabTexture;
//        float4 _NoiseTex_ST;
//        sampler2D _NoiseTex;
//        float strength;
//        float transparency;
//        half4 _Color;

//        Pass
//        {
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//            // make fog work
//            #pragma multi_compile_fog

//            #include "UnityCG.cginc"

//            //struct appdata
//            //{
//            //    float4 vertex : POSITION;
//            //    float2 uv : TEXCOORD0;
//            //};
//            struct data {
//                float4 vertex : POSITION;
//                float3 normal : NORMAL;
//                float4 texcoord : TEXCOORD0;
//            };

//            //struct v2f
//            //{
//            //    float2 uv : TEXCOORD0;
//            //    UNITY_FOG_COORDS(1)
//            //    float4 vertex : SV_POSITION;
//            //};

//            struct v2f {
//                float4 position : POSITION;
//                float4 screenPos : TEXCOORD0;
//                float2 uvmain : TEXCOORD2;
//             //   float viewAngle;
//	            //float distortion;
//            };

//            sampler2D _MainTex;
//            float4 _MainTex_ST;

//            sampler2D _BackgroundTexture;

//            //v2f vert (appdata v)
//            //{
//            //    v2f o;
//            //    o.vertex = UnityObjectToClipPos(v.vertex);
//            //    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
//            //    UNITY_TRANSFER_FOG(o,o.vertex);
//            //    return o;
//            //}

//            v2f vert(data i){
//                v2f o;
//                o.position = UnityObjectToClipPos(i.vertex);      // compute transformed vertex position
//                o.uvmain = TRANSFORM_TEX(i.texcoord, _NoiseTex);   // compute the texcoords of the noise
//                //float viewAngle = dot(normalize(mul((float3x3)glstate.matrix.invtrans.modelview[0], i.normal)),
//	            //					 float3(0,0,1));
	
//	            float viewAngle = dot(normalize(ObjSpaceViewDir(i.vertex)), i.normal);
//	            //float viewAngle = dot(normalize(ObjSpaceViewDir(i.vertex)), i.normal);
//	            o.viewAngle = viewAngle;
	
//	            //o.distortion = o.viewAngle * o.viewAngle;	// square viewAngle to make the effect fall off stronger
//	            o.distortion = viewAngle * viewAngle;
	
//	            float depth = -mul( UNITY_MATRIX_MV, i.vertex ).z;	// compute vertex depth
//	            o.distortion /= 1+depth;		// scale effect with vertex depth
//	            o.distortion *= strength;	// multiply with user controlled strength
//	            o.screenPos = o.position;   // pass the position to the pixel shader
//	            return o;
//            }

//            fixed4 frag (v2f i) : SV_Target
//            {
//                // sample the texture
//                fixed4 col = tex2D(_MainTex, i.uv);
//                // apply fog
//                UNITY_APPLY_FOG(i.fogCoord, col);
//                return col;
//            }
//            ENDCG
//        }
//    }
//}
