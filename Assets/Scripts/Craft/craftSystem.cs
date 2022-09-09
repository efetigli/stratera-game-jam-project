using UnityEngine;
public class craftSystem : MonoBehaviour
{
    [Header("Craftables")]
    [SerializeField] float plate1ReqMetal;
    [SerializeField] float plate2ReqMetal;
    [SerializeField] float plasticLimitTop;
    [SerializeField] float plasticLimitButtom;

    [Header("Upgradeables")]
    [SerializeField] float mPReqMetal; // Metal Pickaxe
    [SerializeField] float gPReqGold; // Gold Pickaxe
    [SerializeField] float oS2ReqPlastic; // Oxygen System 
    [SerializeField] float oS2ReqMetal;
    [SerializeField] float oS3ReqPlastic;
    [SerializeField] float oS3ReqMetal;
    [SerializeField] float bL2ReqPlastic;  // Boots Level
    [SerializeField] float bL3ReqPlastic;

    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;
    [SerializeField] private saveShip mySaveShip;
    
    public void craftPlate1(){
        if(plate1ReqMetal <= mySaveMaterials.metal){
            mySaveMaterials.metal = mySaveMaterials.metal - plate1ReqMetal;
            mySaveShip.isLostPlate1 = false;
        }
        else{
            Debug.Log("You don't have enough metal!!");
        }
    }
    public void craftPlate2(){
        if(plate2ReqMetal <= mySaveMaterials.metal){
            mySaveMaterials.metal = mySaveMaterials.metal - plate2ReqMetal;
            mySaveShip.isLostPlate2 = false;
        }
        else{
            Debug.Log("You don't have enough metal!!");
        }
    }
    public void craftPlastic(){
        Debug.Log("asdada");
    }
    public void upgradeMP(){
        if(mPReqMetal <= mySaveMaterials.metal){
            mySaveMaterials.metal = mySaveMaterials.metal - mPReqMetal;
            mySaveMaterials.pickaxeType = "Metal";
        }
        else{
            Debug.Log("You don't have enough metal!!");
        }
    }
    public void upgradeGP(){
        if(gPReqGold <= mySaveMaterials.gold){
            mySaveMaterials.metal = mySaveMaterials.metal - mPReqMetal;
            mySaveMaterials.pickaxeType = "Gold";
        }
        else{
            Debug.Log("You don't have enough gold!!");
        }
    }
    public void UpgradeOSL(){
        if(mySaveMaterials.oxygenSystemLevel == 1){
            if(oS2ReqMetal <= mySaveMaterials.metal && oS2ReqPlastic <= mySaveMaterials.plastic){
                mySaveMaterials.metal = mySaveMaterials.metal - oS2ReqMetal;
                mySaveMaterials.plastic = mySaveMaterials.plastic - oS2ReqPlastic;
                mySaveMaterials.oxygenSystemLevel = 2;
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
    public void UpgradeBL(){
        if(mySaveMaterials.bootsLevel == 1){
            if(bL2ReqPlastic <= mySaveMaterials.plastic){
                mySaveMaterials.plastic = mySaveMaterials.plastic - bL2ReqPlastic;
                mySaveMaterials.bootsLevel = 2;
            }
            else{
                Debug.Log("You don't have enough plastic!!");
            }
        }
        else{
           if(bL3ReqPlastic <= mySaveMaterials.plastic){
                mySaveMaterials.plastic = mySaveMaterials.plastic - bL3ReqPlastic;
                mySaveMaterials.bootsLevel = 3;
            }
            else{
                Debug.Log("You don't have enough plastic!!");
            }
        }
    }
}
