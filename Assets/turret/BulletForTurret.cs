using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForTurret : MonoBehaviour
{
    public float movementSpeed;
    public GameObject target;
    private bool continueToFollow;

    public void Start()
    {
        continueToFollow = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (continueToFollow)
        {
            if (target != null)
            {
                FollowTarget();
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            }
            else {
                continueToFollow = false;
            }
        }
    }

    public void OnCollisionEnter(Collider other)
    {
        continueToFollow = false;
    }
    //script per seguire il nemico
    public void FollowTarget()
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        Vector3 currentDirection = transform.forward;
        float maxTurnSpeed = 90f; // degrees per second
        Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 10f);
        transform.rotation = Quaternion.LookRotation(resultingDirection);
    }
}