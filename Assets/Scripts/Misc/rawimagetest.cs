using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rawimagetest : MonoBehaviour
{
    // Start is called before the first frame update
    public Gradient gradient;
    private RawImage rawImage;


    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }
    void Update()
    {
        Color[] g = new Color[256];
        for (int i = 0; i < g.Length; i++)
        {
            g[i] = gradient.Evaluate(i / (float)g.Length);
        }
        Texture2D tex = new Texture2D(g.Length, 1)
        {
            wrapMode = TextureWrapMode.Clamp,
            filterMode = FilterMode.Bilinear
        };
        tex.SetPixels(g);
        tex.Apply();
        rawImage.texture = tex;
    }
}