[System.Serializable]
public class shipData
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
    public float rocketLevel;
    public float rocketPiecesLevel;

 public shipData(saveShip ship){
    speed = ship.speed;
    durability = ship.durability;
    aerodynamics = ship.aerodynamics;
    isLostPlate1 = ship.isLostPlate1;
    isLostPlate2 = ship.isLostPlate2;
    wingLevel = ship.wingLevel;
    wingPieceLevel = ship.wingPieceLevel;
    engineLevel = ship.engineLevel;
    enginePiecesLevel = ship.enginePiecesLevel;
    rocketLevel = ship.rocketLevel;
    rocketPiecesLevel = ship.rocketPiecesLevel;

    }   
}
