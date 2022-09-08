using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [Header("Oxygen Bar")]
    [SerializeField] Slider oxygenbar;
    [SerializeField] float regenOxygenSpeed;
    [SerializeField] float lossOxygenSpeed;
    public float currentOxygen { get; private set; }
    private float maxOxygen;

    [Header("Oxygen Rich Area")]
    [SerializeField] private RichOxygenArea richOxygenArea;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = 1;
        maxOxygen = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentOxygenValue();
        OxygenArea();
        Debug.Log(currentOxygen);
    }

    private void OxygenArea()
    {
        if (richOxygenArea.isInsideOxygenRichArea)
        {
            OxygenRegen();
        }
        else if (!richOxygenArea.isInsideOxygenRichArea)
        {
            OxygenConsume();
        }
    }

    private void OxygenConsume()
    {
        oxygenbar.value -= Mathf.Clamp01(lossOxygenSpeed / maxOxygen) * Time.deltaTime;
    }

    private void OxygenRegen()
    {
        oxygenbar.value += Mathf.Clamp01(regenOxygenSpeed / maxOxygen) * Time.deltaTime;
    }

    public void CurrentOxygenValue()
    {
        currentOxygen = oxygenbar.value;
    }
}
