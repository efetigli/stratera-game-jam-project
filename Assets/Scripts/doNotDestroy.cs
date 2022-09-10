using UnityEngine;
using UnityEngine.UI;
public class doNotDestroy : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    public static doNotDestroy instance;
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if(instance == null ){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Update(){
        gameObject.GetComponent<AudioSource>().volume = musicSlider.value;
    }
}
