using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Attributes")]
    // movement direction based on controller input
    public Vector2 moveDirection;
    // movement speed based on controller input intensity
    public float moveSpeed;

    [Space]
    [Header("Character Attributes")]
    // base movement speed
    public float baseSpeed = 1.0f;

    [Space]
    [Header("Reference Components")]
    // rigidbody 2d class for interactions
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // read controller inputs
        ProcessInputs();
        // translate character
        Movement();
    }

    // This function processes the controller input
    void ProcessInputs()
    {
        // Get vector from controller input
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // Base the movement speed on the intensity of controller input, clamp magnitude to be between 0 and 1
        moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();
    }

    // This function acts on the controller input and is called after ProcessInputs() and makes the player move
    void Movement()
    {
        rb.velocity = moveDirection * moveSpeed * baseSpeed;
    }
}
