using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeParameter : MonoBehaviour
{
    public string propertyName;

    public void SetRange()
    {
        var input = GetComponent<UnityEngine.UI.Slider>().value;
        ParameterController.instance.SetNumber(propertyName, input);
    }
}
