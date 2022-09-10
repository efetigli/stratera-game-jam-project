using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        mySaveMaterials.pickaxeType = "Stone";
        mySaveMaterials.oxygenSystemLevel = 1;
        mySaveMaterials.saveMaterialsData();

        mySaveShip.speed = 220;
        mySaveShip.durability = 50;
        mySaveShip.aerodynamics = 150;
        mySaveShip.hasLostPlate1 = false;
        mySaveShip.hasBoosterRocketLevel2 = false;
        mySaveShip.isLostPlate1 = false;
        mySaveShip.isLostPlate2 = false;
        mySaveShip.hasWingPieceLevel2 = false;
        mySaveShip.hasWingPieceLevel3 = false;
        mySaveShip.hasEngineLevel2 = false;
        mySaveShip.hasEngineLevel3 = false;
        mySaveShip.wingLevel = 1;
        mySaveShip.engineLevel = 1;
        mySaveShip.boosterRocketLevel = 1;
        mySaveShip.saveShipData();
        SceneManager.LoadScene(1);
    }
    public void Continue(){
        mySaveMaterials.loadMaterialsData();
        mySaveShip.loadShipData();
        SceneManager.LoadScene(1);
    }
}
