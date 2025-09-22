using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pickupChance;
    public GameObject[] pickups;


    public int health;
    [HideInInspector]
    public Transform player;
    public float speed;
    public float timeBetweenAttack;
    public int damage;
    public GameObject splash;
    public GameObject deathEffect;

    public int healthPickupChance;
    public GameObject healthPickup;
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    
    }

    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        if (health <= 0)
        {
            int randomNumber = Random.Range(0,101);
            if (randomNumber < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            int randomHealth = Random.Range(0,101);
            if (randomHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }
            Instantiate(splash, transform.position, transform.rotation);
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
