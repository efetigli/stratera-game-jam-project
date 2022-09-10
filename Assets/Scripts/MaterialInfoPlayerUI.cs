using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialInfoPlayerUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private saveMaterials mySaveMatrial;

    [Header("Target UI Text (Materials)")]
    [SerializeField] private TextMeshProUGUI metalText;
    [SerializeField] private TextMeshProUGUI oilText;
    [SerializeField] private TextMeshProUGUI plasticText;
    [SerializeField] private TextMeshProUGUI goldText;

    [Header("Showing Info")]
    [SerializeField] private PlayerController myPlayerController;

    [Header("Timer")]
    [SerializeField] private float closeTime;
    [SerializeField] private float closeTimer;

    [Header("Close Animation Timer")]
    [SerializeField] private float closeAnimationTime;
    [SerializeField] private float closeAnimationTimer;
    public bool isClosingMaterialsInfo { get; private set; }
    private bool flag;
    private void Update()
    {
        ShowMaterialCountOnUI();
        CalculateCloseTiming();
        CloseAnimation();
    }

    private void CalculateCloseTiming()
    {
        if (myPlayerController.isPressMaterialShow)
            return;

        if (flag)
            return;

        closeTimer += Time.deltaTime;
        if(closeTimer >= closeTime)
        {
            closeTimer = 0f;
            myPlayerController.isPressMaterialShow = false;
            isClosingMaterialsInfo = true;
            flag = true;
            this.GetComponent<Animator>().SetTrigger("Close");
        }
    }

    private void CloseAnimation()
    {
        if (!isClosingMaterialsInfo)
            return;

        closeAnimationTimer += Time.deltaTime;
        if (closeAnimationTimer >= closeAnimationTime)
        {
            closeAnimationTimer = 0f;
            isClosingMaterialsInfo = false;
            flag = false;
            this.gameObject.SetActive(false);
        }
    }

    private void ShowMaterialCountOnUI()
    {
        metalText.text = "Metal: " + mySaveMatrial.metal;
        oilText.text = "Oil: " + mySaveMatrial.oil;
        plasticText.text = "Plastic: " + mySaveMatrial.plastic;
        goldText.text = "Gold: " + mySaveMatrial.gold;
    }
}
