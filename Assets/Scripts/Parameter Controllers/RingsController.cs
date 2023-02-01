using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RingsController : MonoBehaviour
{

    public GameObject rings;
    public Material ringMaterial;
    public RawImage ringColorPreview;
    public Slider ringVisibilitySlider;
    public Slider ringFalloffSlider;
    public Toggle ringToggle;
    public TMP_InputField ringSizeInput;

    public static RingsController instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadFromPreset(PresetAdditions additions)
    {
        ringToggle.isOn = additions.EnableRings;
        ringVisibilitySlider.value = additions.RingVisibility;
        ringFalloffSlider.value = additions.RingFalloff;
        ringSizeInput.text = additions.RingSize.ToString();
        ApplyColor(additions.RingColor);
    }

    public void SetRingSize(string size)
    {
        float sizeFloat = float.Parse(size);
        if (sizeFloat <= 0f) return;
        rings.transform.localScale = new Vector3(sizeFloat, sizeFloat, sizeFloat);
    }

    public void EnableRings(bool enable)
    {
        rings.SetActive(enable);
    }

    public void SetRingVisibility(float visibility)
    {
        ringMaterial.SetFloat("_Strength", visibility);
    }

    public void SetRingFalloff(float falloff)
    {
        ringMaterial.SetFloat("_Falloff", falloff);
    }

    public void SetRingColor()
    {
        Color color = ringMaterial.GetColor("_Color");
        ColorPicker.Create(color, "Choose Ring Color", ApplyColor, ColorFinished, true);
    }

    private void ApplyColor(Color currentColor)
    {
        ringMaterial.SetColor("_Color", currentColor);
        ringColorPreview.color = currentColor;
    }

    private void ColorFinished(Color finishedColor)
    {
        Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
    }
}