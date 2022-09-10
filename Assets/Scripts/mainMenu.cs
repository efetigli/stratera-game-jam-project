using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;
    [SerializeField] private saveShip mySaveShip;
    public void newGame(){
        mySaveMaterials.metal = 0;
        mySaveMaterials.oil = 0;
        mySaveMaterials.plastic = 0;
        mySaveMaterials.gold = 0;
    }
}
