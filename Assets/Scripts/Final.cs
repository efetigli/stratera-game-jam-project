using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{

    [Header("Timer")]
    [SerializeField] private float finalTime;
    [SerializeField] private float finalTimer;


    private void Update()
    {
        End();
    }

    private void End()
    {
        finalTimer += Time.deltaTime;
        if (finalTimer >= finalTime)
        {
            Invoke("LoadScene", 1f);
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
