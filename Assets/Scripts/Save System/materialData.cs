using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class materialData
{
    public float metal;
    public float  oil;
    public float  plastic;
    public float  gold;
    public float  bootsLevel;
    public float  oxygenSystemLevel;
    public string  pickaxeType;

 public materialData(materials mateirals){
    metal = mateirals.metal;
    oil = mateirals.oil;
    plastic = mateirals.plastic;
    gold = mateirals.gold;
    bootsLevel = mateirals.bootsLevel;
    bootsLevel = mateirals.bootsLevel;
    bootsLevel = mateirals.bootsLevel;
    }   
}
