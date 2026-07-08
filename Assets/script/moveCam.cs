using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class moveCam : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int screenEdge;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * speed;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
    
    public void EdgeMove(InputAction.CallbackContext ctx)
    {
        print(Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
        
        
    }
    
}
    
    
