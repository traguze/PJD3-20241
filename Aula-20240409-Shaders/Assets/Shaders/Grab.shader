Shader "PJD3/GrabPassInvert"
{
    Properties {
	    _Color("Color",Color) = (1,1,1,1)
        _NoiseTex ("Noise Texture (RG)", 2D) = "white" {}
        strength("strength", Range(0.1, 0.3)) = 0.2
        transparency("transparency", Range(0.01, 0.1)) = 0.05
        _Speed("Speed", float) = 1.0
    }
    SubShader
    {
        // Draw after all opaque geometry
        Tags { "Queue" = "Transparent" }

        // Grab the screen behind the object into _BackgroundTexture
        GrabPass
        {
            "_BackgroundTexture"
        }

        // Render the object with the texture generated above, and invert the colors
        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float4 pos : SV_POSITION;
                float2 uvmain : TEXCOORD2;
                //float viewAngle : TEXCOORD3;
            };

            float4 _NoiseTex_ST;
            sampler2D _NoiseTex;
            float strength;
            float transparency;
            half4 _Color;
            float _Speed;
            sampler2D _BackgroundTexture;

            v2f vert(appdata_base v) {
                v2f o;
                // use UnityObjectToClipPos from UnityCG.cginc to calculate 
                // the clip-space of the vertex
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uvmain = TRANSFORM_TEX(v.texcoord, _NoiseTex);
                // use ComputeGrabScreenPos function from UnityCG.cginc
                // to get the correct texture coordinate
                o.grabPos = ComputeGrabScreenPos(o.pos);
                
                //float noise = tex2Dlod(_NoiseTex, float4(v.texcoord.xy, 0, 0)).rgb;
                float noise = tex2Dlod(_NoiseTex, float4(o.uvmain.xy, 0, 0)).rgb;

                o.grabPos.x += cos(noise*_Time.x*_Speed) * strength;
                o.grabPos.y += sin(noise*_Time.x*_Speed) * strength;

             //   float2 viewAngle = float2(dot(normalize(ObjSpaceViewDir(i.vertex)), i.normal),0);
	            //o.viewAngle = viewAngle;
                return o;
            }
            

            half4 frag(v2f i) : SV_Target
            {
                //float2 screenPos = i.pos.xy / i.pos.w;   // screenpos ranges from -1 to 1
                //screenPos.x = (screenPos.x + 1) * 0.5;   // I need 0 to 1
                //screenPos.y = (screenPos.y + 1) * 0.5;   // I need 0 to 1

                //half4 offsetColor1 = tex2D(_NoiseTex, i.uvmain + _Time.xz);
                //half4 offsetColor2 = tex2D(_NoiseTex, i.uvmain - _Time.yx);

                //screenPos.x += ((offsetColor1.r + offsetColor2.r) - 1); // * i.distortion;
                //screenPos.y += ((offsetColor1.g + offsetColor2.g) - 1); // * i.distortion;
   
                //float2 uv = float2(screenPos.x,1-screenPos.y);
                //half4 col = tex2D( _BackgroundTexture, uv );// * _Color;

                //col.a = _Color.a;

                //return col;
                float4 gp = i.grabPos;
                //gp.x += screenPos.x;
                //gp.y += screenPos.y;
                //gp = ComputeGrabScreenPos(i.pos);
                half4 bgcolor = tex2Dproj(_BackgroundTexture, gp);
                //return 1 - bgcolor;
                return bgcolor;
            }
            ENDCG
        }

    }
}