using UnityEngine;

public class saveShip : MonoBehaviour
{
    public float speed;
    public float durability;
    public float aerodynamics;
    public bool isLostPlate1;
    public bool isLostPlate2;
    public float wingLevel;
    public float wingPieceLevel;
    public float engineLevel;
    public float enginePiecesLevel;
    public float boosterRocketLevel;
    public float boosterRocketPiecesLevel;
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
        isLostPlate1 = data.isLostPlate1;
        isLostPlate2 = data.isLostPlate2;
        wingLevel = data.wingLevel;
        wingPieceLevel = data.wingPieceLevel;
        engineLevel = data.engineLevel;
        enginePiecesLevel = data.enginePiecesLevel;
        boosterRocketLevel = data.boosterRocketLevel;
        boosterRocketPiecesLevel = data.boosterRocketPiecesLevel;
        oilTankLevel = data.oilTankLevel;
        oilTankPiecesLevel = data.oilTankPiecesLevel;
    }
}
