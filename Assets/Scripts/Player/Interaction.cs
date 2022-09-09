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

    [Header("Main Camera")]
    [SerializeField] private Camera mainCamera;

    [Header("Saves")]
    [SerializeField] private saveMaterials mySaveMaterials;

    #region Pickable
    [Header("Pick Objects")]
    [SerializeField] private LayerMask maskPickable;
    [SerializeField] private float rayPickableDistance;
    #endregion

    #region Tool
    [Header("Tool Using")]
    [SerializeField] private float rayToolHitDistance;
    [SerializeField] private LayerMask maskToolUsing;

    [Header("Tool Animator")]
    [SerializeField] private Animator toolAnimator;
    #endregion

    private void Update()
    {
        PickObjects();
        ToolUsing();
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
                    mySaveMaterials.oil += 10;
                    Destroy(raycastHit.collider.gameObject);
                    mySaveMaterials.UpdateMaterials();
                }
            }
            else if (raycastHit.collider.CompareTag("Oil"))
            {
                helpingText.text = "Press [E] \n to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mySaveMaterials.gold += 10;
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

    private void ToolUsing()
    {
        if (Input.GetMouseButtonDown(0) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            toolAnimator.SetTrigger("HitWithPickaxe");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit,
                rayToolHitDistance, maskToolUsing))
            {
                if (raycastHit.collider.CompareTag("Resource"))
                {
                    raycastHit.collider.GetComponent<BreakableStone>().HitTheBreakableStone(4);
                    Debug.Log(raycastHit.collider.GetComponent<BreakableStone>().GetStability());
                }
            }
        }
    }

}
