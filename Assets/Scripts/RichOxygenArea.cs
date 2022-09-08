using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichOxygenArea : MonoBehaviour
{
    public bool isInsideOxygenRichArea { get; private set; }


    private void OnTriggerStay(Collider other)
    {
        // 8 is Player layer.
        if(other.gameObject.layer == 8)
        {
            isInsideOxygenRichArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            isInsideOxygenRichArea = false;
        }
    }
}
