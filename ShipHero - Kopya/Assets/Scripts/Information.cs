using UnityEngine;

[CreateAssetMenu(fileName = "Information", menuName = "Information", order = 0)]
public class Information : ScriptableObject {
    [SerializeField] float maxHealth;
    [SerializeField] float curHealth;
    [SerializeField] float armor;
    [SerializeField] int goldAmount;
    [SerializeField] Ship myShip;
    [SerializeField] GameObject myShipPrefab;

    public bool ChangeHealth(float amount){
        if(curHealth +amount >0){
            curHealth += amount;
            return true;
        }else if(curHealth + amount <=0){
            curHealth = 0;
            return false;
        }
        if(curHealth + amount >= maxHealth){
            curHealth = maxHealth;
            return true;
        }
        return false;
    }

    public Ship GetShip(){
        return myShip;
    }
    public void SetShip(GameObject ship){
        myShip = ship.GetComponent<Ship>();
        myShipPrefab = ship;
    }
    public float GetMaxHealth(){
        return maxHealth;
    }
    public float GetCurrentHealth(){
        return curHealth;
    }
    public float GetArmor(){
        return armor;
    }

    public void ChangeArmor(float amount){
        armor *= amount;
    }

    public int Getgold(){
        return goldAmount;
    }

    public bool ChangeMoney(int amount){
        if(goldAmount + amount < 0) return false;
        if(goldAmount + amount >= 0){
            goldAmount += amount;
            return true;
        }
        return false;    
    }


}