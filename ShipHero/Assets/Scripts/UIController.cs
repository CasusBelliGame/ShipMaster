using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text goldAmount;
    public Information self;
    [SerializeField] GameObject buffUI;
    [SerializeField] GameObject[] buffButtons;
    [SerializeField] Buff[] buffs;
    public Weapon wep;
    int i1,i2,i3;
    void Start()
    {
        //buffUI.SetActive(false);
        //OpenBuffUI();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goldAmount.text = self.Getgold().ToString();
    }

    public void OpenBuffUI(){
        buffUI.SetActive(true);
        ChangeButtons();
        AssignButtons();
    }

    private void ChangeButtons()
    {
        wep = FindObjectOfType<ShipController>().curWeapon;
        i1 = UnityEngine.Random.Range(0,buffs.Length);
        if(i1 == 1) i1 = 0;
        buffButtons[0].GetComponent<Image>().sprite = buffs[i1].sprite;

        i2 = UnityEngine.Random.Range(0,buffs.Length);
        if(i2 == i1 ) i2=1;
        buffButtons[0].GetComponent<Image>().sprite = buffs[i2].sprite;

        i3 = UnityEngine.Random.Range(0,buffs.Length);
        if(i3 == i2) i3=0;
        if(i3==i1)   i3 =2;
        buffButtons[0].GetComponent<Image>().sprite = buffs[i3].sprite;
    }

    private void AssignButtons()
    {
        buffButtons[0].GetComponent<Button>().onClick.AddListener(Button0);
        buffButtons[1].GetComponent<Button>().onClick.AddListener(Button1);
        buffButtons[2].GetComponent<Button>().onClick.AddListener(Button2);
    }


    void Button0(){
        buffs[i1].Effect(wep);
    }
    void Button1(){
        buffs[i2].Effect(wep);
    }
    void Button2(){
        buffs[i3].Effect(wep);
    }
}
