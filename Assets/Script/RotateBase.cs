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
    bool rotateX;
    bool rotateY;
    void Start() {
        canRotate = false;
    }

    private void Update()
    {
        if (canRotate)
        {
            if (rotateX && 
               (transform.eulerAngles.x + (rotation / rotationSpeed)) < maxRotationAngle &&
               (transform.eulerAngles.x + (rotation / rotationSpeed)) > minRotationAngle)
            {
                transform.Rotate(rotation / rotationSpeed, 0, 0);
            }
            if (rotateY &&
               (transform.eulerAngles.y + (rotation / rotationSpeed)) < maxRotationAngle &&
               (transform.eulerAngles.y + (rotation / rotationSpeed)) > minRotationAngle)
            {
                transform.Rotate(0, rotation / rotationSpeed, 0);
            }
        }
    }

    public void Rotate2X()
    {
        rotation = rotator.GetComponent<BNG.JoystickControl>().angleX;
    }
    public void Rotate2Y()
    {
        rotation = rotator.GetComponent<BNG.JoystickControl>().angleY;
    }
    public void canRotateTrue() {
        canRotate = true;
    }
    public void canRotateFalse() {
        canRotate = false;
    }
}
