using UnityEngine;

public class savePlayer : MonoBehaviour
{
    public float oxygenLevel;
    public void savePlayerData(){
        SaveSystem.SavePlayer(this);
    }
    public void loadPlayerData(){
        playerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        oxygenLevel = data.oxygenLevel;
    }
}
