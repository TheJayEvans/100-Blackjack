using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class InputHandler : MonoBehaviour
{
    public InputAction moveAction, jumpAction, interactAction;
    public CharacterController characterController;
    public GameObject player;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactAction = InputSystem.actions.FindAction("Interact");

        jumpAction.performed += Jump;
        interactAction.performed += Interact;

        characterController = GetComponent<CharacterController>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        characterController.Jump();
    }

    private void Interact(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        characterController.Move(moveVector);
    }
}