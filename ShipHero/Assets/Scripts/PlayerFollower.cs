using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    GameObject player;

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        transform.position = player.transform.position;
    }
}
