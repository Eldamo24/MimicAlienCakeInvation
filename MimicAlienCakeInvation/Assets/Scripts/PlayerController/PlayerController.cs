using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private PlayerInput inputs;
    private Rigidbody rb;

    [Header("Movement")]
    private Vector2 move;
    private float moveForce = 3000f;
    
    private float jumpForce = 500f;

    [Header("CheckGround")]
    [SerializeField] private LayerMask groundLayer;
    private Transform checkGround;
    private bool isGrounded;

    void Start()
    {
        inputs = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        checkGround = GameObject.Find("CheckGround").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, 0.2f, groundLayer);
        Movement();
    }

    private void Movement()
    {
        move = inputs.actions["Movement"].ReadValue<Vector2>();
        rb.AddForce(transform.forward * move.y * moveForce, ForceMode.Force);
        rb.AddForce(transform.right * move.x * moveForce);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
            
    }
}
