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
    public GameObject spawners;
    public GameObject gun;
    private void OnEnable()
    {
        singleton = this;
        isInvincible = false;
        isHealing = true;
        StartCoroutine("Heal");
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
            Invoke("isInvincibleFalse", invincibleTime);
            Invoke("isHealingTrue", invincibleTime);
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
        spawners.SetActive(false);
        gameOverEvent.Invoke();
    }
    public void isInvincibleFalse()
    {
        isInvincible = false;
    }
    public void isHealingTrue()
    {
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
            yield return new WaitForSeconds(0.2f);
        }
    }
}
