Shader "CustomRenderTexture/CustomTextureInit"
{
    Properties
    {
        _Tex("InputTex", 2D) = "white" {}
    }

        SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent"}
        Lighting Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"

            #pragma vertex InitCustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0

            sampler2D   _Tex;

            float4 frag(v2f_init_customrendertexture IN) : COLOR
            {
                float4 c = tex2D(_Tex, IN.texcoord.xy);
                c[3] = max(c[0], max(c[1], c[2]));
                return c;
            }
            ENDCG
        }
    }
}