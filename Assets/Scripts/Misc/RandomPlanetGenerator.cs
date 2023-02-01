using UnityEngine;

public class RandomPlanetGenerator : MonoBehaviour
{
    [SerializeField] private Material planetMat;
    [SerializeField] private Material atmosphereMat;


    void Start()
    {
        RandomizePlanetMaterials();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) RandomizePlanetMaterials();
    }

    void RandomizePlanetMaterials(){

        Vector3 effectNoiseScale = Random.insideUnitSphere * 8f;
        float effectNoiseStrength = Random.Range(0.01f, 0.3f);
        float noiseScale = Random.Range(0.6f, 2.5f);
        float noiseFalloff = Random.Range(0.5f, 3f);

        float seed = Random.value*1000f;
        float bumpStrenghth = Random.Range(-0.005f, 0.005f);

        Color gradientColor1 = Random.ColorHSV(0f, 1f, 0f, 0.3f, 0f, 1f);
        Color gradientColor2 = Random.ColorHSV(0f, 1f, 0f, 0.3f, 0f, 1f);
        Color gradientColor3 = Random.ColorHSV(0f, 1f, 0f, 0.3f, 0f, 1f);
        Color gradientColor4 = Random.ColorHSV(0f, 1f, 0f, 0.3f, 0f, 1f);

        float[] gradientPositions = new float[]{Random.value, Random.value, Random.value, Random.value};
        System.Array.Sort(gradientPositions);
        float gradientPosition1 = gradientPositions[0];
        float gradientPosition2 = gradientPositions[1];
        float gradientPosition3 = gradientPositions[2];
        float gradientPosition4 = gradientPositions[3];

        planetMat.SetVector("_EffectNoiseScale", effectNoiseScale);
        planetMat.SetFloat("_EffectNoiseStrength", effectNoiseStrength);
        planetMat.SetFloat("_NoiseScale", noiseScale);
        planetMat.SetFloat("_NoiseFalloff", noiseFalloff);
        planetMat.SetFloat("_Seed", seed);
        planetMat.SetFloat("_BumpStrength", bumpStrenghth);
        planetMat.SetColor("_GradientColor1", gradientColor1);
        planetMat.SetColor("_GradientColor2", gradientColor2);
        planetMat.SetColor("_GradientColor3", gradientColor3);
        planetMat.SetColor("_GradientColor4", gradientColor4);
        planetMat.SetFloat("_GradientPosition1", gradientPosition1);
        planetMat.SetFloat("_GradientPosition2", gradientPosition2);
        planetMat.SetFloat("_GradientPosition3", gradientPosition3);
        planetMat.SetFloat("_GradientPosition4", gradientPosition4);
    }
}
