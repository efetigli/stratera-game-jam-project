using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaDie : MonoBehaviour
{
    [Header("OxygenSystem")]
    [SerializeField] private Oxygen oxygen;

    [Header("Death")]
    [SerializeField] private GameObject deathUI;
    [SerializeField] private Animator deathAnimator;

    [Header("Timer")]
    [SerializeField] private float deathTime;
    [SerializeField] private float deathTimer;

    [Header("Close Player Components")]
    [SerializeField] private OpenScreens openScreens;

    [Header("Save files")]
    [SerializeField] private saveShip mySaveShip;
    [SerializeField] private saveMaterials mySaveMaterial;

    public bool lavaTouch;

    private void Awake()
    {
        lavaTouch = false;
    }

    private void Update()
    {
        DyingLava();
    }
    private void DyingLava()
    {
        if (lavaTouch == false)
            return;

        deathTimer += Time.deltaTime;
        if (deathTimer >= deathTime)
        {
            openScreens.DieCloseComponents();
            if (deathTimer <= (deathTime + 0.2f))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(1f, this.GetComponent<Rigidbody>().velocity.y, 1f);
                Invoke("LoadScene", 3f);
            }
            else if (deathTimer <= (deathTime + 1f) && deathTimer > (deathTime + 1.6f))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f, this.GetComponent<Rigidbody>().velocity.y, 0f);
            }
            mySaveMaterial.loadMaterialsData();
            mySaveShip.loadShipData();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            lavaTouch = true;
            deathTimer = deathTime;
            deathUI.SetActive(true);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
