using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stoppingDistance;

    NavMeshAgent agent;

    private Transform pathway;
    private Transform[] WaypointArray;
    private int currentWaypoint;
    private Transform nextWaypoint;
    private Transform target;    
    private GameObject _player;

    private Animator animator;
    private float health;

    public float minDistanceForNextWaypoint;
    public float distanceFromTarget;
    public float distanceFromWaypoint;
    public float distanceFromPlayer;
    public float minDistancePlayerChase;
    public float maxDistancePlayerChase;

    private bool obstacleFound;

    private void Start()
    {
        obstacleFound = false;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        currentWaypoint = 0;
        pathway = transform.parent.parent;
        WaypointArray = new Transform[pathway.childCount];
        for (int i = 0; i < pathway.childCount; i++)
        {
            WaypointArray[i] = pathway.GetChild(i);
        }
        nextWaypoint = WaypointArray[currentWaypoint];
        target = WaypointArray[currentWaypoint];

    }

    private void FixedUpdate()
    {
        SelectTarget();
        distanceFromTarget = Vector3.Distance(transform.position, target.position);
        if (distanceFromTarget < stoppingDistance)
        {
            animator.SetBool("IsMoving", false);
            StopEnemy();
            return;
        }
        else
        {
            animator.SetBool("IsMoving", true);
            GoToTarget();
        }
    }

    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0f) {
            Die();
        }
    }
    void Die() {
        //DropItem();
        Destroy(gameObject);
    }
    void DropItem() {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle")){
            obstacleFound = true;
        }
    }
    void SelectTarget() {
        distanceFromWaypoint = Vector3.Distance(transform.position, nextWaypoint.position);
        distanceFromPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (distanceFromPlayer < minDistancePlayerChase)
        {
            target = _player.transform;
        }
        if (distanceFromWaypoint < minDistanceForNextWaypoint){
            currentWaypoint++;
            try
            {
                nextWaypoint = WaypointArray[currentWaypoint];
            }
            catch {
                return;
            }
        }
        target = nextWaypoint;
    }

}
