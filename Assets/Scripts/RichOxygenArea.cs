using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichOxygenArea : MonoBehaviour
{
    public bool isInsideOxygenRichArea { get; private set; }

    [Header("Player Flaslight")]
    [SerializeField] private GameObject flashLight;

    private void Update()
    {
        Debug.Log(isInsideOxygenRichArea);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            isInsideOxygenRichArea = true;
            flashLight.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // 8 is Player layer.
        if (other.gameObject.layer == 8)
        {
            isInsideOxygenRichArea = true;
            flashLight.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            isInsideOxygenRichArea = false;
            flashLight.SetActive(true);
        }
    }
}
