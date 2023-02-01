using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberParameter : MonoBehaviour
{
    public string propertyName;
    
    public void SetNumber(string input)
    {
        float f = (input == "") ? 0 : float.Parse(input);
        ParameterController.instance.SetNumber(propertyName, f);
    }
}