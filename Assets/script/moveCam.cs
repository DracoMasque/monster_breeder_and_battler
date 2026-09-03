using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int screenEdge;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocity = _moveInput.normalized * speed;
        print(_moveInput);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        print(_moveInput);
    }
    
    public void EdgeMove(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<Vector2>().y < screenEdge)
        {
            _moveInput.y = -1f;
        }
        else if (ctx.ReadValue<Vector2>().y > Screen.height - screenEdge)
        {
            _moveInput.y = +1f;
        }
        
        if (ctx.ReadValue<Vector2>().x < screenEdge)
        {
            _moveInput.x = -1f;
        }
        else if (ctx.ReadValue<Vector2>().x > Screen.width - screenEdge)
        {
            _moveInput.x = +1f;
        }

        if (ctx.ReadValue<Vector2>().y > screenEdge && ctx.ReadValue<Vector2>().y < Screen.height - screenEdge &&
            ctx.ReadValue<Vector2>().x > screenEdge && ctx.ReadValue<Vector2>().x < Screen.width - screenEdge)
        {
            _moveInput.x = 0f;
            _moveInput.y = 0f;
        }
    }
}
    
    
