using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStone : MonoBehaviour
{
    [SerializeField] private int stability;

    public void HitTheBreakableStone(int hitDamage)
    {
        stability = stability - hitDamage;
        if(stability <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int GetStability()
    {
        return stability;
    }
}
