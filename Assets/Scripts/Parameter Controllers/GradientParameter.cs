using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientParameter : MonoBehaviour
{
    public string propertyName;
    
    public void SetGradient()
    {
        Gradient gradient = ParameterController.instance.GetGradient(propertyName);
        GradientPicker.Create(gradient, "Gradient Picker", ApplyGradient, GradientFinished);
    }

    private void ApplyGradient(Gradient currentGradient)
    {
        ParameterController.instance.SetGradient(propertyName, currentGradient);
        ParameterController.instance.UpdateUI();
    }

    private void GradientFinished(Gradient finishedGradient)
    {
        Debug.Log("You chose a Gradient with " + finishedGradient.colorKeys.Length + " Color keys");
    }
}