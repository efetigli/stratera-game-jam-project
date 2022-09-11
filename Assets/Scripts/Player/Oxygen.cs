using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [Header("Oxygen Bar")]
    [SerializeField] Slider oxygenbar;
    [SerializeField] RectTransform oxygenbarTransform;
    [SerializeField] float regenOxygenSpeed;
    [SerializeField] float lossOxygenSpeed;
    public float currentOxygen { get; private set; }
    private float maxOxygen;

    [Header("Oxygen Rich Area")]
    [SerializeField] private RichOxygenArea richOxygenArea;

    [Header("Save Material")]
    [SerializeField] private saveMaterials mySaveMaterial;

    [Header("Oxygen Upgrdes")]
    [SerializeField] private float oxygenBarHeight;
    [SerializeField] private float oxygenSystemLevel1Value;
    [SerializeField] private float oxygenSystemLevel2Value;
    [SerializeField] private float oxygenSystemLevel3Value;

    [Header("Die")]
    [SerializeField] private Die die;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = 1;
        maxOxygen = 1;
        UpdateOxygenLevel();

        if(mySaveMaterial.oxygenSystemLevel == 1)
        {
            oxygenbar.maxValue = oxygenSystemLevel1Value;
            oxygenbar.value = oxygenSystemLevel1Value;
        }
        else if (mySaveMaterial.oxygenSystemLevel == 2)
        {
            oxygenbar.maxValue = oxygenSystemLevel2Value;
            oxygenbar.value = oxygenSystemLevel2Value;
        }
        else if (mySaveMaterial.oxygenSystemLevel == 3)
        {
            oxygenbar.maxValue = oxygenSystemLevel3Value;
            oxygenbar.value = oxygenSystemLevel3Value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentOxygenValue();
        OxygenArea();
        LowOxygen();
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

    public void UpdateOxygenLevel()
    {
        if(mySaveMaterial.oxygenSystemLevel == 2)
        {
            oxygenbar.maxValue = oxygenSystemLevel2Value;
        }
        else if(mySaveMaterial.oxygenSystemLevel == 3)
        {
            oxygenbar.maxValue = oxygenSystemLevel3Value;

        }
    }

    public float GetOxygenValue()
    {
        return oxygenbar.value;
    }

    private void LowOxygen()
    {
        if (GetOxygenValue() <= 0.01)
        {
            die.enabled = true;
        }
    }
}
