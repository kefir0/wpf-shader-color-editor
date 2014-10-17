// no input texture, the output is completely generated in code
/// <summary>Input color to modify. R=uv.X, G=uv.Y, other components are left intact.</summary>
float4 inputColor : register(C0);
float4 main(float2 uv : TEXCOORD) : COLOR
{
	return float4(inputColor.r, uv.y, inputColor.b, inputColor.a);
}
