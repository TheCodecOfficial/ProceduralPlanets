using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Vector3 rotation, rotationAcc;
    Vector3 mousePos, mousePosDelta;

    [SerializeField] private float speed, slowdown;

    void Start(){
        rotation = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Drag mouse to rotate
        if (Input.GetMouseButtonDown(0) || UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            mousePos = Input.mousePosition;
        }
        // if mouse down and cursor not over UI
        if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            mousePosDelta = Input.mousePosition - mousePos;
            mousePos = Input.mousePosition;
            rotation += new Vector3(mousePosDelta.y, -mousePosDelta.x, 0);
        }
        transform.Rotate(rotation*speed*Time.deltaTime, Space.World);
        rotation *= (1-slowdown*Time.deltaTime);
    }
}
