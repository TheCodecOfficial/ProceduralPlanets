using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanParameter : MonoBehaviour
{
    public string propertyName;
    
    public void SetBoolean(bool input)
    {
        ParameterController.instance.SetBool(propertyName, input);
    }
}