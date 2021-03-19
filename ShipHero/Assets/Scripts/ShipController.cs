using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShipController : MonoBehaviour
{
    [SerializeField] GameObject shipRotation;
    [SerializeField] GameObject CannonBall;
    [SerializeField] Information self;
    Rigidbody r;
    [SerializeField] HealthBar healthBar;
    public ParticleSystem explode;
    [SerializeField] Transform InsPoint;
    public Weapon curWeapon;
    bool isMoving;
    public Joystick stick;
    float horInput;
    float verInput;
    float timePassed;
    float shipY;
    [SerializeField] float timeBetweenFire;
    [SerializeField] public float speed;
    [SerializeField] float rotSpeed;

    void Start()
    {
        shipY = transform.position.y;
        r = GetComponent<Rigidbody>();
        healthBar.SetMaxHealth(self.GetMaxHealth());
        healthBar.SetHealth(self.GetCurrentHealth());
        shipRotation = GameObject.Find("ShipRotation");
        stick = GameObject.Find("FixedJoystick").GetComponent<Joystick>();
        //FindObjectOfType<CinemachineVirtualCamera>().LookAt = this.gameObject.transform;
    }

 
    void Update()
    {
        timePassed += Time.deltaTime;
        horInput = stick.Horizontal;
        verInput = stick.Vertical;
        if(Mathf.Abs(horInput) >= 0.1f || Mathf.Abs(verInput) >= 0.1f){
            shipRotation.transform.LookAt(shipRotation.transform.position + new Vector3(horInput,0,verInput));
            //transform.eulerAngles = Vector3.Lerp(new Vector3(0,transform.eulerAngles.y,0),new Vector3(0,shipRotation.transform.eulerAngles.y,0),Time.deltaTime*3);
            transform.Rotate(new Vector3(0,shipRotation.transform.rotation.y-transform.rotation.y,0));
            r.velocity = new Vector3(horInput*speed,0,verInput*speed);
            //transform.LookAt(transform.position + r.velocity);
            isMoving = true;
        }else{
            shipRotation.transform.rotation = transform.rotation;
            r.velocity = Vector3.zero;
            isMoving = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0) return;
            float distance = Mathf.Infinity;
            GameObject enemyToAttack = null;
            foreach (GameObject enemy in enemies)
            {
                if(Vector3.Distance(enemy.transform.position,transform.position)< distance){
                    enemyToAttack = enemy;
                    distance = Vector3.Distance(enemy.transform.position,transform.position);
                }
            }
            if(enemyToAttack == null) return;
            transform.LookAt(enemyToAttack.transform.position);
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
        LaunchGun(enemyToAttack.transform.position);
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
