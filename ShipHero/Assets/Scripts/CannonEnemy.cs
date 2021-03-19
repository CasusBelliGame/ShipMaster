using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEnemy : MonoBehaviour
{
    float timePassed;
    Rigidbody r;
    [SerializeField] float timeBetweenFire;
    GameObject player;
    [SerializeField] GameObject CannonBall;
    [SerializeField] Transform InsPoint;
    Vector3 randPlace = new Vector3(0,0,0);

    void Start()
    {
        r = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        float x = UnityEngine.Random.Range(0f,12f);
        float z = UnityEngine.Random.Range(0f,12f);
        randPlace = new Vector3(x,0,z);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed < timeBetweenFire){
            Move();
        }else{
            Fire();
        }
    }

    private void Move()
    {
        transform.LookAt(player.transform.position - transform.position + randPlace);
        r.velocity = (player.transform.position - transform.position + randPlace)*0.1f;
    }

    private void Fire(){
        LaunchGun(player.transform.position);
        timePassed = 0;
        float x = UnityEngine.Random.Range(0f,12f);
        float z = UnityEngine.Random.Range(0f,12f);
        randPlace = new Vector3(x,0,z);   
    }

    private void LaunchGun(Vector3 position)
    {
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        GameObject cannon = Instantiate(CannonBall,InsPoint.position,Quaternion.identity);
        cannon.GetComponent<CannonBall>().hitPoint = position;
    }




}
