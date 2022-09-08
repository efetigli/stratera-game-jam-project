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
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask maskGround;

    [Header("Speeds")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    private Vector3 movement;

    private float xRotate = 0f;

    void Start()
    {
        // Daha sonra burdan kald�r!!
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateHeadLeftAndRight(); RotateHeadUpAndDown();
        Movement();
        Jump();
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

        this.transform.position += movement * movementSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
            rigidBody.AddForce(Vector3.up * jumpSpeed);
    }

    private bool IsGround()
    {
        return Physics.CheckSphere(checkGround.position, 0.2f, maskGround);
    }
}