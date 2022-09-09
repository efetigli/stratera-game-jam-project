using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    [Header("Which Type of Interaction")]
    [SerializeField] private Image ShowingType;
    [SerializeField] private TextMeshProUGUI helpingText;

    [Header("Which Tool are using")]
    [SerializeField] private PlayerController playerController;

    [Header("Animators")]
    [SerializeField] private Animator toolAnimator;
    [SerializeField] private Animator playerAnimator;


    [Header("Fix Filler")]
    [SerializeField] private Image fixFiller;

    [Header("Main Camera")]
    [SerializeField] private Camera mainCamera;

    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;

    #region Pickable
    [Header("Pick Objects")]
    [SerializeField] private LayerMask maskPickable;
    [SerializeField] private float rayPickableDistance;
    #endregion

    #region Pickaxe
    [Header("Pickaxe Using")]
    [SerializeField] private float rayPickaxeHitDistance;
    [SerializeField] private LayerMask maskPickaxeUsing;
    #endregion

    #region Hammer
    [Header("Hammer Using")]
    [SerializeField] private float rayHammerHitDistance;
    [SerializeField] private LayerMask maskHammerUsing;
    private bool isHammerPressing;
    #endregion

    #region Sleep
    [Header("Bed")]
    [SerializeField] private LayerMask maskSleep;
    [SerializeField] private float raySleepDistance;

    #endregion

    [Header("Fixing")]
    [SerializeField] private float fixingTimeNeed;
    [SerializeField] private float fixingTimer;
    private bool flagComesFromFinishFixing;

    private void Update()
    {
        PickObjects();
        PickaxeUsing();
        FixCorruptedShipParts();
        SleepIntteraction();
    }

    private void PickObjects()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            rayPickableDistance, maskPickable))
        {
            if (raycastHit.collider.CompareTag("Metal"))
            {
                helpingText.text = "Press [E] \n to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mySaveMaterials.metal += 10;
                    Destroy(raycastHit.collider.gameObject);
                    mySaveMaterials.UpdateMaterials();
                }
            }
            else if (raycastHit.collider.CompareTag("Gold"))
            {
                helpingText.text = "Press [E] \n to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mySaveMaterials.gold += 10;
                    Destroy(raycastHit.collider.gameObject);
                    mySaveMaterials.UpdateMaterials();
                }
            }
            else if (raycastHit.collider.CompareTag("Oil"))
            {
                helpingText.text = "Press [E] \n to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mySaveMaterials.oil += 10;
                    Destroy(raycastHit.collider.gameObject);
                    mySaveMaterials.UpdateMaterials();
                }
            }
        }
        else
        {
            helpingText.text = "";
        }
    }

    private void PickaxeUsing()
    {
        if (playerController.whichWeapon != 1)
            return;

        if (Input.GetMouseButtonDown(0) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            toolAnimator.SetTrigger("HitWithPickaxe");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
                rayPickaxeHitDistance, maskPickaxeUsing))
            {
                if (raycastHit.collider.CompareTag("Resource"))
                {
                    raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(4);
                    Debug.Log(raycastHit.collider.GetComponent<BreakableStone>().GetStability());
                }
            }
        }
    }

    private void FixCorruptedShipParts()
    {
        if (playerController.whichWeapon != 2)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            toolAnimator.SetTrigger("HitWithHammer");
            isHammerPressing = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(!flagComesFromFinishFixing)
                toolAnimator.SetTrigger("FinishHammerHit");
            isHammerPressing = false;
            OffFillFixFiller();
            flagComesFromFinishFixing = false;
        }

        if (isHammerPressing && Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
                    rayHammerHitDistance, maskSleep))
        {
            if (raycastHit.collider.CompareTag("CorruptedShipPart1"))
            {
                OnFillFixFiller();

                if(fixFiller.fillAmount >= 1)
                {
                    toolAnimator.SetTrigger("FinishHammerHit");
                    isHammerPressing = false;
                    OffFillFixFiller();
                    flagComesFromFinishFixing = true;
                }
            }
        }
            
    }

    private void SleepIntteraction()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            raySleepDistance, maskPickable))
        {
            if (raycastHit.collider.CompareTag("Bed"))
            {
                helpingText.text = "Press [E] \n to Sleep";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerAnimator.SetTrigger("Sleep");
                }
            }
        }
        else
        {
            helpingText.text = "";
        }
    }

    private void OnFillFixFiller()
    {
        fixingTimer += Time.deltaTime;
        fixFiller.fillAmount = fixingTimer / fixingTimeNeed;
    }

    private void OffFillFixFiller()
    {
        fixingTimer = 0;
        fixFiller.fillAmount = 0;
    }

}
