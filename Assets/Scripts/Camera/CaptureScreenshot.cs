using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{

    [SerializeField] private string _path;

    void Start()
    {
        ScreenCapture.CaptureScreenshot("Assets/Screenshots/"+_path+".png");
    }
}