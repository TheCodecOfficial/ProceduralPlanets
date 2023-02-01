using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceCamera : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        // Rotate such that the y axis is always facing the camera
        transform.LookAt(cam);
        transform.Rotate(90, 0, 0);
    }
}
