using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] Information self;
    public Joystick stick;
    float horInput;
    float verInput;
    [SerializeField] public float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] GameObject shipRotation;
    [SerializeField] HealthBar healthBar;
    public ParticleSystem explode;
    float timePassed;
    [SerializeField] float timeBetweenFire;

    [SerializeField] GameObject CannonBall;
    [SerializeField] Transform InsPoint;
    float shipY;
    bool isMoving;
    void Start()
    {
        shipY = transform.position.y;
        healthBar.SetMaxHealth(self.GetMaxHealth());
        healthBar.SetHealth(self.GetCurrentHealth());
        shipRotation = GameObject.Find("ShipRotation");
        stick = GameObject.Find("FixedJoystick").GetComponent<Joystick>();
    }

 
    void Update()
    {
        timePassed += Time.deltaTime;
        horInput = stick.Horizontal;
        verInput = stick.Vertical;
        if(Mathf.Abs(horInput) >= 0.1f || Mathf.Abs(verInput) >= 0.1f){
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x+horInput,transform.position.y,transform.position.z+verInput),Time.deltaTime*speed);
            shipRotation.transform.position = transform.position;
            shipRotation.transform.LookAt(shipRotation.transform.position + new Vector3(horInput,0,verInput));
            transform.rotation = Quaternion.Lerp(transform.rotation, shipRotation.transform.rotation, Time.deltaTime* rotSpeed);
            isMoving = true;
        }else{
            shipRotation.transform.rotation = transform.rotation;
            isMoving = false;
        }

        Fire();
    }

    private void Fire()
    {
        if(isMoving) return;
        if(timePassed < timeBetweenFire) return;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0) return;
        float distance = Mathf.Infinity;
        GameObject enemyToAttack = null;
        foreach (GameObject enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position,transform.position)< distance){
                enemyToAttack = enemy;
            }
        }
        if(enemyToAttack == null) return;
        LaunchGun(enemyToAttack.transform.position-transform.position);
        timePassed = 0;
    }

    private void LaunchGun(Vector3 position)
    {
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        GameObject cannon = Instantiate(CannonBall,InsPoint.position,Quaternion.identity);
        explode.Play();
        cannon.GetComponent<CannonBall>().hitPoint = position;
    }



    public void ChangeHealth(float amount){
        amount = amount/self.GetArmor();
        if(self.ChangeHealth(amount)){
            healthBar.ChangeHealth(amount);
        }
        else{
            healthBar.ChangeHealth(amount);
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
