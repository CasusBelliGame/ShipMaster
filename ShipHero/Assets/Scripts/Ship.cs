using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Ship", order = 0)]
public class Ship : ScriptableObject {
    [SerializeField] Sprite sprite;
    [SerializeField] bool isBought;
    [SerializeField] bool isEquipped;
    [SerializeField] int shipCost;
    [SerializeField] Information self;
    [SerializeField] GameObject PrefabOfShip;
    [SerializeField] int speed;
    [SerializeField] int maxSpeed;
    [SerializeField] int armor;
    [SerializeField] int MaxArmor;   

    [SerializeField] int[] UpgradeSpeedMoney;
    [SerializeField] int[] UpgradeArmorMoney;

    [SerializeField] Weapon firstCannon;
    [SerializeField] GameObject firstCannonObject;
    [SerializeField] Weapon secondCannon;
    [SerializeField] GameObject secondCannonObject;
    [SerializeField] Weapon thirdCannon;
    [SerializeField] GameObject thirdCannonObject;
    [SerializeField] Weapon mortar;
    [SerializeField] GameObject mortarObject;

    public Sprite GetPic(){
        return sprite;
    }

    public bool IsBought(){
        return isBought;
    }
    public bool IsEquipped(){
        return isEquipped;
    }

    public int GetShipCost(){
        return shipCost;
    }
    public int SpeedIncreaseMoney(){
        return UpgradeSpeedMoney[speed];
    }
    public int ArmorIncreaseMoney(){
        return UpgradeArmorMoney[armor];
    }

    public bool CanIncreaseSpeed(){
        return maxSpeed> speed +1;
    }
    public bool CanIncreaseArmor(){
        return MaxArmor> armor +1;
    }

    



    public void Equip(){
        self.SetShip(this.PrefabOfShip);
        isEquipped = true;
    }
    public void UnEquip(){
        isEquipped = false;
    }

    public void BuyShip(){
        self.ChangeMoney((-1)* shipCost);
        isBought = true;
    }
    public void IncreaseSpeed(){
        self.ChangeMoney(-UpgradeSpeedMoney[speed]);
        speed +=1;
    }
    public void IncreaseArmor(){
        self.ChangeMoney(-UpgradeArmorMoney[armor]);
        armor +=1;
    }
}