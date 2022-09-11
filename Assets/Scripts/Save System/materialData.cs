[System.Serializable]
public class materialData
{
    public bool firstApperance;
    public float metal;
    public float  oil;
    public float  plastic;
    public float  gold;
    public float  oxygenSystemLevel;
    public string  pickaxeType;

 public materialData(saveMaterials mateirals){
    firstApperance = mateirals.firstApperance;
    metal = mateirals.metal;
    oil = mateirals.oil;
    plastic = mateirals.plastic;
    gold = mateirals.gold;
    pickaxeType = mateirals.pickaxeType;
    oxygenSystemLevel = mateirals.oxygenSystemLevel;
    }   
}
