using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStone : MonoBehaviour
{
    [SerializeField] private float stability;
    [SerializeField] private GameObject[] ores;

    [SerializeField] private AudioSource audioSource;

    public void HitTheBreakableStone(float hitDamage)
    {
        stability = stability - hitDamage;
        if(stability <= 0)
        {
            audioSource.Play();
            for (int i = 0; i < ores.Length; i++)
            {
                ores[i].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }

    public float GetStability()
    {
        return stability;
    }
}
