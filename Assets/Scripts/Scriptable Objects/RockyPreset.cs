using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Rocky Planet Preset", menuName = "Rocky Preset")]
public class RockyPreset : ScriptableObject {

    public string presetName;

    [Header("Main Parameters")]
    public float MainSeed;
    public float PerlinScale;
    public float RidgedScale;
    public bool UseRidgedOffset;
    public float NoiseMix;
    public float EffectNoiseScale;
    public float EffectNoiseMix;
    public float BumpStrength;

    [Header("Color Parameters")]
    public Gradient MainGradient;

    [Header("Crater Parameters")]
    public float CratersSeed;
    public float CratersSize;
    public float CraterStrength;
    public float CratersBumpStrength;
    public float CratersCoverage;

    [Header("Ocean Parameters")]
    public float WaterLevel;
    public Color OceanColor;
    public float OceanSpecular;

    [Header("Pole Parameters")]
    public float PolesSeed;
    public float NorthpoleSize;
    public float SouthpoleSize;
    public Color IceColor;
    public float IceSpecular;
    public float PolesNoiseScale;
    public float PolesNoiseMix;

    [Header("Additions")]
    public PresetAdditions additions;

}