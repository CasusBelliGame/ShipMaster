using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShip : MonoBehaviour
{
    [SerializeField] GameObject front;
    [SerializeField] GameObject back;

    private void Update() {
        front.transform.position = front.transform.position + new Vector3(1*Time.deltaTime,-1*Time.deltaTime,1*Time.deltaTime);
        back.transform.position = back.transform.position + new Vector3(-1*Time.deltaTime,-1*Time.deltaTime,-1*Time.deltaTime);
    }


}
