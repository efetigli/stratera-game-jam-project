using UnityEngine;
public class craftSystem : MonoBehaviour
{
    [Header("Craftables")]
    [SerializeField] float plate1ReqMetal;
    [SerializeField] float plate2ReqMetal;
    [SerializeField] float plasticLimitTop;
    [SerializeField] float plasticLimitButtom;

    [Header("Upgradeables")]
    [SerializeField] float mPReqMetal;
    [SerializeField] float gPReqGold;
    [SerializeField] float oxygenSystem2ReqPlastic;
    [SerializeField] float oxygenSystem2ReqMetal;
    [SerializeField] float oxygenSystem3ReqPlastic;
    [SerializeField] float oxygenSystem3ReqMetal;
    [SerializeField] float bootsLevel2ReqPlastic;
    [SerializeField] float bootsLevel3ReqPlastic;

    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;
    
    public void craftPlate1(){
        Debug.Log("asdada");
    }
    public void craftPlate2(){
        Debug.Log("asdada");
    }
    public void craftPlastic(){
        Debug.Log("asdada");
    }
    public void upgradeMP(){
        Debug.Log("asdada");
    }
    public void upgradeGP(){
        Debug.Log("asdada");
    }
    public void UpgradeOSL(){
        Debug.Log("asdada");
    }
    public void UpgradeBL(){
        Debug.Log("asdada");
    }
}
