using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private Transform body = null;

    [SerializeField]
    private float sensitivity = 2.5f, maxY = 90f, minY = -90f;
    private float xRotation = 0f, yrotationOverClamp;

    [SerializeField]
    private bool  rotateX = false, rotateY = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xRotation = transform.rotation.eulerAngles.x;
    }

    void FixedUpdate()
    {
        if(rotateX) //X rotation SetUp (Left/Right)
            body.Rotate(Vector3.up* Input.GetAxis("Mouse X") * sensitivity);
        
        if(rotateY){ //Y rotation SetUp (Up/Down)
            xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
            xRotation = Mathf.Clamp(xRotation, minY, maxY);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    } 

}
