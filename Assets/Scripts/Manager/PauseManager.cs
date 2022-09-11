using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Interaction interaction;
    public bool isPause;

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
    }

    public void UnpauseGame()
    {
        interaction.flagEsc = false;
        isPause = false;
        Time.timeScale = 1;
    }
}
