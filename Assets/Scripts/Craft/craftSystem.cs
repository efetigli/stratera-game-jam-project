using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class craftSystem : MonoBehaviour
{
    [Header("Craftables")]
    [SerializeField] float plate1ReqMetal;
    [SerializeField] float plate2ReqMetal;
    [SerializeField] float oilPerPlastic;
    [Header("Upgradeables")]
    [SerializeField] float mPReqMetal; // Metal Pickaxe
    [SerializeField] float gPReqGold; // Gold Pickaxe
    [SerializeField] float oS2ReqPlastic; // Oxygen System 
    [SerializeField] float oS2ReqMetal;
    [SerializeField] float oS3ReqPlastic;
    [SerializeField] float oS3ReqMetal;

    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;
    [SerializeField] private saveShip mySaveShip;

    [Header("Pick Axe")]
    [SerializeField] private Pickaxe myPickAxe;

    [Header("Oxygen")]
    [SerializeField] private Oxygen myOxygen;

    [Header("OilSlider")]
    [SerializeField] Slider oilSlider;

    [Header("Counter Texts")]
    public TextMeshProUGUI plasticCount;
    public TextMeshProUGUI oilCount; 

    [Header("OS Texts")]
    public Image oSLevel2;
    public Image oSLevel3;
    public TextMeshProUGUI osPlastic1;
    public TextMeshProUGUI osPlastic2;
    public TextMeshProUGUI oSMetal1;
    public TextMeshProUGUI oSMetal2;
    [Header("Buttons")]
    public Button plate1CraftButton;
    public Button plate2CraftButton;
    public Button mPUpgradeButton;
    public Button gPUpgradeButton;
    public Button oSUpgradeButton;

    [Header("Images")]
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;
    public Image Image5;
    public Image Image6;
    public Image Image7;

    [Header("Update in Screen Too")]
    [SerializeField] private craftSystem craftUIScreen;
    [SerializeField] private bool isScreen;
    void Start(){
        osPlastic2.enabled = false;
        oSMetal2.enabled = false;
        oSLevel3.enabled = false;
        Image1.enabled = false;
        Image2.enabled = false;
        Image3.enabled = false;
        Image4.enabled = false;
        Image5.enabled = false;
        Image6.enabled = false;
        Image7.enabled = false;
    }
    void FixedUpdate(){
        ////Debug.Log(mySaveMaterials.metal);
        ////Debug.Log(mySaveMaterials.plastic);
        ////Debug.Log(mySaveMaterials.oil);
        //oilCount.text = (oilSlider.value * oilPerPlastic).ToString("0");
        //plasticCount.text = oilSlider.value.ToString("0");
    }
    public void CheckerForCraft()
    {
        if (mySaveMaterials.isPlate1Crafted)
        {
            mySaveShip.hasLostPlate1 = true;
            plate1CraftButton.enabled = false;
            Image1.enabled = true;
        }
        if (mySaveMaterials.isPlate2Crafted)
        {
            mySaveShip.hasLostPlate2 = true;
            plate2CraftButton.enabled = false;
            Image2.enabled = true;
        }
        if (mySaveMaterials.isMetalPickaxeCrafted)
        {
            mPUpgradeButton.enabled = false;
            Image3.enabled = true;
        }
        if (mySaveMaterials.isGoldPickaxeCrafted)
        {
            gPUpgradeButton.enabled = false;
            Image4.enabled = true;
        }
        if (mySaveMaterials.isOxygenLevel2Upgrade)
        {
            osPlastic1.enabled = false;
            oSMetal1.enabled = false;
            oSLevel2.enabled = false;
            osPlastic2.enabled = true;
            oSMetal2.enabled = true;
            oSLevel3.enabled = true;
        }
        if (mySaveMaterials.isOxygenLevel3Upgrade)
        {
            oSUpgradeButton.enabled = false;
            Image5.enabled = true;
            Image6.enabled = true;
        }
    }

    public void craftPlate1(){
        if(plate1ReqMetal <= mySaveMaterials.metal){
            mySaveMaterials.metal = mySaveMaterials.metal - plate1ReqMetal;
            mySaveShip.hasLostPlate1 = true;
            mySaveMaterials.isPlate1Crafted = true;
            mySaveShip.isLostPlate1 = false;
            plate1CraftButton.enabled = false;
            Image1.enabled = true;
            if (isScreen)
            {
                craftUIScreen.craftPlate1Update();
            }
        }
        else{
            Debug.Log("You don't have enough metal!!");
        }
    }

    public void craftPlate1Update() 
    {
        mySaveShip.isLostPlate1 = false;
        plate1CraftButton.enabled = false;
        Image1.enabled = true;
    }

    public void craftPlate2(){
        if(plate2ReqMetal <= mySaveMaterials.metal){
            mySaveMaterials.metal = mySaveMaterials.metal - plate2ReqMetal;
            mySaveMaterials.isPlate1Crafted = true;
            mySaveShip.hasLostPlate2 = true;
            mySaveShip.isLostPlate2 = false;
            plate2CraftButton.enabled = false;
            Image2.enabled = true;
            if (isScreen)
            {
                craftUIScreen.craftPlate2Update();
            }
        }
        else{
            Debug.Log("You don't have enough metal!!");
        }
    }

    public void craftPlate2Update()
    {
        mySaveShip.isLostPlate2 = false;
        plate2CraftButton.enabled = false;
        Image2.enabled = true;
    }

    public void craftPlastic(){
        if(oilSlider.value * oilPerPlastic <= mySaveMaterials.oil){
            mySaveMaterials.oil = mySaveMaterials.oil - (oilSlider.value * oilPerPlastic);
            mySaveMaterials.plastic = mySaveMaterials.plastic + oilSlider.value;
            oilSlider.SetValueWithoutNotify(0);
            if (isScreen)
            {
                craftUIScreen.craftPlasticUpdate();
            }
        }
        else{
            Debug.Log("You don't have enough oil!!");
            oilSlider.SetValueWithoutNotify(0);
        }
    }

    public void craftPlasticUpdate()
    {
        oilSlider.SetValueWithoutNotify(0);
    }

    public void upgradeMP(){
        if(mPReqMetal <= mySaveMaterials.metal){
            mySaveMaterials.metal = mySaveMaterials.metal - mPReqMetal;
            if(mySaveMaterials.pickaxeType != "Gold")
            {
                mySaveMaterials.pickaxeType = "Metal";
                myPickAxe.AssignPickaxeHead();
            }
            mySaveMaterials.isMetalPickaxeCrafted = true;
            mPUpgradeButton.enabled = false;
            Image3.enabled = true;
            if (isScreen)
            {
                craftUIScreen.upgradeMPUpdate();
            }
        }
        else{
            Debug.Log("You don't have enough metal!!");
        }
    }

    public void upgradeMPUpdate()
    {
        mPUpgradeButton.enabled = false;
        Image3.enabled = true;
    }

    public void upgradeGP(){
        if(gPReqGold <= mySaveMaterials.gold){
            mySaveMaterials.metal = mySaveMaterials.gold - gPReqGold;
            mySaveMaterials.pickaxeType = "Gold";
            myPickAxe.AssignPickaxeHead();
            mySaveMaterials.isGoldPickaxeCrafted = true;
            gPUpgradeButton.enabled = false;
            Image4.enabled = true;
            if (isScreen)
            {
                craftUIScreen.upgradeGPUpdate();
            }
        }
        else{
            Debug.Log("You don't have enough gold!!");
        }
    }

    public void upgradeGPUpdate()
    {
        gPUpgradeButton.enabled = false;
        Image4.enabled = true;
    }

    public void UpgradeOSL(){
        if(mySaveMaterials.oxygenSystemLevel == 1){
            if(oS2ReqMetal <= mySaveMaterials.metal && oS2ReqPlastic <= mySaveMaterials.plastic){
                mySaveMaterials.metal = mySaveMaterials.metal - oS2ReqMetal;
                mySaveMaterials.plastic = mySaveMaterials.plastic - oS2ReqPlastic;
                mySaveMaterials.oxygenSystemLevel = 2;
                myOxygen.UpdateOxygenLevel();
                mySaveMaterials.isOxygenLevel2Upgrade = true;
                osPlastic1.enabled = false;
                oSMetal1.enabled = false;
                oSLevel2.enabled = false;
                osPlastic2.enabled = true;
                oSMetal2.enabled = true;
                oSLevel3.enabled = true;
                if (isScreen)
                {
                    craftUIScreen.UpgradeOSL1Update();
                }
            }
            else if(oS2ReqMetal <= mySaveMaterials.metal){
                Debug.Log("You don't have enough plastic!!");
            }
            else if(oS2ReqPlastic <= mySaveMaterials.plastic){
                Debug.Log("You don't have enough metal!!");
            }
            else{
                Debug.Log("You don't have enough metal and plastic!!");
            }
        }
        else{
            if(oS3ReqMetal <= mySaveMaterials.metal && oS3ReqPlastic <= mySaveMaterials.plastic){
                mySaveMaterials.metal = mySaveMaterials.metal - oS3ReqMetal;
                mySaveMaterials.plastic = mySaveMaterials.plastic - oS3ReqPlastic;
                mySaveMaterials.oxygenSystemLevel = 3;
                myOxygen.UpdateOxygenLevel();
                mySaveMaterials.isOxygenLevel3Upgrade = true;
                oSUpgradeButton.enabled = false;
                Image5.enabled = true;
                Image6.enabled = true;
                if (isScreen)
                {
                    craftUIScreen.UpgradeOSL2Update();
                }
            }
            else if(oS3ReqMetal <= mySaveMaterials.metal){
                Debug.Log("You don't have enough plastic!!");
            }
            else if(oS3ReqPlastic <= mySaveMaterials.plastic){
                Debug.Log("You don't have enough metal!!");
            }
            else{
                Debug.Log("You don't have enough metal and plastic!!");
            }
        }
    }

    public void UpgradeOSL1Update()
    {
        osPlastic1.enabled = false;
        oSMetal1.enabled = false;
        oSLevel2.enabled = false;
        osPlastic2.enabled = true;
        oSMetal2.enabled = true;
        oSLevel3.enabled = true;
    }

    public void UpgradeOSL2Update()
    {
        oSUpgradeButton.enabled = false;
        Image5.enabled = true;
        Image6.enabled = true;
    }
}
