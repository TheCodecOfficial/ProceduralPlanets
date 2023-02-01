using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeController : MonoBehaviour
{
    public Material rockyPlanetMaterial, gasPlanetMaterial, starMaterial;
    public ParameterList rockyParameters, gasParameters, starParameters;

    public GameObject planet;
    private Renderer planetRenderer;

    void Start()
    {
        planetRenderer = planet.GetComponent<Renderer>();
    }
    void SelectRocky()
    {
        planetRenderer.material = rockyPlanetMaterial;
        ParameterController.instance.InitializeType(rockyParameters, rockyPlanetMaterial);

        PresetLoader.instance.SetType(0);
    }

    void SelectGas()
    {
        planetRenderer.material = gasPlanetMaterial;
        ParameterController.instance.InitializeType(gasParameters, gasPlanetMaterial);

        PresetLoader.instance.SetType(1);
    }

    void SelectStar()
    {
        planetRenderer.material = starMaterial;
        ParameterController.instance.InitializeType(starParameters, starMaterial);

        PresetLoader.instance.SetType(2);
    }

    public void SelectType(int type)
    {
        switch (type)
        {
            case 0:
                SelectRocky();
                break;
            case 1:
                SelectGas();
                break;
            case 2:
                SelectStar();
                break;
            default:
                break;
        }
    }
}