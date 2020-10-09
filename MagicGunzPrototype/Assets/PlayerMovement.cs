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

    // rigidbody 2d class for cursor
    public Rigidbody2D curs;

    // mouse position
    public Vector2 mousePos;

    // player camera
    public Camera playerCam;

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
        MovePlayer();

        // rotate character
        RotatePlayer();
    }

    // This function processes the controller input
    void ProcessInputs()
    {
        // Get vector from controller input
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Base the movement speed on the intensity of controller input, clamp magnitude to be between 0 and 1
        moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();

        // Get mouse position (cursor position)
        mousePos = curs.position; //playerCam.ScreenToWorldPoint(Input.mousePosition);
    }

    // This function acts on the controller input and is called after ProcessInputs() and makes the player move
    void MovePlayer()
    {
        rb.velocity = moveDirection * moveSpeed * baseSpeed;
    }

    // This function acts on a mouse/look joystick input and is called after ProcessInputs() to make the player rotate
    void RotatePlayer()
    {
        // Get the look direction for the player
        Vector2 lookVec = mousePos - rb.position;

        // Compute angle around unit circle that the look direction is rotated
        float lookAngle = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg - 90f;

        // Change rotation of the player
        rb.rotation = lookAngle;
    }
}
