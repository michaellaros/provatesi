using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float attackRate;
    private bool readyToAttack;
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

    private GameObject obstacleFound;

    private void Start()
    {
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
        readyToAttack = true;
    }

    private void FixedUpdate()
    {
        if (obstacleFound!=null) {
            StopEnemy();
            if (readyToAttack)
            {
                try
                {
                    obstacleFound.GetComponent<Door>().TakeDamage(damage);
                    Attack();
                }
                catch
                {
                    Debug.Log("Non ha un componente door");
                }
            }
            return;
        }
        SelectTarget();
        distanceFromTarget = Vector3.Distance(transform.position, target.position);
        if (distanceFromTarget < stoppingDistance)
        {
            StopEnemy();
            if (target == _player.transform && readyToAttack) {
                Attack();
            }
            return;
        }
        else
        {
            GoToTarget();
        }
    }

    private void Attack() {
        //animator attack TODO
        readyToAttack = false;
        Invoke("AgainReadyToAttack", attackRate);
    }

    private void GoToTarget()
    {
        animator.SetBool("IsMoving", true);
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    private void StopEnemy()
    {
        animator.SetBool("IsMoving", false);
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

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Obstacle"))
        {
            obstacleFound = other.transform.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            obstacleFound = null;
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
    void AgainReadyToAttack() {
        readyToAttack = true;
    }
}
