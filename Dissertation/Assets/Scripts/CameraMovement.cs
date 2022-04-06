﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    public bool camerarotation = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void LateUpdate()
    {
        CameraUpdater();
        
    }

    void CameraUpdater()     //Set target object
    {
        if (camerarotation == true)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        
    }
}
