using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private Transform bedPostion;
    [SerializeField] private Transform playerPosition;
    private bool isSleeping;

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
            isSleeping = false;
            this.GetComponent<Sleep>().enabled = false;
        }
    }
}
