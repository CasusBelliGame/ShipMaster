using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] HealthBar bar;
    [SerializeField] float health = 10;
    [SerializeField] int amount;
    [SerializeField] GameObject goldPrefab;

    private void Start() {
        bar.SetHealth(health);
        bar.SetMaxHealth(health);
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
        SpawnGold(amount);
        Destroy(gameObject);
    }

    private void SpawnGold(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = UnityEngine.Random.Range(0f,2f);
            float z = UnityEngine.Random.Range(0f,2f);
            Instantiate(goldPrefab, transform.position + new Vector3(x,0,z),Quaternion.identity);
        }
    }
}
