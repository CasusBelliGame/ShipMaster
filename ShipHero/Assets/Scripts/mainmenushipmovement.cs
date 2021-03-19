using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenushipmovement : MonoBehaviour
{
    Rigidbody r;
    float timeCounter = 0;

    void Start()
    {
        r= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCounter += Time.deltaTime;
        r.velocity = new Vector3(6* Mathf.Cos (timeCounter),0,6*Mathf.Sin (timeCounter));
        transform.LookAt(transform.position + r.velocity);
    }
}
