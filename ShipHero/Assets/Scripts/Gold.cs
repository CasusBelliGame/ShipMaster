using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    Rigidbody r;
    public bool isUpdatable = false;
    GameObject player;
    [SerializeField] Information self;
    void Start()
    {
        r = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");

    }


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject enemyTolook = null;
        foreach (GameObject enemy in enemies)
        {
            enemyTolook = enemy;
        }        
        if(enemyTolook == null){
            isUpdatable = true;
        }else{
            isUpdatable = false;
        }
        if(!isUpdatable) return;
        r.velocity =  (player.transform.position - transform.position)*(5/ Vector3.Distance(player.transform.position - transform.position,Vector3.zero));
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            self.ChangeMoney(1);
            Destroy(gameObject);
        }
    }

}
