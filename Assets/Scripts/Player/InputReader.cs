using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [Header("Mouse Settings")]
    [SerializeField] private float mouseSensitivity;

    public Vector2 move { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public float jump { get; private set; }
    public bool fastRun { get; private set; }

    [Header("Inside Ship")]
    [SerializeField] private RichOxygenArea InsideShip;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PauseManager pauseManager;

    [Header("Cursor Manager")]
    [SerializeField] private CursorManager cursorManager;



    void Start()
    {
        
    }

    void Update()
    {
        LookInput();
        MovementInput();
        FastRunInput();
        OpenPauseMenu();
    }

    private void LookInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    private void MovementInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        move = new Vector2(x, y);
    }

    private void FastRunInput()
    {
        if (InsideShip.isInsideOxygenRichArea)
        {
            fastRun = false;
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            fastRun = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fastRun = false;
        }
    }

    private void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.GetComponent<Interaction>().flagEsc = true;
            this.GetComponent<Interaction>().hammerHit.Stop();
            this.GetComponent<Interaction>().flagHammerHit = false;
            cursorManager.UnlockCursor();
            pauseMenu.SetActive(true);
            pauseManager.PauseGame();
        }
    }
}
