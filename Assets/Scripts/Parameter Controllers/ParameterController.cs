using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParameterController : MonoBehaviour
{
    public ParameterList parameterList;
    public GameObject categoryPrefab;
    public GameObject numberPrefab;
    public GameObject rangePrefab;
    public GameObject booleanPrefab;
    public GameObject colorPrefab;
    public GameObject gradientPrefab;

    public Transform content;

    public Material material;
    public Gradient defaultGradient;

    public static ParameterController instance;

    struct parameterValue
    {
        public float floatValue;
        public bool boolValue;
        public Color colorValue;
        public Gradient gradientValue;
    }

    Dictionary<string, parameterValue> parameterValues;

    void Awake()
    {
        instance = this;
        parameterValues = new Dictionary<string, parameterValue>();
    }

    void Start()
    {
        foreach (var parameter in parameterList.parameters)
        {
            parameterValues[parameter.propertyName] = new parameterValue()
            {
                floatValue = 0.2f,
                boolValue = false,
                colorValue = Color.red,
                gradientValue = defaultGradient
            };
            GameObject prefab = null;
            switch (parameter.type)
            {
                case ParameterList.Parameter.ParameterType.Category:
                    prefab = categoryPrefab;
                    break;
                case ParameterList.Parameter.ParameterType.Number:
                    prefab = numberPrefab;
                    break;
                case ParameterList.Parameter.ParameterType.Range:
                    prefab = rangePrefab;
                    break;
                case ParameterList.Parameter.ParameterType.Boolean:
                    prefab = booleanPrefab;
                    break;
                case ParameterList.Parameter.ParameterType.Color:
                    prefab = colorPrefab;
                    break;
                case ParameterList.Parameter.ParameterType.Gradient:
                    prefab = gradientPrefab;
                    break;
            }
            var go = Instantiate(prefab, content);
            go.name = parameter.name + " Parameter";
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = parameter.name;
            switch (parameter.type)
            {
                case ParameterList.Parameter.ParameterType.Category:
                    break;
                case ParameterList.Parameter.ParameterType.Number:
                    go.transform
                        .GetChild(1)
                        .GetChild(0)
                        .GetComponent<NumberParameter>()
                        .propertyName = parameter.propertyName;
                    break;
                case ParameterList.Parameter.ParameterType.Range:
                    go.transform.GetChild(1).GetComponent<Slider>().minValue = parameter.min;
                    go.transform.GetChild(1).GetComponent<Slider>().maxValue = parameter.max;
                    go.transform.GetChild(1).GetComponent<RangeParameter>().propertyName =
                        parameter.propertyName;
                    break;
                case ParameterList.Parameter.ParameterType.Boolean:
                    go.transform.GetChild(1).GetComponent<BooleanParameter>().propertyName =
                        parameter.propertyName;
                    break;
                case ParameterList.Parameter.ParameterType.Color:
                    go.transform.GetChild(1).GetComponent<ColorParameter>().propertyName =
                        parameter.propertyName;
                    break;
                case ParameterList.Parameter.ParameterType.Gradient:
                    go.transform.GetChild(1).GetComponent<GradientParameter>().propertyName =
                        parameter.propertyName;
                    break;
            }
        }

        // Call updateUI after a few milliseconds
        Invoke("UpdateUI", 0.1f);
    }

    void PintParameterValues()
    {
        Debug.Log("########## Parameter Values: ##############");
        foreach (var parameter in parameterValues)
        {
            Debug.Log(parameter.Key + " " + parameter.Value.floatValue);
        }
    }

    public void InitializeType(ParameterList parameters, Material mat)
    {
        material = mat;
        parameterValues = new Dictionary<string, parameterValue>();
        parameterList = parameters;
        RemoveChildren();

        Start();
    }

    public void RemoveChildren()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadRockyPreset(RockyPreset preset)
    {
        parameterValues["MainSeed"] = new parameterValue() { floatValue = preset.MainSeed };
        parameterValues["PerlinScale"] = new parameterValue() { floatValue = preset.PerlinScale };
        parameterValues["RidgedScale"] = new parameterValue() { floatValue = preset.RidgedScale };
        parameterValues["UseRidgedOffset"] = new parameterValue() { boolValue = preset.UseRidgedOffset };
        parameterValues["NoiseMix"] = new parameterValue() { floatValue = preset.NoiseMix };
        parameterValues["EffectNoiseScale"] = new parameterValue() { floatValue = preset.EffectNoiseScale };
        parameterValues["EffectNoiseMix"] = new parameterValue() { floatValue = preset.EffectNoiseMix };
        parameterValues["BumpStrength"] = new parameterValue() { floatValue = preset.BumpStrength };
        parameterValues["MainGradient"] = new parameterValue() { gradientValue = preset.MainGradient };
        parameterValues["CratersSeed"] = new parameterValue() { floatValue = preset.CratersSeed };
        parameterValues["CratersSize"] = new parameterValue() { floatValue = preset.CratersSize };
        parameterValues["CraterStrength"] = new parameterValue() { floatValue = preset.CraterStrength };
        parameterValues["CratersBumpStrength"] = new parameterValue() { floatValue = preset.CratersBumpStrength };
        parameterValues["CratersCoverage"] = new parameterValue() { floatValue = preset.CratersCoverage };
        parameterValues["WaterLevel"] = new parameterValue() { floatValue = preset.WaterLevel };
        parameterValues["OceanColor"] = new parameterValue() { colorValue = preset.OceanColor };
        parameterValues["OceanSpecular"] = new parameterValue() { floatValue = preset.OceanSpecular };
        parameterValues["PolesSeed"] = new parameterValue() { floatValue = preset.PolesSeed };
        parameterValues["NorthpoleSize"] = new parameterValue() { floatValue = preset.NorthpoleSize };
        parameterValues["SouthpoleSize"] = new parameterValue() { floatValue = preset.SouthpoleSize };
        parameterValues["IceColor"] = new parameterValue() { colorValue = preset.IceColor };
        parameterValues["IceSpecular"] = new parameterValue() { floatValue = preset.IceSpecular };
        parameterValues["PolesNoiseScale"] = new parameterValue() { floatValue = preset.PolesNoiseScale };
        parameterValues["PolesNoiseMix"] = new parameterValue() { floatValue = preset.PolesNoiseMix };

        UpdateUI();
        UpdateMaterial();
    }

    public void LoadGasPreset(GasPreset preset)
    {
        parameterValues["MainGradient"] = new parameterValue() { gradientValue = preset.MainGradient };
        parameterValues["BumpStrength"] = new parameterValue() { floatValue = preset.BumpStrength };
        parameterValues["TurbulenceSeed"] = new parameterValue() { floatValue = preset.TurbulenceSeed };
        parameterValues["TurbulenceScale"] = new parameterValue() { floatValue = preset.TurbulenceScale };
        parameterValues["TurbulenceStrength"] = new parameterValue() { floatValue = preset.TurbulenceStrength };
        parameterValues["BandsSeed"] = new parameterValue() { floatValue = preset.BandsSeed };
        parameterValues["BandsNoiseScale"] = new parameterValue() { floatValue = preset.BandsNoiseScale };
        parameterValues["BandsNoiseMix"] = new parameterValue() { floatValue = preset.BandsNoiseMix };
        parameterValues["MainBandsFrequency"] = new parameterValue() { floatValue = preset.MainBandsFrequency };
        parameterValues["MainBandsPhase"] = new parameterValue() { floatValue = preset.MainBandsPhase };
        parameterValues["SecondaryBandsFrequency"] = new parameterValue() { floatValue = preset.SecondaryBandsFrequency };
        parameterValues["SecondaryBandsPhase"] = new parameterValue() { floatValue = preset.SecondaryBandsPhase };
        parameterValues["BandsRatio"] = new parameterValue() { floatValue = preset.BandsRatio };
        parameterValues["StormsSeed"] = new parameterValue() { floatValue = preset.StormsSeed };
        parameterValues["StormSize"] = new parameterValue() { floatValue = preset.StormSize };
        parameterValues["StormFalloff"] = new parameterValue() { floatValue = preset.StormFalloff };
        parameterValues["StormStrength"] = new parameterValue() { floatValue = preset.StormStrength };
        parameterValues["StormCoverage"] = new parameterValue() { floatValue = preset.StormCoverage };

        UpdateUI();
        UpdateMaterial();
    }

    public void LoadStarPreset(StarPreset preset)
    {
        parameterValues["EffectNoiseScale"] = new parameterValue() { floatValue = preset.EffectNoiseScale };
        parameterValues["EffectNoiseStrength"] = new parameterValue() { floatValue = preset.EffectNoiseStrength };
        parameterValues["NoiseScale"] = new parameterValue() { floatValue = preset.NoiseScale };
        parameterValues["NoiseFalloff"] = new parameterValue() { floatValue = preset.NoiseFalloff };
        parameterValues["Seed"] = new parameterValue() { floatValue = preset.Seed };
        parameterValues["Color"] = new parameterValue() { colorValue = preset.Color };
        parameterValues["Strength"] = new parameterValue() { floatValue = preset.Strength };

        UpdateUI();
        UpdateMaterial();
    }

    int GetPropertyIndex(string propertyName)
    {
        for (int i = 0; i < parameterList.parameters.Length; i++)
        {
            if (parameterList.parameters[i].propertyName == propertyName)
            {
                return i;
            }
        }
        return -1;
    }

    void Update()
    {
        UpdateMaterial();
    }

    void UpdateMaterial()
    {
        // foreach key in parameterValues
        // set material property
        foreach (string key in parameterValues.Keys)
        {
            int index = GetPropertyIndex(key);
            //Debug.Log(index);
            if (index >= 0)
            {
                material.SetFloat("_StormCoverage", 0.69f);

                string property = "_" + key;
                switch (parameterList.parameters[index].type)
                {
                    case ParameterList.Parameter.ParameterType.Number:
                        if (key == "EffectNoiseScale" || key == "PolesNoiseScale")
                        {
                            Vector3 noiseScale =
                                new Vector3(1, 2, 4) * parameterValues[key].floatValue;
                            material.SetVector(property, noiseScale);
                        }
                        else
                        {
                            material.SetFloat(property, parameterValues[key].floatValue);
                        }
                        break;
                    case ParameterList.Parameter.ParameterType.Range:
                        material.SetFloat(property, parameterValues[key].floatValue);
                        break;
                    case ParameterList.Parameter.ParameterType.Boolean:
                        material.SetInt(property, parameterValues[key].boolValue ? 1 : 0);
                        break;
                    case ParameterList.Parameter.ParameterType.Color:
                        material.SetColor(property, parameterValues[key].colorValue);
                        break;
                    case ParameterList.Parameter.ParameterType.Gradient:
                        Gradient gradient = parameterValues[key].gradientValue;

                        material.SetColor("_GradientColor1", gradient.colorKeys[0].color);
                        material.SetColor("_GradientColor2", gradient.colorKeys[1].color);
                        material.SetColor("_GradientColor3", gradient.colorKeys[2].color);
                        material.SetColor("_GradientColor4", gradient.colorKeys[3].color);

                        material.SetFloat("_GradientPosition1", gradient.colorKeys[0].time);
                        material.SetFloat("_GradientPosition2", gradient.colorKeys[1].time);
                        material.SetFloat("_GradientPosition3", gradient.colorKeys[2].time);
                        material.SetFloat("_GradientPosition4", gradient.colorKeys[3].time);

                        break;
                }
            }
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < parameterValues.Keys.Count; i++)
        {
            string key = parameterValues.ElementAt(i).Key;
            int index = GetPropertyIndex(key);
            if (index >= 0)
            {
                switch (parameterList.parameters[index].type)
                {
                    case ParameterList.Parameter.ParameterType.Number:
                        content
                            .GetChild(index)
                            .GetChild(1)
                            .GetChild(0)
                            .GetComponent<TMP_InputField>()
                            .text = parameterValues[key].floatValue.ToString();
                        break;
                    case ParameterList.Parameter.ParameterType.Range:
                        content.GetChild(index).GetChild(1).GetComponent<Slider>().value =
                            parameterValues[key].floatValue;
                        break;
                    case ParameterList.Parameter.ParameterType.Boolean:
                        content.GetChild(index).GetChild(1).GetComponent<Toggle>().isOn =
                            parameterValues[key].boolValue;
                        break;
                    case ParameterList.Parameter.ParameterType.Color:
                        content.GetChild(index).GetChild(1).GetComponent<Image>().color =
                            parameterValues[key].colorValue;
                        break;
                    case ParameterList.Parameter.ParameterType.Gradient:
                        Debug.Log("Gradient child: " + content.GetChild(index));
                        SetGradientUI(
                            content.GetChild(index).GetChild(1).GetComponent<RawImage>(),
                            parameterValues[key].gradientValue
                        );
                        break;
                }
            }
        }
    }

    void SetGradientUI(RawImage image, Gradient gradient)
    {
        Texture2D texture = new Texture2D(256, 1);
        for (int i = 0; i < 256; i++)
        {
            float t = (float)i / 255;
            texture.SetPixel(i, 0, gradient.Evaluate(t));
        }
        texture.Apply();
        image.texture = texture;
    }

    public void SetNumber(string propertyName, float value)
    {
        parameterValues[propertyName] = new parameterValue { floatValue = value };
    }

    public void SetBool(string propertyName, bool value)
    {
        parameterValues[propertyName] = new parameterValue { boolValue = value };
    }

    public void SetColor(string propertyName, Color value)
    {
        parameterValues[propertyName] = new parameterValue { colorValue = value };
    }

    public Color GetColor(string propertyName)
    {
        return parameterValues[propertyName].colorValue;
    }

    public void SetGradient(string propertyName, Gradient value)
    {
        parameterValues[propertyName] = new parameterValue { gradientValue = value };
    }

    public Gradient GetGradient(string propertyName)
    {
        return parameterValues[propertyName].gradientValue;
    }
}
