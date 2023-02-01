using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresetLoader : MonoBehaviour
{
    public RockyPreset[] rockyPresets;
    private List<string> rockyPresetNames;
    public GasPreset[] gasPresets;
    private List<string> gasPresetNames;
    public StarPreset[] starPresets;
    private List<string> starPresetNames;

    public TMP_Dropdown dropdown;
    private int type = 0;

    public static PresetLoader instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rockyPresetNames = new List<string>();
        gasPresetNames = new List<string>();
        starPresetNames = new List<string>();

        foreach (RockyPreset p in rockyPresets)
        {
            rockyPresetNames.Add(p.presetName);
        }
        foreach (GasPreset p in gasPresets)
        {
            gasPresetNames.Add(p.presetName);
        }
        foreach (StarPreset p in starPresets)
        {
            starPresetNames.Add(p.presetName);
        }

        SetType(0);
    }

    public void SetType(int type)
    {
        this.type = type;

        switch (type)
        {
            case 0:
                dropdown.ClearOptions();
                dropdown.AddOptions(rockyPresetNames);
                break;
            case 1:
                dropdown.ClearOptions();
                dropdown.AddOptions(gasPresetNames);
                break;
            case 2:
                dropdown.ClearOptions();
                dropdown.AddOptions(starPresetNames);
                break;
            default:
                break;
        }

        Invoke("LoadFirst", 0.1f);
    }

    void LoadFirst(){
        LoadPreset(0);
    }
    public void LoadPreset(int index)
    {
        PresetAdditions additions;
        Debug.Log("Loading preset " + index + " of type " + type);
        switch (type){
            case 0:
                ParameterController.instance.LoadRockyPreset(rockyPresets[index]);
                additions = rockyPresets[index].additions;
                break;
            case 1:
                ParameterController.instance.LoadGasPreset(gasPresets[index]);
                additions = gasPresets[index].additions;
                break;
            case 2:
                ParameterController.instance.LoadStarPreset(starPresets[index]);
                additions = starPresets[index].additions;
                break;
            default:
                additions = null;
                break;
        }
        AtmosphereController.instance.LoadFromPreset(additions);
        RingsController.instance.LoadFromPreset(additions);
    }
}
