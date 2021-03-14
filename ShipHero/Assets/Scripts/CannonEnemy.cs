using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEnemy : MonoBehaviour
{
    float timePassed;
    [SerializeField] float timeBetweenFire;
    GameObject player;
    [SerializeField] GameObject CannonBall;
    [SerializeField] Transform InsPoint;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        Fire();







    }


    private void Fire(){
        if(timePassed < timeBetweenFire) return;
        LaunchGun(player.transform.position-transform.position);
        timePassed = 0;
    }

    private void LaunchGun(Vector3 position)
    {
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        GameObject cannon = Instantiate(CannonBall,InsPoint.position,Quaternion.identity);
        cannon.GetComponent<CannonBall>().hitPoint = position;
    }




}
