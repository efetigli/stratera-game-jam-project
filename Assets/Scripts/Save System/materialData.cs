[System.Serializable]
public class materialData
{
    public float metal;
    public float  oil;
    public float  plastic;
    public float  gold;
    public float  oxygenSystemLevel;
    public string  pickaxeType;

 public materialData(saveMaterials mateirals){
    metal = mateirals.metal;
    oil = mateirals.oil;
    plastic = mateirals.plastic;
    gold = mateirals.gold;
    pickaxeType = mateirals.pickaxeType;
    oxygenSystemLevel = mateirals.oxygenSystemLevel;
    }   
}
