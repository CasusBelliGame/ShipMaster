using UnityEngine;

[CreateAssetMenu(fileName = "Information", menuName = "Information", order = 0)]
public class Information : ScriptableObject {
    [SerializeField] float maxHealth;
    [SerializeField] float curHealth;
    [SerializeField] float armor;

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


    public float GetMaxHealth(){
        return maxHealth;
    }
    public float GetCurrentHealth(){
        return curHealth;
    }
    public float GetArmor(){
        return armor;
    }
}