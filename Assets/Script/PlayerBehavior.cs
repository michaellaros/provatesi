using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior singleton;
    public float health = 100f;
    bool isInvincible;
    bool isHealing;
    public float invincibleTime;
    public float dealyHealingTime;
    public UnityEvent gameOverEvent;
    public GameObject spawnManager;
    public GameObject gun;
    private void OnEnable()
    {
        singleton = this;
        isInvincible = false;
        isHealing = true;
        StartCoroutine("Heal");
    }
    public void Start()
    {
        GameEvents.singleton.triggerHealPlayer += MageHeal;
    }
    public void Update()
    {
    }
    public void TakeDamage(float damage) {
        if (isInvincible)
        {
            isInvincible = true;
            isHealing = false;
            health -= 20f;
            StartCoroutine("isInvincibleFalse");
            StartCoroutine("isHealingTrue");
            if (health < 1)
            {
                //gameOverRoutine();
            }
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Material"))
        {
            //TODO aggiungere materiali al mago
        }

    }
    public void gameOverRoutine()
    {
        //ferma il gioco
        GetComponent<CapsuleCollider>().enabled = false;
        spawnManager.SetActive(false);
        gameOverEvent.Invoke();
    }
    IEnumerator isInvincibleFalse()
    {
        yield return new WaitForSeconds (invincibleTime);
        isInvincible = false;
    }
    IEnumerator isHealingTrue()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = true;
    }

    IEnumerator Heal()
    {
        while (true)
        {
            if (health != 100f && isHealing)
            { 
                health += 1f;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void MageHeal() {
        health += 200f;
    }
    private void OnDestroy() {

        GameEvents.singleton.triggerHealPlayer -= MageHeal;
    }
    
}
