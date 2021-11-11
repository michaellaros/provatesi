using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private static int EnemyCount;
    public int id;
    //Variabili degli attacchi e vita
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float objectiveDamage;
    [SerializeField] private float attackRate;
    [SerializeField] private Transform attackProjectile;
    [SerializeField] private Transform spawnPointProjectile;
    private bool readyToAttack;
    [SerializeField] private float stoppingDistance;
    //Variabili del navmesh
    NavMeshAgent agent;
    private Transform pathway;
    private Transform[] WaypointArray;
    private int currentWaypoint;
    private Transform nextWaypoint;
    [SerializeField] private Transform target;    
    private GameObject _player;
    [SerializeField] private float minDistanceForNextWaypoint;
    private float distanceFromTarget;
    private float distanceFromWaypoint;
    private float distanceFromPlayer;
    [SerializeField] private float minDistancePlayerChase;
    [SerializeField] private float maxDistancePlayerChase;
    private GameObject obstacleFound;
    //varibili di animazione
    private Animator animator;
    private bool fullHealth = true;
    [SerializeField] private bool onFire;
    [SerializeField] private bool isParalyzed;
    //varibili dei drop
    [SerializeField] private GameObject[] droppedItem;
    [SerializeField] private int minDrop;
    [SerializeField] private int maxDrop;
    [SerializeField] private int dropNumber;
    //Lista dei Joint e loro collider
    [SerializeField] private List<GameObject> collidersAndJoints;
    //gameobj da istanziare se prende quel tipo di danno
    [SerializeField] private GameObject fireFX;
    [SerializeField] private GameObject iceFX;
    [SerializeField] private GameObject thunderFX;
    [SerializeField] private GameObject elementManager;
    //UI elements
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject slider;
    [SerializeField] private OscEnemySender OES;
    private Slider sliderhp;
    private Vector3 playerPositionSlider;

    private void Start()
    {
        //Setting enemy id
        EnemyCount = EnemyCount + 1;
        id = EnemyCount;
        //inizializing variables
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
        dropNumber = Random.Range(minDrop, maxDrop);
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
    public void TakeDamage(float amount) {
        fullHealth = false;
        if (!fullHealth)
            slider.SetActive(true);
        health -= amount;
        sliderhp.value = health;
        CheckForElement();
        if (health <= 0f) {
            Die(true);
        }
    }
    public void CheckForElement()
    {
        if (elementManager.GetComponent<CheckElement>().fire)
        {
            fireFX.SetActive(true);
            FireDebuff();
        }
        if (elementManager.GetComponent<CheckElement>().ice)
        {
            iceFX.SetActive(true);
            animator.speed = 0.5f;
            agent.speed = agent.speed / 2;
            //rallenta movimento ed animazione (plus, ogni hit aumenta il rallentamento, fino a x3)
        }
        if (elementManager.GetComponent<CheckElement>().thunder)
        {
            ThunderDebuff();
            //resetta eventuali animazioni ed attacchi ogni x tempo
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
            TakeDamage(2.5f);
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
        for (int i = 0; i < dropNumber; i++)
        {
            var drop = Instantiate(droppedItem[Random.Range(0, droppedItem.Length)], transform.position, transform.rotation);
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
        if(other.gameObject.CompareTag("FireZone"))
        {
            FireDebuff();
            fireFX.SetActive(true);
            //thunderFX.SetActive(true);
            //StartCoroutine(Paralysis());

            //iceFX.SetActive(true);
            //animator.speed = 0.5f;
            //agent.speed = agent.speed / 2;
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
    public float getHealth() {
        return health;
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


