using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingEnemy : MonoBehaviour
{
    float timePassed;
    [SerializeField] float timeBetweenFire;
    [SerializeField] float attackTime;
    float attackProcess;
    GameObject player;
    bool isUpdatable = false;
    Rigidbody r;
    Vector3 positionToGo = new Vector3(0,0,0);
    [SerializeField] float speed;
    float divider;
    [SerializeField] float hitPower;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timePassed += Time.deltaTime;
        Attack();
        if(isUpdatable){
            r.AddForce((positionToGo)*(speed/Vector3.Distance(positionToGo,new Vector3(0,0,0))));
            attackProcess += Time.deltaTime;
            if(attackProcess >= attackTime){
                isUpdatable = false;
                positionToGo = new Vector3(0,0,0);
                r.velocity = new Vector3(0,0,0);
                attackProcess = 0;
            }
        }
    }

    private void Attack()
    {
        if(timePassed < timeBetweenFire) return;
        player = GameObject.FindWithTag("Player");
        Rush(player.transform.position-transform.position);
        timePassed = 0;
    }

    private void Rush(Vector3 position)
    {
        positionToGo = position-transform.position;
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        isUpdatable = true;
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<ShipController>().ChangeHealth(hitPower);
        }
    }
}
