using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour
{
    public Transform knob;
    public void Rotate() {
        transform.Rotate(0,knob.rotation.y,0);
    }
}
