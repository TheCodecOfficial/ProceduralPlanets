using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Gas Planet Preset", menuName = "Gas Preset")]
public class GasPreset : ScriptableObject {

    public string presetName;

    [Header("Main Parameters")]
    public Gradient MainGradient;
    public float BumpStrength;

    [Header("Turbulence Parameters")]

    public float TurbulenceSeed;
    public float TurbulenceScale;
    public float TurbulenceStrength;

    [Header("Bands Parameters")]
    public float BandsSeed;
    public float BandsNoiseScale;
    public float BandsNoiseMix;
    public float MainBandsFrequency;
    public float MainBandsPhase;
    public float SecondaryBandsFrequency;
    public float SecondaryBandsPhase;
    public float BandsRatio;

    [Header("Storm Parameters")]
    public float StormsSeed;
    public float StormSize;
    public float StormFalloff;
    public float StormStrength;
    public float StormCoverage;

    [Header("Additions")]
    public PresetAdditions additions;

}