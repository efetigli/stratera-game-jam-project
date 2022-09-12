using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : menuParent
{
    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;
    [SerializeField] private saveShip mySaveShip;

    public override void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        base.Start();
    }
    public void newGame(){
        mySaveMaterials.isPlate1Crafted = false;
        mySaveMaterials.isPlate2Crafted = false;
        mySaveMaterials.isMetalPickaxeCrafted = false;
        mySaveMaterials.isGoldPickaxeCrafted = false;
        mySaveMaterials.isOxygenLevel2Upgrade = false;
        mySaveMaterials.isOxygenLevel3Upgrade = false;
        mySaveMaterials.firstApperance = true;
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
        mySaveShip.isLostPlate1 = false;
        mySaveShip.isLostPlate2 = false;
        mySaveShip.hasBoosterRocketLevel2 = false;
        mySaveShip.hasBoosterRocketLevel3 = false;
        mySaveShip.hasWingPieceLevel2 = false;
        mySaveShip.hasWingPieceLevel3 = false;
        mySaveShip.hasEngineLevel2 = false;
        mySaveShip.hasEngineLevel3 = false;
        mySaveShip.wingLevel = 1;
        mySaveShip.engineLevel = 1;
        mySaveShip.boosterRocketLevel = 1;
        mySaveShip.saveShipData();
        Invoke("WaitScene",0.2f);
    }
    private void WaitScene(){
        SceneManager.LoadScene(1);
    }
    public void Continue(){
        mySaveMaterials.loadMaterialsData();
        mySaveShip.loadShipData();
        Invoke("WaitScene",0.2f);
    }
}
