using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Preset Additions", menuName = "Preset Additions")]
public class PresetAdditions : ScriptableObject {

    public string presetName;

    [Header("Atmosphere Parameters")]
    public bool EnableAtmosphere;
    public float AtmosphereDensity;
    public float EdgeIntensity;
    public Color AtmosphereColor;
    public float CloudCoverage;
    public float CloudDensity;

    [Header("Ring Parameters")]
    public bool EnableRings;
    public float RingVisibility;
    public float RingSize;
    public float RingFalloff;
    public Color RingColor;

}