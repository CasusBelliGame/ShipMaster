using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float HitPower;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<ShipController>().speed = other.gameObject.GetComponent<ShipController>().speed/10;
            other.gameObject.GetComponent<ShipController>().ChangeHealth(-HitPower);
        }
        if(other.tag == "Cannonball"){
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag != "Player") return;
        other.gameObject.GetComponent<ShipController>().ChangeHealth(-HitPower* 0.01f);
    }
}
