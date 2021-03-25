using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Buff", order = 0)]
public class Buff : ScriptableObject {
    public Sprite sprite;
    public Information self;
    public Weapon weapon;
    public BuffType myBuff;
    public float armorBuff;
    public float healthBuff;
    public enum BuffType{
        armor,
        health,
        power
    };

    public void Effect(Weapon wep){
        weapon =wep;
        if(myBuff == BuffType.armor){
           self.ChangeArmor(armorBuff);
        }
        if(myBuff == BuffType.health){
           self.ChangeHealth(healthBuff);
        }
        if(myBuff == BuffType.power){
           self.ChangeArmor(armorBuff);
        }     
    }


}