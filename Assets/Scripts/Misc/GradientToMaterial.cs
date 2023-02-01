using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GradientToMaterial : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private Material material;

    void Update()
    {
        if (gradient.colorKeys.Length != 4)
        {
            return;
        }

        material.SetColor("_GradientColor1", gradient.colorKeys[0].color);
        material.SetColor("_GradientColor2", gradient.colorKeys[1].color);
        material.SetColor("_GradientColor3", gradient.colorKeys[2].color);
        material.SetColor("_GradientColor4", gradient.colorKeys[3].color);

        material.SetFloat("_GradientPosition1", gradient.colorKeys[0].time);
        material.SetFloat("_GradientPosition2", gradient.colorKeys[1].time);
        material.SetFloat("_GradientPosition3", gradient.colorKeys[2].time);
        material.SetFloat("_GradientPosition4", gradient.colorKeys[3].time);
    }
}
