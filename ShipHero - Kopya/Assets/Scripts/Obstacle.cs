using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float HitPower;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<ShipController>().speed = other.gameObject.GetComponent<ShipController>().speed/2;
            other.gameObject.GetComponent<ShipController>().ChangeHealth(-HitPower);
        }

    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag != "Player") return;
        other.gameObject.GetComponent<ShipController>().ChangeHealth(-HitPower* 0.01f);
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<ShipController>().speed = other.gameObject.GetComponent<ShipController>().speed*2;

        }
  
    }
}
