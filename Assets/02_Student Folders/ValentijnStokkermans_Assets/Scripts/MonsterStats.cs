using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] public bool isDead;

    [SerializeField] public int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] public bool canAttack;
    [SerializeField] public bool isBoss = false;

    private Animator animDeath = null;
    public float countdown;

    private void Start() {
        InitVariables();
    }

    void Update() {
        if (isDead == true) {
            countdown -= Time.deltaTime;
            if (countdown <= 0f) {
                Destroy(gameObject);
            }
        }
    }

    public void DealDamage(Health statsToDamage)
    {
        //Damaging functionality
        statsToDamage.TakeDamage(damage, null);
    }

    public void CheckHealth() {
        if(health <= 0) {
            health = 0;
            animDeath = GetComponentInChildren<Animator>();
            animDeath.SetTrigger("Die");
            Die();
        }

        if(health >= maxHealth) {
            health = maxHealth;
        }
    }

    public void Die() {
        isDead = true;
        damage = 0;
        attackSpeed = 0f;
        canAttack = false;
    }

    private void SetHealthTo(int healthToSetTo) {
        health = healthToSetTo;
        CheckHealth();
    }

    public void Heal(int heal) {
        int healthAferHeal = health + heal;
        SetHealthTo(healthAferHeal);
    }

    public void TakeDamage(int Damage) {
        int healthAferDamage = health - damage;
        SetHealthTo(healthAferDamage);
    }

    public void InitVariables() {
        maxHealth = 100;
        if (isBoss) {
            maxHealth = maxHealth * 4;
        }
        SetHealthTo(maxHealth);
        isDead = false;
        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
        countdown = 1f;
    }
}
