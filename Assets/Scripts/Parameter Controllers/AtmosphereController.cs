using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AtmosphereController : MonoBehaviour
{
    public GameObject atmosphere;
    public Material atmosphereMaterial;
    public RawImage atmosphereColorPreview;
    public Material cloudsMaterial;

    public Slider cloudCoverageSlider;
    public Slider cloudDensitySlider;

    public Toggle atmosphereToggle;
    public TMP_InputField atmosphereDensityInput;
    public TMP_InputField atmosphereEdgeIntensityInput;

    public static AtmosphereController instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadFromPreset(PresetAdditions additions)
    {
        atmosphereToggle.isOn = additions.EnableAtmosphere;
        atmosphereDensityInput.text = additions.AtmosphereDensity.ToString();
        atmosphereEdgeIntensityInput.text = additions.EdgeIntensity.ToString();
        cloudCoverageSlider.value = additions.CloudCoverage;
        cloudDensitySlider.value = additions.CloudDensity;
        ApplyColor(additions.AtmosphereColor);
    }

    public void EnableAtmosphere(bool enable)
    {
        atmosphere.SetActive(enable);
    }

    public void SetAtmosphereDensity(string density)
    {
        atmosphereMaterial.SetFloat("_Intensity", float.Parse(density));
    }

    public void SetEdgeIntensity(string intensity)
    {
        atmosphereMaterial.SetFloat("_EdgeIntensity", float.Parse(intensity));
    }

    public void SetCloudCoverage()
    {
        float coverage = cloudCoverageSlider.value; 
        cloudsMaterial.SetFloat("_Amount", coverage);
    }

    public void SetCloudDensity()
    {
        float density = cloudDensitySlider.value;
        cloudsMaterial.SetFloat("_Strength", density);
    }

    public void SetAtmosphereColor()
    {
        Color color = atmosphereMaterial.GetColor("_Color");
        ColorPicker.Create(color, "Choose Atmosphere Color", ApplyColor, ColorFinished, true);
    }

    private void ApplyColor(Color currentColor)
    {
        atmosphereMaterial.SetColor("_Color", currentColor);
        atmosphereColorPreview.color = currentColor;
    }

    private void ColorFinished(Color finishedColor)
    {
        Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
    }
}