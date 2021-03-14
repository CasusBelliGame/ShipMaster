using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] bool isEnemyCannon;
    public Vector3 hitPoint = new Vector3(0,0,0);
    public float speed;
    [SerializeField] float hitPower;
    Rigidbody r;
    GameObject player;
    private void Start() {
        r = GetComponent<Rigidbody>();
        hitPoint = hitPoint -transform.position;
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        r.velocity = ((hitPoint)*speed);
        //if(isEnemyCannon){
        //    if(Vector3.Distance(transform.position,player.transform.position)<1.5f){
        //    HitPlayer();
        //    }else{
        //        Debug.Log(Vector3.Distance(transform.position,player.transform.position));
        //    }
        //}

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" & isEnemyCannon){
            HitPlayer();
        }
        if(other.tag == "Enemy" & !isEnemyCannon){
            HitEnemy(other.gameObject);
        }
    }


    void HitPlayer(){
        player.GetComponent<ShipController>().ChangeHealth(-hitPower);
    }
    void HitEnemy(GameObject other){
        other.GetComponent<Health>().ChangeHealth(-hitPower);
    }
}
