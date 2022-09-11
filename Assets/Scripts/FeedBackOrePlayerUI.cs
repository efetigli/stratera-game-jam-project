using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedBackOrePlayerUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Interaction interaction;

    [Header("Target UI Text (FeedBackOre)")]
    [SerializeField] private TextMeshProUGUI feedbackOreText;

    [Header("Timer")]
    [SerializeField] private float closeTime;
    [SerializeField] public float closeTimer;

    [Header("Close Animation Timer")]
    [SerializeField] private float closeAnimationTime;
    [SerializeField] private float closeAnimationTimer;
    private bool isClosingMaterialsInfo;
    private bool flag;

    private void Update()
    {
        ShowFeedbackOreCountOnUI();
        CalculateCloseTiming();
        //CloseAnimation();
    }

    private void CalculateCloseTiming()
    {
        //if (flag)
        //    return;

        interaction.isCollectNewOre = false;
        closeTimer += Time.deltaTime;
        if (closeTimer >= closeTime)
        {
            closeTimer = 0f;
            //isClosingMaterialsInfo = true;
            //flag = true;
            this.gameObject.SetActive(false);
            //this.GetComponent<Animator>().SetTrigger("Close");
        }
    }

    ////private void CloseAnimation()
    ////{
    ////    if (!isClosingMaterialsInfo)
    ////        return;

    ////    closeAnimationTimer += Time.deltaTime;
    ////    if (closeAnimationTimer >= closeAnimationTime)
    ////    {
    ////        closeAnimationTimer = 0f;
    ////        isClosingMaterialsInfo = false;
    ////        flag = false;
    ////        this.gameObject.SetActive(false);
    ////    }
    ////}

    private void ShowFeedbackOreCountOnUI()
    {
        feedbackOreText.text = "Added " + interaction.amountCollectNewOre + " " + interaction.whichCollectNewOreType;
    }

    public void ForceExit()
    {
        this.GetComponent<Animator>().SetTrigger("ForceExit");
    }
}
