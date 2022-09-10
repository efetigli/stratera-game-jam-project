[System.Serializable]
public class shipData
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
    

 public shipData(saveShip ship){
    speed = ship.speed;
    durability = ship.durability;
    aerodynamics = ship.aerodynamics;
    isLostPlate1 = ship.isLostPlate1;
    isLostPlate2 = ship.isLostPlate2;
    hasLostPlate1 = ship.hasLostPlate1;
    hasLostPlate2 = ship.hasLostPlate2;
    wingLevel = ship.wingLevel;
    hasWingPieceLevel2 = ship.hasWingPieceLevel2;
    hasWingPieceLevel3 = ship.hasWingPieceLevel3;
    engineLevel = ship.engineLevel;
    hasEngineLevel2 = ship.hasEngineLevel2;
    hasEngineLevel3 = ship.hasEngineLevel3;
    boosterRocketLevel = ship.boosterRocketLevel;
    hasBoosterRocketLevel3 = ship.hasBoosterRocketLevel3;
    hasBoosterRocketLevel3 = ship.hasBoosterRocketLevel3;
    }   
}
