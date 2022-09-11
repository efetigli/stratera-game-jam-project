using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichOxygenArea : MonoBehaviour
{
    public bool isInsideOxygenRichArea { get; private set; }

    [Header("O2 Sounds")]
    [SerializeField] private AudioSource inO2;
    [SerializeField] private AudioSource outO2;

    [Header("Player Flaslight")]
    [SerializeField] private GameObject flashLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            isInsideOxygenRichArea = true;
            flashLight.SetActive(false);
            inO2.enabled = true;
            outO2.enabled = false;
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
            outO2.enabled = true;
            inO2.enabled = false;
        }
    }
}
