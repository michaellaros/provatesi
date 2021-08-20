using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    [SerializeField]
    private float health;

    public float speed = 10f;
    public Transform pathToFollow;
    private Transform[] points;
    private Transform lastWaypoint;
    private int wavePointIndex;

    public void CreatePath() {
        points = new Transform[pathToFollow.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = pathToFollow.GetChild(i);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
