using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input Reader")]
    [SerializeField] private InputReader inputReader;

    [Header("Head of Player")]
    [SerializeField] private Transform mainCamera;

    [Header("Player Components")]
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Animator animator;
    private const float AnimatorDampTime = 0.1f;

    [Header("Ground Checking")]
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask maskGround;

    [Header("Tool Animator")]
    [SerializeField] private Animator toolAnimator;

    [Header("Speeds")]
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    public float movementSpeed;
    private Vector3 movement;
    private float xRotate = 0f;

    [Header("Tools")]
    [SerializeField] private GameObject pickaxe;
    [SerializeField] private GameObject hammer;
    public int whichWeapon { get; private set; }


    void Start()
    {
        // Daha sonra burdan kald�r!!
        //Cursor.lockState = CursorLockMode.Locked;
        whichWeapon = 1;
    }

    void Update()
    {
        RotateHeadLeftAndRight(); RotateHeadUpAndDown();
        Movement();
        Jump();
        HoldingTool();
        OpnMaterialInfoPanel();
    }

    private void RotateHeadLeftAndRight()
    {
        this.transform.Rotate(Vector3.up * inputReader.mouseX);
    }

    private void RotateHeadUpAndDown()
    {
        xRotate -= inputReader.mouseY;
        // Head look limitation
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        mainCamera.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
    }

    private void Movement()
    {
        movement = transform.right * inputReader.move.x + transform.forward * inputReader.move.y;

        if (!inputReader.fastRun)
            movementSpeed = walkSpeed;
        else if (inputReader.fastRun)
            movementSpeed = runSpeed;

        if (movement == Vector3.zero)
            animator.SetFloat("IdleAndWalk", 0f, AnimatorDampTime, Time.deltaTime);
        else if (movement != Vector3.zero)
        {
            if(movementSpeed == runSpeed)
                animator.SetFloat("IdleAndWalk", 1f, AnimatorDampTime, Time.deltaTime);
            else if (movementSpeed == walkSpeed)
                animator.SetFloat("IdleAndWalk", 0.5f, AnimatorDampTime, Time.deltaTime);
        }


        transform.position += movement.normalized * movementSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
            rigidBody.AddForce(Vector3.up * jumpSpeed);
    }

    public bool IsGround()
    {
        return Physics.CheckSphere(checkGround.position, 0.01f, maskGround);
    }

    private void ClickWithLetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }           
    }

    private void HoldingTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            pickaxe.SetActive(true);
            hammer.SetActive(false);
            whichWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            pickaxe.SetActive(false);
            hammer.SetActive(true);
            whichWeapon = 2;
        }

        if((Input.GetAxisRaw("Mouse ScrollWheel") > 0.05f || Input.GetAxisRaw("Mouse ScrollWheel") < -0.05f) && toolAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if(whichWeapon == 1)
            {
                pickaxe.SetActive(false);
                hammer.SetActive(true);
                whichWeapon = 2;
            }
            else if(whichWeapon == 2)
            {
                pickaxe.SetActive(true);
                hammer.SetActive(false);
                whichWeapon = 1;
            }
        }
    }
    [Header("Material Player UI Element")]
    [SerializeField] private GameObject materialsInfoUI;
    [HideInInspector] public bool isPressMaterialShow;

    private void OpnMaterialInfoPanel()
    {
        if (Input.GetKeyDown(KeyCode.I) && !materialsInfoUI.GetComponent<MaterialInfoPlayerUI>().isClosingMaterialsInfo)
        {
            isPressMaterialShow = true;
            materialsInfoUI.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.I))
        {
            isPressMaterialShow = false;
        }
    }
}
