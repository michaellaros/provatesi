using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour
{

    public Transform rotator;
    public float minRotationAngle;
    public float maxRotationAngle;
    public float rotationSpeed;

    private float rotation;
    public bool canRotate;
    public bool rotateX;
    public bool rotateY;
    void Start() {
        canRotate = false;
    }

    private void Update()
    {
        if (canRotate)
        { 
            if (rotateX)
            {
                rotation = rotator.GetComponent<BNG.JoystickControl>().angleX;
                transform.Rotate(rotation / rotationSpeed, 0, 0);
                
                if (((transform.eulerAngles.x + (rotation / rotationSpeed)) < maxRotationAngle) &&
                   ((transform.eulerAngles.x + (rotation / rotationSpeed)) > minRotationAngle))
                {
                    //transform.Rotate(rotation / rotationSpeed, 0, 0);
                }
            }
            if (rotateY)
            {
                rotation = rotator.GetComponent<BNG.JoystickControl>().angleY;
                transform.Rotate(0, rotation / rotationSpeed, 0);
            }
        }
    }
    public void canRotateTrue() {
        canRotate = true;
    }
    public void canRotateFalse() {
        canRotate = false;
    }
}
