using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private Transform body = null;

    [SerializeField]
    private float sensitivity = 100f, maxY = 90f, minY = -90f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        //X rotation SetUp (Left/Right)
        body.Rotate(Vector3.up* Input.GetAxis("Mouse X") * sensitivity);

        //Y rotation SetUp (Up/Down)
        xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    } 
}
