Shader "Custom/SmoothOutline" {
	Properties {
		_AlbedoColor ("Albedo", Color) = (1,1,1,1)
		_OutlineColor ("Outline Color", Color) = (1,1,1,1)
		_OutlineWidth ("Outline width", Range(0,10)) = 5.0
	}

    CGINCLUDE

    #include "UnityCG.cginc"

    struct appdata
    {
        float4 vertex : POSITION;
		float3 normal : NORMAL;
    };
    
    struct v2f
    {
        float4 position : SV_POSITION;
		float3 normal : NORMAL;
    };
    
	float _OutlineWidth;
	float4 _OutlineColor;

	v2f vert(appdata v){
		v.vertex.xyz *= _OutlineWidth;

        v2f o;
        o.position = UnityObjectToClipPos (v.vertex);
        return o;
	}

    ENDCG
	
	SubShader {

		PASS { // Render the outline 
			ZWrite on
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i):COLOR{
				return _OutlineColor;
			}


			ENDCG
		}

		PASS{ // Normal render

		ZWrite on

		Material{
			Diffuse[_AlbedoColor]
			Ambient[_AlbedoColor]
		}

		Lighting on

		
		Combine previous* primary double

		}
	}
	FallBack "Diffuse"
}
