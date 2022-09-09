using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class materials : MonoBehaviour
{
    public float metal;
    public float  oil;
    public float  plastic;
    public float  gold;
    public float  bootsLevel;
    public float  oxygenSystemLevel;
    public string  pickaxeType;
    public TextMeshProUGUI metalCount;
    public TextMeshProUGUI oilCount; 
    public TextMeshProUGUI plasticCount; 
    public TextMeshProUGUI goldCount; 

    public void SaveMaterials(){

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            metal = metal + 100;
            oil = oil + 50;
            plastic = plastic + 100;
            gold = gold + 31;
            metalCount.text = metal.ToString("0");
            oilCount.text = oil.ToString("0");
            plasticCount.text = plastic.ToString("0");
            goldCount.text = gold.ToString("0");
        }
    }
}
