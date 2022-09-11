using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Interaction interaction;
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        interaction.toolAnimator.ResetTrigger("FinishHammerHit");
        interaction.flagEsc = false;
        Time.timeScale = 1;
    }
}
