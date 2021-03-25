using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    bool isUpdate = true;
    GameObject FadeMenu;
    void Awake()
    {
        GameObject player = Instantiate(playerPrefab,transform.position,Quaternion.identity);    
    }

    private void Start() {
       FadeMenu = GameObject.FindWithTag("FadeMenu");
       FadeMenu.SetActive(false);
    }

    private void FixedUpdate() {
        if(!isUpdate) return;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0){
            GameObject.FindWithTag("zincir").SetActive(false);
            isUpdate = false;
        }

    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            FadeMenu.SetActive(true);
            StartCoroutine(LoadNext());
            Debug.Log("Palyer");
        }
    }

    IEnumerator LoadNext(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }


}
