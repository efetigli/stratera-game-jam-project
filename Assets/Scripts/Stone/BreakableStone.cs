using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStone : MonoBehaviour
{
    [SerializeField] private int stability;
    [SerializeField] private GameObject[] ores;

    public void HitTheBreakableStone(int hitDamage)
    {
        stability = stability - hitDamage;
        if(stability <= 0)
        {
            for(int i = 0; i < ores.Length; i++)
            {
                ores[i].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }

    public int GetStability()
    {
        return stability;
    }
}
