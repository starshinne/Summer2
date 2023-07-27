using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Basic Data")]
    static public float maxHealth = 100;
    static public float currentHealth = 100;
    public PlayerMove playerMove;

    [Header("Invincible Data")]
    public float inVincinbleDuration;
    public bool isDead;
    private float inVincinbleCounter;
    private bool Invincible;
    public Animator animator;
    HealthController healthcontroller;
    private void Start()
    {
        currentHealth = maxHealth;
        playerMove = GetComponent<PlayerMove>();
        animator.GetComponent<Animator>();
        healthcontroller = GameObject.Find("HealthBar").GetComponent<HealthController>();
    }
    private void Update()
    {
        if (Invincible)
        {
            inVincinbleCounter -= Time.deltaTime;
        }
        if (inVincinbleCounter <= 0)
        {
            Invincible = false;
        }
    }


    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent WhenDead;

    public void TakeDamage(Attack attacker)
    {
        if (Invincible)
            return;
        if (currentHealth - attacker.Damage > 0)
        {
            healthcontroller.changeHealth(-attacker.Damage);
            inVincinble();
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            healthcontroller.changeHealth(-currentHealth);
            WhenDead.Invoke();
        }

    }

    public void inVincinble()
    {
        Invincible = true;
        inVincinbleCounter = inVincinbleDuration;
    }

    public void OnDeath()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
        playerMove.input.Player.Disable();
    }
}
