using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [Header("Which Type of Interaction")]
    [SerializeField] private Image ShowingType;

    [Header("Raycast Components")]
    [SerializeField] private LayerMask maskInteractable;
    [SerializeField] private float rayDistance = 100f;

    [Header("Main Camera")]
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        InteractableRaycast();
    }

    private void InteractableRaycast()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out raycastHit,
            rayDistance, maskInteractable))
        {
            if (raycastHit.collider.CompareTag("Deneme"))
            {
                Debug.Log("ads");
            }
        }
    }

}
