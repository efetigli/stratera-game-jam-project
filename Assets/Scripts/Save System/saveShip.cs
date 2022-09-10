using UnityEngine;

public class saveShip : MonoBehaviour
{
    public float speed;
    public float durability;
    public float aerodynamics;
    public bool hasLostPlate1;
    public bool hasLostPlate2;
    public bool isLostPlate1;
    public bool isLostPlate2;
    public float wingLevel;
    public bool hasWingPieceLevel2;
    public bool hasWingPieceLevel3;
    public float engineLevel;
    public bool hasEngineLevel2;
    public bool hasEngineLevel3;
    public float boosterRocketLevel;
    public bool hasBoosterRocketLevel2;
    public bool hasBoosterRocketLevel3;
    public float oilTankLevel;
    public float oilTankPiecesLevel;
    public void saveShipData(){
        SaveSystem.SaveShip(this);
    }
    public void loadShipData(){
        shipData data = SaveSystem.LoadShip();
        speed = data.speed;
        durability = data.durability;
        aerodynamics = data.aerodynamics;
        hasLostPlate1 = data.hasLostPlate1;
        hasLostPlate2 = data.hasLostPlate2;
        isLostPlate1 = data.isLostPlate1;
        isLostPlate2 = data.isLostPlate2;
        wingLevel = data.wingLevel;
        hasWingPieceLevel2 = data.hasWingPieceLevel2;
        hasWingPieceLevel3 = data.hasWingPieceLevel3;
        engineLevel = data.engineLevel;
        hasEngineLevel2 = data.hasEngineLevel2;
        hasEngineLevel3 = data.hasEngineLevel3;
        boosterRocketLevel = data.boosterRocketLevel;
        hasBoosterRocketLevel2 = data.hasBoosterRocketLevel2;
        hasBoosterRocketLevel3 = data.hasBoosterRocketLevel3;
        oilTankLevel = data.oilTankLevel;
        oilTankPiecesLevel = data.oilTankPiecesLevel;
    }

    public void UpdateShipPartLostPlate()
    {
            durability += 100;
    }

    public void UpdateEngine()
    {
        if (engineLevel == 1)
        {
            speed += 30;
            durability += 20;
        }
        else if (engineLevel == 2)
        {
            speed -= 30;
            durability -= 20;

            speed += 60;
            durability += 30;
        }
        else if (engineLevel == 3)
        {
            speed -= 60;
            durability -= 30;

            speed += 90;
            durability += 50;
            aerodynamics += 100;
        }
    }

    public void UpdateWing()
    {
        if (wingLevel == 1)
        {
            speed += 25;
            durability += 25;
            aerodynamics += 50;
        }
        else if (wingLevel == 2)
        {
            speed -= 25;
            durability -= 25;
            aerodynamics -= 50;

            speed += 50;
            durability += 25;
            aerodynamics += 100;
        }
        else if (wingLevel == 3)
        {
            speed -= 50;
            durability -= 25;
            aerodynamics -= 100;

            speed += 100;
            durability += 100;
            aerodynamics += 150;
        }
    }

    public void UpdateBooster()
    {
        if (boosterRocketLevel == 1)
        {
            speed += 30;
            durability += 25;
        }
        else if (boosterRocketLevel == 2)
        {
            speed -= 30;
            durability -= 25;

            speed += 60;
            durability += 75;
        }
        else if (boosterRocketLevel == 3)
        {
            speed -= 60;
            durability -= 75;

            speed += 90;
            durability += 100;
            aerodynamics += 100;
        }
    }
}
