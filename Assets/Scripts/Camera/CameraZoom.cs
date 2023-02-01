using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minZ,
        maxZ;
    public float zoomSpeed = 10;
    float z = -3.5f;

    void Update()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            z = Mathf.Clamp(z + Input.GetAxis("Mouse ScrollWheel") * 10, -maxZ, -minZ);
        }
        transform.position = new Vector3(
            0,
            0,
            Mathf.Lerp(transform.position.z, z, Time.deltaTime * zoomSpeed)
        );
    }
}
