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

    [Header("Collecting Ore")]
    [SerializeField] private Pickaxe pickaxe;
    [SerializeField] private float stonePickaxeOreValue;
    [SerializeField] private float metalPickaxeOreValue;
    [SerializeField] private float goldPickaxeOreValue;

    [Header("Pickaxe Damage")]
    [SerializeField] private float stonePickaxeDamageValue;
    [SerializeField] private float metalPickaxeDamageValue;
    [SerializeField] private float goldPickaxeDamageValue;


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
    private bool isSleeping;
    #endregion

    #region Screen
    [Header("Screen")]
    [SerializeField] private LayerMask maskScreen;
    [SerializeField] private float rayScreenDistance;
    [SerializeField] private OpenScreens openScreens;
    #endregion

    [Header("Fixing")]
    [SerializeField] private float fixingTimeNeed;
    [SerializeField] private float fixingTimer;
    private bool flagComesFromFinishFixing;


    private GameObject raycastHittingCollider;
    private void Update()
    {
        PickObjects();
        PickaxeUsing();
        FixCorruptedShipParts();
        SleepIntteraction();
        InteractionWithScreens();
    }

    [Header("Feedback Ore Player UI Element")]
    [SerializeField] private GameObject feedbackOreUI;
    [HideInInspector] public bool isCollectNewOre;
    [HideInInspector] public string whichCollectNewOreType;
    [HideInInspector] public float amountCollectNewOre;

    private void PickObjects()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            rayPickableDistance, maskPickable))
        {
            if (raycastHit.collider.CompareTag("Metal"))
            {
                helpingText.text = "Press [E] \n to collect";
                Debug.Log("asd");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    #region Collect By Looking Pickaxe Type
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.metal += stonePickaxeOreValue;
                        amountCollectNewOre = stonePickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.metal += metalPickaxeOreValue;
                        amountCollectNewOre = metalPickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.metal += goldPickaxeOreValue;
                        amountCollectNewOre = goldPickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    #endregion
                    whichCollectNewOreType = "Metal";
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Gold"))
            {
                helpingText.text = "Press [E] \n to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    #region Collect By Looking Pickaxe Type
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.gold += stonePickaxeOreValue;
                        amountCollectNewOre = stonePickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.gold += metalPickaxeOreValue;
                        amountCollectNewOre = metalPickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.gold += goldPickaxeOreValue;
                        amountCollectNewOre = goldPickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    #endregion
                    whichCollectNewOreType = "Gold";
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Oil"))
            {
                helpingText.text = "Press [E] \n to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    #region Collect By Looking Pickaxe Type
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.oil += stonePickaxeOreValue;
                        amountCollectNewOre = stonePickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.oil += metalPickaxeOreValue;
                        amountCollectNewOre = metalPickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.oil += goldPickaxeOreValue;
                        amountCollectNewOre = goldPickaxeOreValue;
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                    }
                    #endregion
                    whichCollectNewOreType = "Oil";
                    Destroy(raycastHit.collider.gameObject);
                }
            }
        }
        else if(!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit rayHit,
            rayPickableDistance, maskPickable))
        {
            helpingText.text = "";
        }
    }



    private void PickaxeUsing()
    {
        if (playerController.whichWeapon != 1)
            return;

        if (Input.GetMouseButtonDown(0) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            toolAnimator.SetTrigger("HitWithPickaxe");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
                rayPickaxeHitDistance, maskPickaxeUsing))
            {
                Debug.Log("ad");
                if (raycastHit.collider.CompareTag("Resource"))
                {
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(stonePickaxeDamageValue);
                        Debug.Log(raycastHit.collider.GetComponent<BreakableStone>().GetStability());
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(metalPickaxeDamageValue);
                        Debug.Log(raycastHit.collider.GetComponent<BreakableStone>().GetStability());
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(goldPickaxeDamageValue);
                        Debug.Log(raycastHit.collider.GetComponent<BreakableStone>().GetStability());
                    }
                }
            }
        }
    }

    private void FixCorruptedShipParts()
    {
        if (playerController.whichWeapon != 2)
            return;


        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
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
                    rayHammerHitDistance, maskHammerUsing))
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
            raySleepDistance, maskSleep))
        {
            if (raycastHit.collider.CompareTag("Bed"))
            {
                if(!isSleeping)
                    helpingText.text = "Press [E] \n to Sleep";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerAnimator.SetTrigger("Sleep");
                    isSleeping = true;
                    helpingText.text = "";
                }
            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit rayHit,
            rayPickableDistance, maskPickable))
        {
            isSleeping = false;
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

    [Header("Screen Canvases")]
    [SerializeField] private GameObject upgradeScreenCanvas;

    [Header("Cursor Manager")]
    [SerializeField] private CursorManager cursorManager;


    private void InteractionWithScreens()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            rayScreenDistance, maskScreen))
        {
            if (raycastHit.collider.CompareTag("UgradeScreen"))
            {
                helpingText.text = "Press [E] \n to Open Screen";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    openScreens.ClosePlayerComponents();
                    upgradeScreenCanvas.SetActive(true);
                    cursorManager.UnlockCursor();
                }
            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit rayHit,
            rayPickableDistance, maskPickable))
        {
            helpingText.text = "";
        }
    }
}
