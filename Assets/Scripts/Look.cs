using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float Mouse_Sensitivity = 1000.0f;
    public Transform PlayerBody;
    public float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Mouse_Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Mouse_Sensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Math.Clamp(xRotation, -90f, 80f);
        transform.localRotation  = Quaternion.Euler(xRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up*MouseX);

    }
}
