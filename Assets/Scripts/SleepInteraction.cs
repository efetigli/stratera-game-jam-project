using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SleepInteraction : MonoBehaviour
{
    [Header("Which Type of Interaction")]
    [SerializeField] private TextMeshProUGUI helpingText;


    [Header("Main Camera")]
    [SerializeField] private Camera mainCamera;

    [Header("Bed")]
    [SerializeField] private LayerMask maskSleep;
    [SerializeField] private float raySleepDistance;
    private bool isSleeping;

    [Header("Animators")]
    [SerializeField] public Animator toolAnimator;
    [SerializeField] private Animator playerAnimator;

    private void Update()
    {
        SleepIntteraction();
    }


    private void SleepIntteraction()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            raySleepDistance, maskSleep))
        {
            if (raycastHit.collider.CompareTag("Bed"))
            {
                    helpingText.text = "Press [E] \n to Sleep";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerAnimator.SetTrigger("Sleep");
                    isSleeping = true;
                    //helpingText.text = "";
                }
            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycasHit,
            raySleepDistance, maskSleep))
        {
            isSleeping = false;
            helpingText.text = "";
        }
    }
}
