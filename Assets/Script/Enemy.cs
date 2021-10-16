using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float objectiveDamage;
    public float attackRate;
    public Transform attackProjectile;
    public Transform spawnPointProjectile;
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

    [SerializeField] private float health;

    public float minDistanceForNextWaypoint;
    private float distanceFromTarget;
    private float distanceFromWaypoint;
    private float distanceFromPlayer;
    public float minDistancePlayerChase;
    public float maxDistancePlayerChase;

    private GameObject obstacleFound;

    public GameObject[] dopppedItem;
    public int minDrop;
    public int maxDrop;

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
            FollowTarget();
            StopEnemy();
            if (target == _player.transform && readyToAttack) {
                Shoot();
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
    void Shoot()
    {
        Transform _bullet = Instantiate(attackProjectile, spawnPointProjectile.position, spawnPointProjectile.rotation);
        _bullet.GetComponent<EnemyBullet>().target = _player;
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

    public void TakeDamage(float amount) {
        health -= amount;
        if (health <= 0f) {
            Die(true);
        }
    }
    void Die(bool drop) {
        if (drop)
        {
            DropItem();
            //ragdoll code
        }
        //add event to tell pc
        Destroy(gameObject);
    }
    void DropItem() {
        int dropNumber = Random.Range(minDrop, maxDrop);
        for (int i = 0; i < dropNumber; i++)
        {
            var drop = Instantiate(dopppedItem[Random.Range(0, dopppedItem.Length)], transform.position, transform.rotation);
            drop.GetComponent<Rigidbody>().AddForce(drop.transform.up * 500);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            obstacleFound = other.transform.gameObject;
        }
        if (other.CompareTag("Objective"))
        {
            obstacleFound.GetComponent<Objective>().TakeDamage(objectiveDamage);
            Die(false);
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
            return;
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
    public void FollowTarget()
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        Vector3 currentDirection = transform.forward;
        float maxTurnSpeed = 90f; // degrees per second
        Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 10f);
        transform.rotation = Quaternion.LookRotation(resultingDirection);
    }
}
