#ifndef PERLINNOISE3D_INCLUDED
#define PERLINNOISE3D_INCLUDED

#include "SimplexNoise.hlsl"

float Perlin(float3 uv, int octaves, float persistence, float lacunarity, float scale, int seed){

    float total = 0;
    float frequency = 1;
    float amplitude = 1;
    float maxValue = 0;
    float3 seedOffset = float3(1.0, 1.0, 1.0)*seed;
    for (int i = 0; i < octaves; i++){
        float3 coords = uv * scale * frequency + (i+1)*seedOffset;
        float noise = abs(snoise(coords));
        total += pow(noise, 0.5)*amplitude;
        maxValue += amplitude;
        amplitude *= persistence;
        frequency *= lacunarity;
    }
    return total/maxValue;
}

void RidgedMultifractal_float(float3 uv, int octaves, float persistence, float lacunarity, float scale, float power, int seed, out float color, out float color_normalized){

    float noise = Perlin(uv, octaves, persistence, lacunarity, scale, seed);

    noise = pow(noise, power);

    color_normalized = noise*power;
    color = (color_normalized - 0.5)*2;

}

#endif