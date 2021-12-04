using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public List <GameObject> collidersAndJoints;
    public GameObject fireFX;
    public GameObject iceFX;
    public GameObject thunderFX;
    public GameObject elementManager;
    public GameObject canvas;
    public GameObject slider;
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
    [SerializeField]
    private Transform target;    
    private GameObject _player;

    private Animator animator;
    private bool fullHealth = true;
    public bool onFire;
    public bool isParalyzed;

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
    private Slider sliderhp;
    
    private Vector3 playerPositionSlider;
    
    
    private void Start()
    {
        onFire = false;
        isParalyzed = false;
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
        sliderhp = slider.GetComponent<Slider>();
        sliderhp.maxValue = health;
        
        
    }

    private void FixedUpdate()
    {
        
        


            //canvas.transform.LookAt(playerPositionSlider);
            if (obstacleFound != null)
            {
                StopEnemy();
                if (readyToAttack)
                {
                    try
                    {
                        if(onFire)
                    {
                        obstacleFound.GetComponent<Door>().TakeDamage(damage / 2);
                    }
                        
                        else
                    {
                        obstacleFound.GetComponent<Door>().TakeDamage(damage);
                    }
                        
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
                if (target == _player.transform && readyToAttack)
                {
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
    //element 0 = none, 1 = fire, 2 = ice, 3 = thunder
    public void TakeDamage(float amount, int element) {
        fullHealth = false;
        if (!fullHealth)
            slider.SetActive(true);
        health -= amount;
        sliderhp.value = health;
        switch (element)
        {
            case 0:
                break;
            case 1:
                fireFX.SetActive(true);
                FireDebuff();
                break;
            case 2:
                iceFX.SetActive(true);
                animator.speed = 0.5f;
                agent.speed = agent.speed / 2;
                break;
            case 3:
                ThunderDebuff();
                break;
        }

        
        if (health <= 0f) {
            Die(true);
        }
    }
    void ThunderDebuff()
    {
        if (!isParalyzed)
        {
            isParalyzed = true;
            thunderFX.SetActive(true);
            StartCoroutine(Paralysis());
        }
    }
    IEnumerator Paralysis()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if(Random.Range(0, 100)< 60)
            {
                animator.speed = 0;
                agent.speed = 0;
            }
            else
            {
                animator.speed = 1;
                agent.speed = 8;
            }
        }
        animator.speed = 1;
        agent.speed = 8;
        isParalyzed = false;
        thunderFX.SetActive(false);
    }
    IEnumerator DamageOverTime()
    {
        for (int ripetizione = 1; ripetizione < 10; ripetizione++)
        {
            TakeDamage(2.5f,0);
            yield return new WaitForSeconds(0.5f);
            

        }
        onFire = false;
        fireFX.SetActive(false);
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
            drop.GetComponent<Rigidbody>().AddForce(drop.transform.up * 3);
        }
    }

    void FireDebuff()
    {
        if(!onFire)
        {
            onFire = true;
            StartCoroutine(DamageOverTime());
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("entro trigger");
        if (other.gameObject.CompareTag("FireZone"))
        {
            
            FireDebuff();
            fireFX.SetActive(true);
            

            
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
                obstacleFound = other.transform.gameObject;
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
//public void TakeExplosion(float explosionForce, Vector3 explosionCenter, float explosionRadius)
//{

//    //DisableMovement();



//    //StartCoroutine(WaitToGetUp());


//}


//public void DisableMovement()
//{

//    collidersAndJoints[0].GetComponent<CapsuleCollider>().enabled = false;
//    collidersAndJoints[0].GetComponent<Rigidbody>().isKinematic = true;
//    for (int i = 1; i < collidersAndJoints.Count; i++)

//    {
//        collidersAndJoints[i].GetComponent<Collider>().enabled = true;
//    }

//    animator.enabled = false;
//    agent.enabled = false;
//}
//IEnumerator WaitToGetUp()
//{
//    yield return new WaitForSeconds(4);
//    EnableMovement();
//}


