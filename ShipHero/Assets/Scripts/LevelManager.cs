using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    void Awake()
    {
        GameObject player = Instantiate(playerPrefab,transform.position,Quaternion.identity);    
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            //LevelEnd
            Debug.Log("Palyer");
        }
    }


}
