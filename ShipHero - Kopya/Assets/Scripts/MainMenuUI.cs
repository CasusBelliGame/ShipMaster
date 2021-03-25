using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Information self;
    [SerializeField] TMP_Text goldAmount;
    [SerializeField] GameObject shopUI;

    private void FixedUpdate() {
        goldAmount.text = self.Getgold().ToString();
    }

    public void StartGame(){
        self.ChangeHealth(self.GetMaxHealth()-self.GetCurrentHealth());
        SceneManager.LoadScene(1);
    }
    public void OpenShop(){
        shopUI.SetActive(true);
        shopUI.GetComponent<ShopUI>().ChangeCard();
    }
    public void CloseShop(){
        shopUI.SetActive(false);
    }
}
