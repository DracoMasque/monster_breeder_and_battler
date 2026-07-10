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
        
        
        rb.linearVelocity = moveInput.normalized * speed;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
    
    public void EdgeMove(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<Vector2>().y < screenEdge)
        {
            moveInput.y = -1f;
        }
        else if (ctx.ReadValue<Vector2>().y > Screen.height - screenEdge)
        {
            moveInput.y = +1f;
        }
        
        if (ctx.ReadValue<Vector2>().x < screenEdge)
        {
            moveInput.x = -1f;
        }
        else if (ctx.ReadValue<Vector2>().x > Screen.width - screenEdge)
        {
            moveInput.x = +1f;
        }

        if (ctx.ReadValue<Vector2>().y > screenEdge && ctx.ReadValue<Vector2>().y < Screen.height - screenEdge &&
            ctx.ReadValue<Vector2>().x > screenEdge && ctx.ReadValue<Vector2>().x < Screen.width - screenEdge)
        {
            moveInput.x = 0f;
            moveInput.y = 0f;
        }
    }
    
}
    
    
