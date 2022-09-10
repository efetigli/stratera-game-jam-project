using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private Transform bedPostion;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float targetRotation;
    [SerializeField] private bool isSleeping;

    [Header("Save files")]
    [SerializeField] private saveShip mySaveShip;
    [SerializeField] private saveMaterials mySaveMaterial;

    private void Start()
    {
        isSleeping = true;
    }

    // Update is called once per frame
    void Update()
    {
        TeleportBedPosition();
    }

    private void TeleportBedPosition()
    {
        if (isSleeping)
        {
            playerPosition.position = bedPostion.position;
            playerPosition.localRotation = Quaternion.Euler(0f,targetRotation,0f);
            isSleeping = true;
            this.GetComponent<Sleep>().enabled = false;
            mySaveShip.saveShipData();
            mySaveMaterial.saveMaterialsData();
        }
    }
}
