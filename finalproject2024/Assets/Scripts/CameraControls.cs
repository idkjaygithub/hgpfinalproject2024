using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
     // The object the camera will follow
    public GameObject target; // Assign in editor

    // The offset distance between the camera & the target
    public Vector3 posOffset; // Assign in editor

    // Start is called before the first frame update
    void Start()
    { 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        posOffset = transform.position - target.transform.position; // Calculate the distance between the target and the camera
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + posOffset; // move the camera to follow the target using the offset
    }
}
