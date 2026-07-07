using UnityEngine;
using UnityEngine.InputSystem;

public class moveCam : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputActionReference moveInputReference;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * (speed * Time.fixedDeltaTime));
    }

    void OnEnable()
    {
        moveInputReference.action.Enable();
        moveInputReference.action.performed += OnMove;
        moveInputReference.action.canceled += OnMoveCancel;
    }

    void OnDisable()
    {
        moveInputReference.action.performed -= OnMove;
        moveInputReference.action.canceled -= OnMoveCancel;
        moveInputReference.action.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
    
    private void OnMoveCancel(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }
}
