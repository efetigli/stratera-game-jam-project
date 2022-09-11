using UnityEngine;
using UnityEngine.UI;

public class menuParent : MonoBehaviour
{
    [SerializeField] public Slider musicSlider;
    public virtual void Start(){
        musicSlider.value = FindObjectOfType<doNotDestroy>().GetComponent<AudioSource>().volume;
    } 
    
}
