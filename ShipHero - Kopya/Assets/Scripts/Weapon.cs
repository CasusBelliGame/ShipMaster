using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 0)]
public class Weapon : ScriptableObject {
    [SerializeField] GameObject self;
    [SerializeField] float WeaponPower;
    [SerializeField] bool canFly;
    [SerializeField] bool additionalVFX;
    [SerializeField] GameObject effect;
    [SerializeField] bool isEnemyCannon;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] bool isBought;

    public float getAttackTime(){
        return timeBetweenAttacks;
    }
    public GameObject GetSelf(){
        return self;
    }

    public GameObject GetVFX(){
        return effect;
    }

    public float GetPower(){
        return WeaponPower;
    }

    public bool GetCanFly(){
        return canFly;
    }
    
    public bool GetAdditionVFX(){
        return additionalVFX;
    }
    public bool GetEnemyCannon(){
        return isEnemyCannon;
    }

    public void SetWeaponPower(float amount){
        WeaponPower *= amount;
    }


    public bool IsBought(){
        return isBought;
    }
}