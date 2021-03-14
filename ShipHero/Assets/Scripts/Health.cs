using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] HealthBar bar;
    [SerializeField] float health = 10;

    private void Start() {
        bar.SetHealth(health);
        bar.SetHealth(health);
    }

    public void ChangeHealth(float amount){
        health += amount;
        bar.ChangeHealth(amount);
        if(health <=0){
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
