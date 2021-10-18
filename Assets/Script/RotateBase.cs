using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour
{

    public Transform rotator;
    public float minRotationAngle;
    public float maxRotationAngle;
    public float rotationSpeed;
    [Space(20)]
    public Quaternion CurrentRotationDebug;
    private float rotation;
    bool canRotate;
    bool rotateX;
    bool rotateY;
    void Start() {
        canRotate = false;
    }

    private void Update()
    {
        CurrentRotationDebug = transform.localRotation;
        if (canRotate)
        {
           if(rotateX && (transform.eulerAngles.x + (rotation / rotationSpeed)) < maxRotationAngle &&
                    (transform.eulerAngles.x + (rotation / rotationSpeed)) > minRotationAngle)
            {
                transform.Rotate(rotation / rotationSpeed, 0, 0);
            }
            if (rotateY && (transform.eulerAngles.y + (rotation / rotationSpeed)) < maxRotationAngle &&
                    (transform.eulerAngles.y + (rotation / rotationSpeed)) > minRotationAngle)
            {
                transform.Rotate(0, rotation / rotationSpeed, 0);
            }
        }

    }

    public void Rotate2X()
    {
        if (canRotate)
        {
            try
            {

                rotation = rotator.GetComponent<BNG.JoystickControl>().angleX;
                if ((transform.eulerAngles.x + (rotation / rotationSpeed)) < maxRotationAngle &&
                    (transform.eulerAngles.x + (rotation / rotationSpeed)) > minRotationAngle)
                {
                    transform.Rotate(rotation / rotationSpeed, 0, 0);
                }
            }
            catch
            {
            }
        }
    }
    public void Rotate2Y()
    {
        if (canRotate)
        {
            try
            {
                rotation = rotator.GetComponent<BNG.JoystickControl>().angleY;
                if ((transform.localRotation.y + (rotation / rotationSpeed)) < maxRotationAngle &&
                    (transform.localRotation.y + (rotation / rotationSpeed)) > minRotationAngle)
                {
                    transform.Rotate(0, rotation / rotationSpeed, 0);
                }
                
            }
            catch
            {
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
