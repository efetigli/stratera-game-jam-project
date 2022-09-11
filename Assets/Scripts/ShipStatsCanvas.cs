using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatsCanvas : MonoBehaviour
{
    [Header("Save Ship")]
    [SerializeField] private saveShip mySaveShip;

    [Header("Bars")]
    [SerializeField] private Slider speedBar;
    [SerializeField] private Slider durabilityBar;
    [SerializeField] private Slider aeroBar;

    [Header("Pancarts")]
    [SerializeField] private GameObject engine;
    [SerializeField] private GameObject wing;
    [SerializeField] private GameObject boosterRocket;
    [SerializeField] public int pancartCount;

    [Header("Engine")]
    [SerializeField] private GameObject engineLvl1;
    [SerializeField] private GameObject engineLvl2;
    [SerializeField] private GameObject engineLvl3;

    [Header("wing")]
    [SerializeField] private GameObject wingLvl1;
    [SerializeField] private GameObject wingLvl2;
    [SerializeField] private GameObject wingLvl3;

    [Header("boosterRocket")]
    [SerializeField] private GameObject boosterRocketLvl1;
    [SerializeField] private GameObject boosterRocketLvl2;
    [SerializeField] private GameObject boosterRocketLvl3;

    private void Start()
    {
        pancartCount = 1;
        WhichPancart();
        SliderUpdate();
    }

    private void Update()
    {
        WhichPancart();
    }


    private void WhichPancart()
    {
        SliderUpdate();

        if (pancartCount == 1)
        {
            engine.SetActive(true);
            wing.SetActive(false);
            boosterRocket.SetActive(false);
            if (mySaveShip.engineLevel == 1)
            {
                engineLvl1.SetActive(true);
                engineLvl2.SetActive(false);
                engineLvl3.SetActive(false);
            }
            else if (mySaveShip.engineLevel == 2)
            {
                engineLvl1.SetActive(false);
                engineLvl2.SetActive(true);
                engineLvl3.SetActive(false);
            }
            else if (mySaveShip.engineLevel == 3)
            {
                engineLvl1.SetActive(false);
                engineLvl2.SetActive(false);
                engineLvl3.SetActive(true);
            }
        }
        else if (pancartCount == 2)
        {
            engine.SetActive(false);
            wing.SetActive(true);
            boosterRocket.SetActive(false);
            if (mySaveShip.wingLevel == 1)
            {
                wingLvl1.SetActive(true);
                wingLvl2.SetActive(false);
                wingLvl3.SetActive(false);
            }
            else if (mySaveShip.wingLevel == 2)
            {
                wingLvl1.SetActive(false);
                wingLvl2.SetActive(true);
                wingLvl3.SetActive(false);
            }
            else if (mySaveShip.wingLevel == 3)
            {
                wingLvl1.SetActive(false);
                wingLvl2.SetActive(false);
                wingLvl3.SetActive(true);
            }
        }
        else if (pancartCount == 3)
        {
            engine.SetActive(false);
            wing.SetActive(false);
            boosterRocket.SetActive(true);
            if (mySaveShip.boosterRocketLevel == 1)
            {
                boosterRocketLvl1.SetActive(true);
                boosterRocketLvl2.SetActive(false);
                boosterRocketLvl3.SetActive(false);
            }
            else if (mySaveShip.wingLevel == 2)
            {
                boosterRocketLvl1.SetActive(false);
                boosterRocketLvl2.SetActive(true);
                boosterRocketLvl3.SetActive(false);
            }
            else if (mySaveShip.wingLevel == 3)
            {
                boosterRocketLvl1.SetActive(false);
                boosterRocketLvl2.SetActive(false);
                boosterRocketLvl3.SetActive(true);
            }
        }
    }

    public void RightPage()
    {
        pancartCount = pancartCount + 1;
        if (pancartCount == 4)
            pancartCount = 1;
        WhichPancart();
    }

    public void LeftPage()
    {
        pancartCount = pancartCount - 1;
        if (pancartCount == 0)
            pancartCount = 3;
        WhichPancart();
    }

    public void SliderUpdate()
    {
        speedBar.value = mySaveShip.speed;
        durabilityBar.value = mySaveShip.durability;
        aeroBar.value = mySaveShip.aerodynamics;

    }

    
}
