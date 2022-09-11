[System.Serializable]
public class materialData
{
    public bool isPlate1Crafted;
    public bool isPlate2Crafted;
    public bool isMetalPickaxeCrafted;
    public bool isGoldPickaxeCrafted;
    public bool isOxygenLevel2Upgrade;
    public bool isOxygenLevel3Upgrade;

    public bool firstApperance;
    public float metal;
    public float  oil;
    public float  plastic;
    public float  gold;
    public float  oxygenSystemLevel;
    public string  pickaxeType;

 public materialData(saveMaterials mateirals){
        firstApperance = mateirals.firstApperance;
        isPlate1Crafted = mateirals.isPlate1Crafted;
        isPlate2Crafted = mateirals.isPlate2Crafted;
        isMetalPickaxeCrafted = mateirals.isMetalPickaxeCrafted;
        isGoldPickaxeCrafted = mateirals.isGoldPickaxeCrafted;
        isOxygenLevel2Upgrade = mateirals.isOxygenLevel2Upgrade;
        isOxygenLevel3Upgrade = mateirals.isOxygenLevel3Upgrade;

        firstApperance = mateirals.firstApperance;
    metal = mateirals.metal;
    oil = mateirals.oil;
    plastic = mateirals.plastic;
    gold = mateirals.gold;
    pickaxeType = mateirals.pickaxeType;
    oxygenSystemLevel = mateirals.oxygenSystemLevel;
    }   
}
