using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorParameter : MonoBehaviour
{
    public string propertyName;
    
    public void SetColor()
    {
        Color color = ParameterController.instance.GetColor(propertyName);
        ColorPicker.Create(color, "Choose Color", ApplyColor, ColorFinished, true);
    }

    private void ApplyColor(Color currentColor)
    {
        ParameterController.instance.SetColor(propertyName, currentColor);
        ParameterController.instance.UpdateUI();
    }

    private void ColorFinished(Color finishedColor)
    {
        Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
    }
}