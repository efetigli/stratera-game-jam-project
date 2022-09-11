using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    [SerializeField] private saveMaterials mySaveMaterials;
    [SerializeField] private GameObject introductionCanvas;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private CursorManager cursorManager;
    [SerializeField] private OpenScreens openScreens;

    [SerializeField] private GameObject[] cards;
    private int cardIndex;

    [Header("Pickaxe")]
    [SerializeField] private Pickaxe pickaxe;

    [Header("CraftUI")]
    [SerializeField] private craftSystem screenCraftSystem;
    [SerializeField] private craftSystem canvasCraftSystem;

    private void Update()
    {
        IntroductioncanvasActivation();
    }

    public void IntroductioncanvasActivation()
    {
        if (mySaveMaterials.firstApperance == false)
        {
            cursorManager.LockCursor();
            pickaxe.AssignPickaxeHead();
            this.gameObject.SetActive(false);
            screenCraftSystem.CheckerForCraft();
            canvasCraftSystem.CheckerForCraft();
        }
        else if (mySaveMaterials.firstApperance == true)
        {
            introductionCanvas.SetActive(true);
            pauseManager.PauseGame();
            openScreens.ClosePlayerComponents();
            cursorManager.UnlockCursor();
        }
    }

    public void ClickSkip()
    {
        mySaveMaterials.firstApperance = false;
        pauseManager.UnpauseGame();
        openScreens.OpenPlayerComponents();
        cursorManager.LockCursor();
        introductionCanvas.SetActive(false);
    }

    public void LeftClick()
    {
        cards[cardIndex].SetActive(false);
        cardIndex -= 1;
        if(cardIndex == -1)
        {
            cardIndex = cards.Length - 1;
        }
        cards[cardIndex].SetActive(true);
    }

    public void RightClick()
    {
        cards[cardIndex].SetActive(false);
        cardIndex += 1;
        if (cardIndex == cards.Length)
        {
            cardIndex = 0;
        }
        cards[cardIndex].SetActive(true);
    }

    public void PickaxeColorLoad()
    {
        pickaxe.AssignPickaxeHead();
    }
}
