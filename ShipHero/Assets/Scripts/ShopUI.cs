using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopUI : MonoBehaviour
{
    public Information self;
    public Ship[] ships;
    public int order = 0;
    public Image kartPic;
    public GameObject SagOk;
    public GameObject SolOk;
    public GameObject CardCloser;
    public GameObject EquipButton;    
    public TMP_Text BuyShopText;
    public GameObject speedPlusButton;
    public TMP_Text speedIncreaseMoney;
    public GameObject armorPlusButton;
    public TMP_Text ArmorIncreaseMoney;

    public void ChangeCard(){
        kartPic.sprite = ships[order].GetPic();
        if(ships.Length < order+2){
            SagOk.SetActive(false);
        }else{
            SagOk.SetActive(true);
        }
        if(order == 0){
            SolOk.SetActive(false);
        }else{
            SolOk.SetActive(true);
        }
        CheckStatus();
    }

    public void CheckStatus()
    {
        if(ships[order].IsBought()){
            CardCloser.SetActive(false);
            if(ships[order].IsEquipped()){
                EquipButton.SetActive(false);
            }else{
                EquipButton.SetActive(true);
            }
        }else{
            CardCloser.SetActive(true);
            BuyShopText.text = ships[order].GetShipCost().ToString();
        }
        if(!ships[order].CanIncreaseSpeed()){
            speedPlusButton.SetActive(false);
            speedIncreaseMoney.enabled = false;
        }else{
            speedPlusButton.SetActive(true);
            speedIncreaseMoney.text = ships[order].SpeedIncreaseMoney().ToString();
        }
        if(!ships[order].CanIncreaseArmor()){
            armorPlusButton.SetActive(false);
            ArmorIncreaseMoney.enabled = false;
        }else{
            armorPlusButton.SetActive(true);
            ArmorIncreaseMoney.text = ships[order].ArmorIncreaseMoney().ToString();
        }



    }









    public void BuySpeed(){

    }
    public void BuyArmor(){

    }
}
