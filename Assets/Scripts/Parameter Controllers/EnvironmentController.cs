using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentController : MonoBehaviour
{
    public Light sun;
    public Material skybox;

    public RawImage sunColorPreview;

    public void SetLightColor()
    {
        Color color = sun.color;
        ColorPicker.Create(color, "Choose Light Color", ApplyColor, ColorFinished, true);
    }

    private void ApplyColor(Color currentColor)
    {
        sun.color = currentColor;
        sunColorPreview.color = currentColor;
    }

    private void ColorFinished(Color finishedColor)
    {
        Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
    }

    public void SetLightIntensity(float intensity)
    {
        sun.intensity = intensity;
    }

    public void ChangeStarAmount(float amount)
    {
        amount = 1100 - amount;
        skybox.SetFloat("_Falloff", amount); 
    }
}