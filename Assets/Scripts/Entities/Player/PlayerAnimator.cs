using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private PlayerMovement movementManager;

    private static readonly int dirXHash = Animator.StringToHash("dirX");
    private static readonly int dirYHash = Animator.StringToHash("dirY");
    private static readonly int isMovingHash = Animator.StringToHash("isMoving");

    private void Update()
    {
        playerAnimator.SetFloat(dirXHash, movementManager.LastNonZeroDirection.x);
        playerAnimator.SetFloat(dirYHash, movementManager.LastNonZeroDirection.y);
        playerAnimator.SetBool(isMovingHash, movementManager.IsMoving);
    }
}
