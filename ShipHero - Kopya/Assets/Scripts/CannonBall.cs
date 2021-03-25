using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    GameObject player;
    Rigidbody r;
    [SerializeField] Weapon self;
    public Vector3 hitPoint = new Vector3(0,0,0);
    [SerializeField] bool isEnemyCannon;
    public float speed;
    [SerializeField] float hitPower;
    float startingDistance;
    private void Start() {
        r = GetComponent<Rigidbody>();
        hitPoint = hitPoint -transform.position;
        player = GameObject.FindWithTag("Player");
        isEnemyCannon = self.GetEnemyCannon();
        startingDistance = Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(hitPoint.x,hitPoint.z));
        transform.LookAt(player.transform.position);
    }

    void FixedUpdate()
    {
        r.velocity = ((hitPoint)*speed);
        if(self.GetCanFly() ){
            if(Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(hitPoint.x,hitPoint.z)) >= 3*startingDistance/5){
                r.velocity = r.velocity + new Vector3(0,5*speed,0);
            }else{
                r.useGravity = true;
                r.velocity = r.velocity + new Vector3(0,-10*speed,0);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" & isEnemyCannon){
            HitPlayer();
            Destroy(gameObject);
        }
        if(other.tag == "Enemy" & !isEnemyCannon){
            HitEnemy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.tag == "obstacle"){
            Destroy(gameObject);
        }
    }


    void HitPlayer(){
        player.GetComponent<ShipController>().ChangeHealth(-self.GetPower());
    }
    void HitEnemy(GameObject other){
        other.GetComponent<Health>().ChangeHealth(-self.GetPower());
    }
}
