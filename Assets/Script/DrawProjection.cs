using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    public GameObject cannon;
    private Transform shootPoint;
    private float blastPower;
    LineRenderer lineRenderer;

    // Number of points on the line
    public int numPoints = 50;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        shootPoint = cannon.GetComponent<BNG.ProjectileLauncher>().MuzzleTransform;
        blastPower = cannon.GetComponent<BNG.ProjectileLauncher>().ProjectileForce;

    }


    void Update()
    {
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = shootPoint.position;
        Vector3 startingVelocity = shootPoint.forward * blastPower;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());
    }
}
