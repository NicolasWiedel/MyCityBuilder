﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3? basePointerPosition = null;
    private float cameraMovementSpeed = 0.001f;
    private int cameraXMin, cameraXMax, cameraZMin, cameraZMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(Vector3 pointerPosition)
    {
        if (!basePointerPosition.HasValue)
        {
            basePointerPosition = pointerPosition;
        }
        Vector3 newPosition = pointerPosition - basePointerPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);
        transform.Translate(newPosition * cameraMovementSpeed);
        LimitPositionInsideCameraBounds();
    }

    private void LimitPositionInsideCameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraXMin, cameraXMax),
            0,
            Mathf.Clamp(transform.position.z, cameraZMin, cameraZMax)
            );
    }

    public void StopCameraMovement()
    {
        basePointerPosition = null;
    }

    public void SetCameraLimits(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax)
    {
        this.cameraXMin = cameraXMin;
        this.cameraXMax = cameraXMax;
        this.cameraZMin = cameraZMin;
        this.cameraZMax = cameraZMax;
    }
}
