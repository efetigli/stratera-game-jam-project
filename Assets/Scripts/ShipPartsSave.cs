using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartsSave : MonoBehaviour
{
    [Header("Wing Parts")]
    [SerializeField] private GameObject wingLvl1;
    [SerializeField] private GameObject wingLvl2;
    [SerializeField] private GameObject wingLvl3;

    [Header("Engine Parts")]
    [SerializeField] private GameObject engineLvl1;
    [SerializeField] private GameObject engineLvl2;
    [SerializeField] private GameObject engineLvl3;

    [Header("Booster Parts")]
    [SerializeField] private GameObject boosterLvl1;
    [SerializeField] private GameObject boosterLvl2;
    [SerializeField] private GameObject boosterLvl3;

    [Header("Metal Plack")]
    [SerializeField] private GameObject plate1;
    [SerializeField] private GameObject plate2;

    [Header("Saves")]
    [SerializeField] private saveShip saveShip;

    private void Start()
    {
        if(saveShip.wingLevel == 1)
        {
            wingLvl1.SetActive(true);
            wingLvl2.SetActive(false);
            wingLvl3.SetActive(false);
        }
        else if (saveShip.wingLevel == 2)
        {
            wingLvl1.SetActive(false);
            wingLvl2.SetActive(true);
            wingLvl3.SetActive(false);
        }
        else if (saveShip.wingLevel == 3)
        {
            wingLvl1.SetActive(false);
            wingLvl2.SetActive(true);
            wingLvl3.SetActive(true);

        }

        if (saveShip.engineLevel == 1)
        {
            engineLvl1.SetActive(true);
            engineLvl2.SetActive(false);
            engineLvl3.SetActive(false);
        }
        else if (saveShip.engineLevel == 2)
        {
            engineLvl1.SetActive(true);
            engineLvl2.SetActive(true);
            engineLvl3.SetActive(false);
        }
        else if (saveShip.engineLevel == 3)
        {
            engineLvl1.SetActive(true);
            engineLvl2.SetActive(true);
            engineLvl3.SetActive(true);
        }

        if (saveShip.boosterRocketLevel == 1)
        {
            boosterLvl1.SetActive(true);
            boosterLvl2.SetActive(false);
            engineLvl3.SetActive(false);
        }
        else if (saveShip.boosterRocketLevel == 2)
        {
            boosterLvl1.SetActive(true);
            boosterLvl2.SetActive(true);
            engineLvl3.SetActive(false);
        }
        else if (saveShip.boosterRocketLevel == 3)
        {
            boosterLvl1.SetActive(true);
            boosterLvl2.SetActive(true);
            boosterLvl3.SetActive(true);
        }

        if (saveShip.isLostPlate1)
        {
            plate1.SetActive(true);
        }

        if (saveShip.isLostPlate2)
        {
            plate2.SetActive(true);
        }
    }
}
