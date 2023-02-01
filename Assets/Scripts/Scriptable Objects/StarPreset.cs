using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Star Preset", menuName = "Star Preset")]
public class StarPreset : ScriptableObject {

    public string presetName;

    [Header("Main Parameters")]
    public float EffectNoiseScale;
    public float EffectNoiseStrength;
    public float NoiseScale;
    public float NoiseFalloff;
    public float Seed;
    public Color Color = Color.white;
    public float Strength;

    [Header("Additions")]
    public PresetAdditions additions;

}