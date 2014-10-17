float4 inputColor : register(c0);
//float4 uvx_mask : register(c1); //e.g. (0,0,1,0)
//float4 uvy_mask : register(c2); // e.g. (0,0,0,1)

float4 main(float2 uv : TEXCOORD) : COLOR
{    
  float4 color = 0;
  float4 uvx_mask = {1,0,0,0};
  float4 uvy_mask = {0,1,0,0};

  // replacing uvx channel with uv.x
  color = lerp(inputColor, uv.x * uvx_mask, uvx_mask); 
  // replacing uvy channel with uv.y
  color = lerp(color , uv.y * uvy_mask, uvy_mask);

  return color;
}