using UnityEngine;
using TMPro;

public class saveMaterials : MonoBehaviour
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
    public TextMeshProUGUI metalCount;
    public TextMeshProUGUI oilCount; 
    public TextMeshProUGUI plasticCount; 
    public TextMeshProUGUI goldCount; 

    void Start(){
        loadMaterialsData();
    }
    public void saveMaterialsData(){
        SaveSystem.SaveMaterials(this);
    }
    public void loadMaterialsData(){
        materialData data =  SaveSystem.LoadMaterials();
        firstApperance = data.firstApperance;
        isPlate1Crafted = data.isPlate1Crafted;
        isPlate2Crafted = data.isPlate2Crafted;
        isMetalPickaxeCrafted = data.isMetalPickaxeCrafted;
        isGoldPickaxeCrafted = data.isGoldPickaxeCrafted;
        isOxygenLevel2Upgrade = data.isOxygenLevel2Upgrade;
        isOxygenLevel3Upgrade = data.isOxygenLevel3Upgrade;

        metal = data.metal;
        oil = data.oil;
        plastic = data.plastic;
        gold = data.gold;
        oxygenSystemLevel = data.oxygenSystemLevel;
        pickaxeType = data.pickaxeType;
    }
    public void UpdateMaterials()
    {
        metalCount.text = metal.ToString("0");
        oilCount.text = oil.ToString("0");
        plasticCount.text = plastic.ToString("0");
        goldCount.text = gold.ToString("0");
        
    }
}
