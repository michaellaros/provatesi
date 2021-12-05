using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBehaviour : MonoBehaviour
{ 
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndScreen"))
        {
            Destroy(this.gameObject);
        }
    }

}
