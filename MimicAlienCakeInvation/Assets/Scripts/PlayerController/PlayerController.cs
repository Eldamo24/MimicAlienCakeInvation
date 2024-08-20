using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private FPController inputs;
    private Rigidbody rb;

    [Header("Movement")]
    private Vector2 move;
    private float moveForce = 3000f;
    
    private float jumpForce = 500f;

    [Header("CheckGround")]
    private bool isGrounded;

    void Start()
    {
        inputs = new FPController();
        rb = GetComponent<Rigidbody>();
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        move = inputs.Player.Movement.ReadValue<Vector2>();
        rb.AddForce(transform.forward * move.y * moveForce, ForceMode.Force);
        rb.AddForce(transform.right * move.x * moveForce);
    }
}
