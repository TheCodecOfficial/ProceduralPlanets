#ifndef PERLINNOISE3D_INCLUDED
#define PERLINNOISE3D_INCLUDED

#include "SimplexNoise.hlsl"

void Perlin_float(float3 uv, int octaves, float persistence, float lacunarity, float scale, int seed, out float color, out float color_normalized){
    float total = 0;
    float frequency = 1;
    float amplitude = 1;
    float maxValue = 0;
    float3 seedOffset = float3(1.0, 1.0, 1.0)*seed;
    for (int i = 0; i < octaves; i++){
        float3 coords = uv * scale * frequency + i*seedOffset;
        total += snoise(coords)*amplitude;
        maxValue += amplitude;
        amplitude *= persistence;
        frequency *= lacunarity;
    }
    color = total/maxValue;
    color_normalized = (color + 1)/2;
}

#endif