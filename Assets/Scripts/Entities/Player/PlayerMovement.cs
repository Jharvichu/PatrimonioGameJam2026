using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private InputActionReference movementAction;
	[SerializeField] private float movementSpeed;
	[SerializeField] private Rigidbody rb;

	private Vector2 moveDirection;
	private Vector2 lastNonZeroDirection = Vector2.up;

	public Vector2 Direction
	{
		get => moveDirection;
    }

	public Vector2 LastNonZeroDirection
	{
		get => lastNonZeroDirection;
	}

	public bool IsMoving
	{
		get => moveDirection.magnitude > 0.01f;
	}

	private void OnEnable()
	{
		movementAction.action.Enable();
	}

	private void OnDisable()
	{
		movementAction.action.Disable();
	}

	private void Update()
	{
        moveDirection = movementAction.action.ReadValue<Vector2>();
		if (IsMoving)
			lastNonZeroDirection = moveDirection;
	}

	private void FixedUpdate()
	{
		if (moveDirection.magnitude > 0.01f)
            rb.linearVelocity = new Vector3(moveDirection.x * movementSpeed, rb.linearVelocity.y, moveDirection.y * movementSpeed);
        else
			rb.linearVelocity = new Vector3(0.0f, rb.linearVelocity.y, 0.0f);
    }
}
