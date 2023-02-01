#ifndef PERLINNOISE_INCLUDED
#define PERLINNOISE_INCLUDED

#include "SimplexNoise.hlsl"

void Perlin_float(float3 uv, int octaves, float persistence, float lacunarity, float scale, int seed, out float color, out float color_normalized){
    float total = 0;
    float frequency = 1;
    float amplitude = 1;
    float maxValue = 0;
    float3 seedOffset = float3(1.0, 1.0, 1.0)*seed;
    for (int i = 0; i < octaves; i++){
        total += snoise(uv * scale * frequency + 1000.0*i + 10*seedOffset) * amplitude;
        maxValue += amplitude;
        amplitude *= persistence;
        frequency *= lacunarity;
    }
    color = total/maxValue;
    color_normalized = (color + 1)/2;
}

void Perlin4D_float(float4 uv, int octaves, float persistence, float lacunarity, float scale, int seed, out float color, out float color_normalized){
    float total = 0;
    float frequency = 1;
    float amplitude = 1;
    float maxValue = 0;
    float4 seedOffset = float4(1.0, 1.0, 1.0, 1.0)*seed;
    for (int i = 0; i < octaves; i++){
        total += snoise(uv * scale * frequency + 1000.0*i + 10*seedOffset) * amplitude;
        maxValue += amplitude;
        amplitude *= persistence;
        frequency *= lacunarity;
    }
    color = total/maxValue;
    color_normalized = (color + 1)/2;
}

#endif