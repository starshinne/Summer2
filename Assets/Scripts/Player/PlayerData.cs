using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Basic Data")]
    public float maxHealth = 100;
    public float currentHealth = 100;
    public PlayerMove playerMove;
    [Header("Invincible Data")]
    public float inVincinbleDuration;
    public bool isDead;
    private float inVincinbleCounter;
    private bool Invincible;
    public Animator animator;
    private void Start()
    {
        currentHealth = maxHealth;
        playerMove = GetComponent<PlayerMove>();
        animator.GetComponent<Animator>();
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
            inVincinble();
            OnTakeDamage?.Invoke(attacker.transform);
            currentHealth -= attacker.Damage;
        }
        else
        {
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
