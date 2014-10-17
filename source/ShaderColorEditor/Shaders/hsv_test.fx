// no input texture, the output is completely generated in code
/// <summary>Input color to modify. R=uv.X, G=uv.Y, other components are left intact.</summary>
float4 inputColor : register(C0);

float3 RgbToHsv(float3 rgb)
{
	float mn = min(min(rgb.r, rgb.g), rgb.b);
	float mx = max(max(rgb.r, rgb.g), rgb.b);
	
	float saturation = mx == 0 ? 0 : 1 - (1 * mn/mx);
	float chroma = mx-mn;
	float hue = 0;
	if(chroma != 0)
  {
    if(mx == rgb.r)
    {
      hue = ((rgb.g - rgb.b) / chroma) % 6;
    }   
    else if (mx == rgb.g)
    {
      hue = (rgb.b - rgb.r) / chroma + 2;
    }
    else if (mx == rgb.b)
    {
      hue = (rgb.r - rgb.g) / chroma + 4;
    }
    hue = hue / 6; // to 0-1 range
    if (hue < 0) hue += 1; // wrap around
  }	
	
	return float3(hue, saturation, mx);
}


float4 main(float2 uv : TEXCOORD) : COLOR
{
	float3 rgb = float3(inputColor.r, inputColor.g, inputColor.b);
	float3 hsv = RgbToHsv(rgb);
	return float4 (hsv.r, hsv.g, hsv.b, inputColor.a);
}

