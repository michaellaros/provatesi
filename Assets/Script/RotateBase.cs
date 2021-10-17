using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour
{

    public Transform rotator;

    public void RotateY()
    {
        transform.Rotate(0, rotator.rotation.y, 0);
    }
    public void RotateX()
    {
        transform.Rotate(rotator.rotation.x,0, 0);
    }
}
