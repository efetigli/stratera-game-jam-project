[System.Serializable]
public class playerData
{
    public float[] position;
    public float oxygenLevel;

 public playerData(savePlayer player){
    position = new float[3];
    position[0] = player.transform.position.x;
    position[1] = player.transform.position.y;
    position[2] = player.transform.position.z;
    oxygenLevel = player.oxygenLevel;
    }   
}
