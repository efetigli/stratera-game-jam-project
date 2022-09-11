using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public Vector3 soundPosition;
    void Start(){
        soundPosition.x = 0;
        soundPosition.y = 0;
        soundPosition.z = 0;
    }
    public void CreateSoundEffect(GameObject Audio){
        Instantiate(Audio,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
    }
}
