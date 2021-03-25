using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBox : MonoBehaviour
{
    public Buff buff;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            buff.Effect(other.GetComponent<ShipController>().curWeapon);
        }
    }
}
