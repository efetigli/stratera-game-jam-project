using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource pickaxeHit;
    [SerializeField] public AudioSource hammerHit;
    [SerializeField] public AudioSource pickObjetSound;

    [Header("Which Type of Interaction")]
    [SerializeField] private Image ShowingType;
    [SerializeField] private TextMeshProUGUI helpingText;
    [SerializeField]private TextMeshProUGUI helpingText2;
    [SerializeField]private TextMeshProUGUI helpingText3;
    [SerializeField]private TextMeshProUGUI helpingText4;

    [Header("Images")]
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject wrench;
    [SerializeField] private GameObject pickaxeImage;

    [Header("Which Tool are using")]
    [SerializeField] private PlayerController playerController;

    [Header("Animators")]
    [SerializeField] public Animator toolAnimator;
    [SerializeField] private Animator playerAnimator;


    [Header("Fix Filler")]
    [SerializeField] private Image fixFiller;

    [Header("Main Camera")]
    [SerializeField] private Camera mainCamera;

    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;
    [SerializeField] private saveShip saveShip;

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


    [Header("Upgrade")]
    [SerializeField] private LayerMask maskUpgrade;
    [SerializeField] private float rayUpgradeDistance;

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

    private GameObject raycastHittingCollider;

    [Header("Pause Manager")]
    [SerializeField] private PauseManager pauseManager;
    private void Update()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
        PickObjects();
        PickaxeUsing();
        //FixCorruptedShipParts();
        UpgradeShipParts();
        InteractWithChair();
            SleepIntteraction();
            InteractionWithScreens();

        }
    }

    [Header("Feedback Ore Player UI Element")]
    [SerializeField] private GameObject feedbackOreUI;
    [HideInInspector] public bool isCollectNewOre;
    [HideInInspector] public string whichCollectNewOreType;
    [HideInInspector] public string amountCollectNewOre;

    private void PickObjects()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            rayPickableDistance, maskPickable))
        {
            if (raycastHit.collider.CompareTag("Metal"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                Debug.Log("asd");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    #region Collect By Looking Pickaxe Type
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.metal += stonePickaxeOreValue;
                        amountCollectNewOre = stonePickaxeOreValue.ToString();
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                        feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.metal += metalPickaxeOreValue;
                        amountCollectNewOre = metalPickaxeOreValue.ToString();
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                        feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.metal += goldPickaxeOreValue;
                        amountCollectNewOre = goldPickaxeOreValue.ToString();
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                        feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    }
                    #endregion
                    whichCollectNewOreType = "Metal";
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Gold"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    #region Collect By Looking Pickaxe Type
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.gold += stonePickaxeOreValue;
                        amountCollectNewOre = stonePickaxeOreValue.ToString();
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                        feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.gold += metalPickaxeOreValue;
                        amountCollectNewOre = metalPickaxeOreValue.ToString();
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                        feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        feedbackOreUI.SetActive(false);
                        mySaveMaterials.gold += goldPickaxeOreValue;
                        amountCollectNewOre = goldPickaxeOreValue.ToString();
                        isCollectNewOre = true;
                        feedbackOreUI.SetActive(true);
                        feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    }
                    #endregion
                    whichCollectNewOreType = "Gold";
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Oil"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //#region Collect By Looking Pickaxe Type
                    //if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    //{
                    //    feedbackOreUI.SetActive(false);
                    //    mySaveMaterials.oil += stonePickaxeOreValue;
                    //    amountCollectNewOre = stonePickaxeOreValue;
                    //    isCollectNewOre = true;
                    //    feedbackOreUI.SetActive(true);
                    //    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    //}
                    //else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    //{
                    //    feedbackOreUI.SetActive(false);
                    //    mySaveMaterials.oil += metalPickaxeOreValue;
                    //    amountCollectNewOre = metalPickaxeOreValue;
                    //    isCollectNewOre = true;
                    //    feedbackOreUI.SetActive(true);
                    //    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    //}
                    //else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    //{
                    //    feedbackOreUI.SetActive(false);
                    //    mySaveMaterials.oil += goldPickaxeOreValue;
                    //    amountCollectNewOre = goldPickaxeOreValue;
                    //    isCollectNewOre = true;
                    //    feedbackOreUI.SetActive(true);
                    //    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    //}
                    //#endregion
                    pickObjetSound.Play();
                    feedbackOreUI.SetActive(false);
                    mySaveMaterials.oil += 200;
                    amountCollectNewOre = 200.ToString();
                    isCollectNewOre = true;
                    feedbackOreUI.SetActive(true);
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    whichCollectNewOreType = "Oil";
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Wing2"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    isCollectNewOre = true;
                    feedbackOreUI.SetActive(true);
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    whichCollectNewOreType = "";
                    amountCollectNewOre = "Wing Lvl.2";
                    saveShip.hasWingPieceLevel2 = true;
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Wing3"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    feedbackOreUI.SetActive(true);
                    amountCollectNewOre = "Wing Lvl.3";
                    whichCollectNewOreType = "";
                    isCollectNewOre = true;
                    saveShip.hasWingPieceLevel3 = true;
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Engine2"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                Debug.Log("asd");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    feedbackOreUI.SetActive(true);
                    amountCollectNewOre = "Engine Lvl.2";
                    whichCollectNewOreType = "";
                    isCollectNewOre = true;
                    saveShip.hasEngineLevel2 = true;
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Engine3"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                Debug.Log("asd");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    feedbackOreUI.SetActive(true);
                    amountCollectNewOre = "Engine Lvl.3";
                    whichCollectNewOreType = "";
                    isCollectNewOre = true;
                    saveShip.hasEngineLevel3 = true;
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Booster2"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                Debug.Log("asd");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    feedbackOreUI.SetActive(true);
                    amountCollectNewOre = "Booster Rocker Lvl.2";
                    whichCollectNewOreType = "";
                    isCollectNewOre = true;
                    saveShip.hasBoosterRocketLevel2 = true;
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    Destroy(raycastHit.collider.gameObject);
                }
            }
            else if (raycastHit.collider.CompareTag("Booster3"))
            {
                hand.SetActive(true);
                helpingText.text = "Press [E]\nTo Collect";
                Debug.Log("asd");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickObjetSound.Play();
                    feedbackOreUI.SetActive(true);
                    amountCollectNewOre = "Booster Rocker Lvl.3";
                    whichCollectNewOreType = "";
                    isCollectNewOre = true;
                    saveShip.hasBoosterRocketLevel3 = true;
                    feedbackOreUI.GetComponent<FeedBackOrePlayerUI>().closeTimer = 0f;
                    Destroy(raycastHit.collider.gameObject);
                }
            }
        }
        else if(!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit rayHit,
            rayPickableDistance, maskPickable))
        {
            hand.SetActive(false);
            helpingText.text = "";
        }
    }



    private void PickaxeUsing()
    {
        if (playerController.whichWeapon != 1 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            toolAnimator.SetTrigger("HitWithPickaxe");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
                rayPickaxeHitDistance, maskPickaxeUsing))
            {
                pickaxeImage.SetActive(true);
                if (raycastHit.collider.CompareTag("Resource"))
                {
                    if (pickaxe.GetTypeOfPickaxe() == "Stone")
                    {
                        pickaxeHit.Play();
                        raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(stonePickaxeDamageValue);
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Metal")
                    {
                        raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(metalPickaxeDamageValue);
                        pickaxeHit.Play();
                    }
                    else if (pickaxe.GetTypeOfPickaxe() == "Gold")
                    {
                        raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(goldPickaxeDamageValue);
                        pickaxeHit.Play();
                    }
                }
            }
        }
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycstHit,
                rayPickaxeHitDistance, maskPickaxeUsing))
        {
            pickaxeImage.SetActive(true);
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raystHit,
                rayPickaxeHitDistance, maskPickaxeUsing))
        {
            pickaxeImage.SetActive(false);
        }
    }

    //private void FixCorruptedShipParts()
    //{
    //    if (playerController.whichWeapon != 2)
    //        return;


    //    if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
    //    {
    //        toolAnimator.SetTrigger("HitWithHammer");
    //        isHammerPressing = true;
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        if(!flagComesFromFinishFixing)
    //            toolAnimator.SetTrigger("FinishHammerHit");
    //        isHammerPressing = false;
    //        OffFillFixFiller();
    //        flagComesFromFinishFixing = false;
    //    }

    //    if (isHammerPressing && Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
    //                rayHammerHitDistance, maskHammerUsing))
    //    {
    //        if (raycastHit.collider.CompareTag("CorruptedShipPart1"))
    //        {
    //            OnFillFixFiller();

    //            if(fixFiller.fillAmount >= 1)
    //            {
    //                toolAnimator.SetTrigger("FinishHammerHit");
    //                isHammerPressing = false;
    //                OffFillFixFiller();
    //                flagComesFromFinishFixing = true;
    //            }
    //        }
    //    }
            
    //}

    private void SleepIntteraction()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            raySleepDistance, maskSleep))
        {
            if (raycastHit.collider.CompareTag("Bed"))
            {
                if(!isSleeping)
                    helpingText2.text = "Press [E]\nTo Sleep";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerAnimator.SetTrigger("Sleep");
                    isSleeping = true;
                    helpingText2.text = "";
                }
            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycasHit,
            raySleepDistance, maskSleep))
        {
            isSleeping = false;
            helpingText2.text = "";
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
    [SerializeField] private GameObject statScreenCanvas;

    [Header("Cursor Manager")]
    [SerializeField] private CursorManager cursorManager;

    public bool flagScreenOpen;

    public void setFlagFalse()
    {
        flagScreenOpen = false;
    }
    private void InteractionWithScreens()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            rayScreenDistance, maskScreen))
        {
            if (raycastHit.collider.CompareTag("UgradeScreen"))
            {
                helpingText.text = "Press [E]\nTo Open Screen";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    upgradeScreenCanvas.SetActive(true);
                    cursorManager.UnlockCursor();
                    pauseManager.PauseGame();
                    //openScreens.ClosePlayerComponents();
                    //flagScreenOpen = true;
                }
            }
            if (raycastHit.collider.CompareTag("StatScreen"))
            {
                helpingText.text = "Press [E]\nTo Open Screen";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    statScreenCanvas.SetActive(true);
                    cursorManager.UnlockCursor();
                    pauseManager.PauseGame();
                    //openScreens.ClosePlayerComponents();
                    //flagScreenOpen = true;
                }
            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycasHit,
            rayScreenDistance, maskScreen))
        {
            helpingText.text = "";
        }
    }

    [HideInInspector] public bool flagEsc;
    public bool flagHammerHit;

    private void UpgradeShipParts()
    {
        if (playerController.whichWeapon != 2 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;


        if (flagEsc== false && Input.GetMouseButtonDown(0))
        {
            toolAnimator.SetTrigger("HitWithHammer");
            toolAnimator.SetBool("FinishHammerHit2", false);
            isHammerPressing = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!flagComesFromFinishFixing)
            {
                toolAnimator.SetBool("FinishHammerHit2", true);
            }
            //toolAnimator.SetTrigger("FinishHammerHit");
            isHammerPressing = false;
            OffFillFixFiller();
            flagComesFromFinishFixing = false;
        }

        //if (isHammerPressing == false)
        //{
        //    hammerHit.Stop();
        //    flagHammerHit = false;
        //}


        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
                    rayUpgradeDistance, maskUpgrade))
        {
            //if (isHammerPressing && flagHammerHit==false)
            //{
            //    hammerHit.Play();
            //    flagHammerHit = true;
            //}
            wrench.SetActive(true);
            //error message
            if (raycastHit.collider.CompareTag("Wing"))
            {
                if (saveShip.wingLevel == 3)
                {
                    wrench.SetActive(false);
                    helpingText3.text = "Reach Max Upgrade Level";
                    return;
                }
                else if (saveShip.wingLevel == 1 && saveShip.hasWingPieceLevel2 == false)
                {
                    helpingText3.text = "You Don't Have\nWing Lvl.2 To Upgrade";
                    return;
                }
                else if (saveShip.wingLevel == 2 && saveShip.hasWingPieceLevel3 == false)
                {
                    helpingText3.text = "You Don't Have\nWing Lvl.3 To Upgrade";
                    return;
                }
                else
                {
                    helpingText3.text = "Click Left Mouse Click\nTo Upgrade";
                }
            }
            if (raycastHit.collider.CompareTag("Booster"))
            {
                if (saveShip.boosterRocketLevel == 3)
                {
                    wrench.SetActive(false);
                    helpingText3.text = "Reach Max Upgrade Level";
                    return;
                }
                else if (saveShip.boosterRocketLevel == 1 && saveShip.hasBoosterRocketLevel2 == false)
                {
                    helpingText3.text = "You Don't Have\nBooster Rocket Lvl.2 To Upgrade";
                    return;
                }
                else if (saveShip.boosterRocketLevel == 2 && saveShip.hasBoosterRocketLevel3 == false)
                {
                    helpingText3.text = "You Don't Have\nBooster Rocket Lvl.3 To Upgrade";
                    return;
                }
                else
                {
                    helpingText3.text = "Click Left Mouse Click\nTo Upgrade";
                }
            }
            if (raycastHit.collider.CompareTag("Engine"))
            {
                if (saveShip.engineLevel == 3)
                {
                    wrench.SetActive(false);
                    helpingText3.text = "Reach Max Upgrade Level";
                    return;
                }
                else if (saveShip.engineLevel == 1 && saveShip.hasEngineLevel2 == false)
                {
                    helpingText3.text = "You Don't Have\nEngine Lvl.2 To Upgrade";
                    return;
                }
                else if (saveShip.engineLevel == 2 && saveShip.hasEngineLevel2 == false)
                {
                    helpingText3.text = "You Don't Have\nEngine Lvl.3 To Upgrade";
                    return;
                }
                else
                {
                    helpingText3.text = "Click Left Mouse Click\nTo Upgrade";
                }
            }
            if (raycastHit.collider.CompareTag("Crash1"))
            {
                if (saveShip.isLostPlate1 == true)
                {
                    wrench.SetActive(false);
                    helpingText3.text = "Reach Max Upgrade Level";
                    return;
                }
                else if (saveShip.isLostPlate1 == false && saveShip.hasLostPlate1 == false)
                {
                    helpingText3.text = "You Don't Have\nPlate1 To Upgrade";
                    return;
                }
                else
                {
                    helpingText3.text = "Click Left Mouse Click\nTo Upgrade";
                }
            }
            if (raycastHit.collider.CompareTag("Crash2"))
            {
                if (saveShip.isLostPlate2 == true)
                {
                    wrench.SetActive(false);
                    helpingText3.text = "Reach Max Upgrade Level";
                    return;
                }
                else if (saveShip.isLostPlate2 == false && saveShip.hasLostPlate2 == false)
                {
                    helpingText3.text = "You Don't Have\nPlate2 To Upgrade";
                    return;
                }
                else
                {
                    helpingText3.text = "Click Left Mouse Click\nTo Upgrade";
                }
            }

            if (isHammerPressing)
            {
                helpingText.text = "";
                if (raycastHit.collider.CompareTag("Wing"))
                {
                    OnFillFixFiller();

                    if (fixFiller.fillAmount >= 1)
                    {
                        if (saveShip.wingLevel == 1)
                        {
                            wingLvl1.SetActive(false);
                            wingLvl2.SetActive(true);
                            saveShip.wingLevel = 2;
                            saveShip.UpdateWing();
                        }
                        else if (saveShip.wingLevel == 2)
                        {
                            wingLvl3.SetActive(true);
                            saveShip.wingLevel = 3;
                            saveShip.UpdateWing();
                        }
                        //toolAnimator.SetTrigger("FinishHammerHit");
                        toolAnimator.SetBool("FinishHammerHit2", true);
                        //hammerHit.Stop();
                        //flagHammerHit = false;
                        isHammerPressing = false;
                        OffFillFixFiller();
                        flagComesFromFinishFixing = true;
                    }
                }
                if (raycastHit.collider.CompareTag("Booster"))
                {
                    OnFillFixFiller();

                    if (fixFiller.fillAmount >= 1)
                    {
                        if (saveShip.boosterRocketLevel == 1)
                        {
                            boosterLvl2.SetActive(true);
                            saveShip.boosterRocketLevel = 2;
                            saveShip.UpdateBooster();
                        }
                        else if (saveShip.boosterRocketLevel == 2)
                        {
                            boosterLvl3.SetActive(true);
                            saveShip.boosterRocketLevel = 3;
                            saveShip.UpdateBooster();
                        }
                        toolAnimator.SetTrigger("FinishHammerHit");
                        toolAnimator.SetBool("FinishHammerHit2", true);
                        //hammerHit.Stop();
                        //flagHammerHit = false;
                        isHammerPressing = false;
                        OffFillFixFiller();
                        flagComesFromFinishFixing = true;
                    }
                }
                if (raycastHit.collider.CompareTag("Engine"))
                {
                    OnFillFixFiller();

                    if (fixFiller.fillAmount >= 1)
                    {
                        if (saveShip.engineLevel == 1)
                        {
                            engineLvl2.SetActive(true);
                            saveShip.engineLevel = 2;
                            saveShip.UpdateEngine();
                        }
                        else if (saveShip.engineLevel == 2)
                        {
                            engineLvl3.SetActive(true);
                            saveShip.engineLevel = 3;
                            saveShip.UpdateEngine();
                        }
                        toolAnimator.SetTrigger("FinishHammerHit");
                        toolAnimator.SetBool("FinishHammerHit2", true);
                        //hammerHit.Stop();
                        //flagHammerHit = false;
                        isHammerPressing = false;
                        OffFillFixFiller();
                        flagComesFromFinishFixing = true;
                    }
                }
                if (raycastHit.collider.CompareTag("Crash1"))
                {
                    OnFillFixFiller();

                    if (fixFiller.fillAmount >= 1)
                    {
                        plate1.SetActive(true);
                        saveShip.isLostPlate1 = true;
                        saveShip.UpdateShipPartLostPlate();
                        toolAnimator.SetTrigger("FinishHammerHit");
                        toolAnimator.SetBool("FinishHammerHit2", true);
                        //hammerHit.Stop();
                        //flagHammerHit = false;
                        isHammerPressing = false;
                        OffFillFixFiller();
                        flagComesFromFinishFixing = true;
                    }
                }
                if (raycastHit.collider.CompareTag("Crash2"))
                {
                    OnFillFixFiller();

                    if (fixFiller.fillAmount >= 1)
                    {
                        plate2.SetActive(true);
                        saveShip.isLostPlate2 = true;
                        saveShip.UpdateShipPartLostPlate();
                        toolAnimator.SetTrigger("FinishHammerHit");
                        toolAnimator.SetBool("FinishHammerHit2", true);
                        //hammerHit.Stop();
                        //flagHammerHit = false;
                        hammerHit.Stop();
                        isHammerPressing = false;
                        OffFillFixFiller();
                        flagComesFromFinishFixing = true;
                    }
                }

            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycasHit,
                    rayUpgradeDistance, maskUpgrade))
        {
            //toolAnimator.SetBool("FinishHammerHit2", true);
            //hammerHit.Stop();
            //flagHammerHit = false;
            wrench.SetActive(false);
            helpingText3.text = "";
        }

    }

    [Header("Chair Object")]
    [SerializeField] private LayerMask maskChair;
    [SerializeField] private float rayChairDistance;

    private void InteractWithChair()
    {
        if (!saveShip.finishGame)
            return;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
            rayChairDistance, maskChair))
        {
            if (raycastHit.collider.CompareTag("Rescue"))
            {
                helpingText4.text = "Press [E]\nTo Rescue";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("asdasd");
                }
            }
        }
        else if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycatHit,
            rayChairDistance, maskChair))
        {
            helpingText4.text = "";
        }
    }

}
