using UnityEngine;

public class OpenScreens: MonoBehaviour
{

    [Header("Player Components")]
    [SerializeField] private CapsuleCollider playerCapsuleCollider;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private InputReader playerInputReader;
    [SerializeField] private Oxygen playerOxygen;
    [SerializeField] private PlayerController playerPlayerController;
    [SerializeField] private Interaction playerInteraction;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject playerTool;

    public void ClosePlayerComponents()
    {
        playerCapsuleCollider.enabled = false;
        playerInputReader.enabled = false;
        playerOxygen.enabled = false;
        playerPlayerController.enabled = false;
        playerInteraction.enabled = false;
    }

    public void OpenPlayerComponents()
    {
        playerCapsuleCollider.enabled = true;
        playerInputReader.enabled = true;
        playerOxygen.enabled = true;
        playerPlayerController.enabled = true;
        playerInteraction.enabled = true;

    }

    public void DieCloseComponents()
    {
        playerInputReader.enabled = false;
        playerOxygen.enabled = false;
        playerPlayerController.enabled = false;
        playerInteraction.enabled = false;
        playerAnimator.enabled = false;
        playerTool.SetActive(false);
        playerRigidbody.freezeRotation = false;

    }
}
