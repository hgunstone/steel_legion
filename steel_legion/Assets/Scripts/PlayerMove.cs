using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed;
    public float sprintMultiplier;
    public float crouchSpeed;
    public float groundDrag;

    public float crouchYScale; //Crouch Height
    public float startYScale;  //Normal Height

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [Header("State")]
    public bool sprinting;
    public bool walking;
    public bool crouching;
    public bool jumping;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public Transform orientation;

    // WASD
    float horizontailInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        // Initializing variables

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        walking = true;
        sprinting = false;
        jumping = false;
        startYScale = transform.localScale.y; // Getting Y scale of player object
    }

    private void Update()
    {
        //Check if you are grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 
       

        MyInput();
        SpeedControl();

        if (grounded) // Adds drag/friction when you are on the ground
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;           
        }

        if (Input.GetKeyUp(sprintKey)) // Setting bools for when you stop sprinting
        {
            walking = true;
            sprinting = false;
        }

        if (sprinting) //Setting bools for when you start sprinting
        {
            walking = false;
        }

        if (Input.GetKeyDown(crouchKey)) // Setting bools for when you start crouching
        {
            crouching = true;
            walking = false;
        }
        
        if (Input.GetKeyUp(crouchKey)) // Setting bools for when you stop crouching
        {
            crouching = false;
            walking = true;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer(); // calls the MovePlayer method
    }
    private void MyInput()
    {
        horizontailInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded) //calls this function if the press space, are grounded and is ready to jump
        {
            // setting bools
            readyToJump = false;
            jumping = true;

            jump(); // calls the jump method

            Invoke(nameof(ResetJump), jumpCooldown); // calls the restet jump function after the jump cooldown
        }

        if(Input.GetKey(sprintKey) && !crouching) //Calls this function if you press the sprint key and are not crouching
        {
            rb.AddForce(moveDirection.normalized * (sprintMultiplier) * 10f, ForceMode.Force); // adds force in the direction of the player

            sprinting = true; //sets bool
        }
        if (Input.GetKeyDown(crouchKey)) //calls this function if you press down on the crouch key
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z); // makes the Y scale the crouch Y scale
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); // adds force down to keep you on the ground
        }

        if (Input.GetKeyUp(crouchKey)) // calls this method if you let go of the crouch key
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z); //returns the Y scale back to normal
        }
    }
    private void MovePlayer()
    {
        //
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontailInput;

        if(grounded && !sprinting) // calls this function if you are grounded and not sprinting
            rb.AddForce(moveDirection.normalized * walkSpeed * 10f, ForceMode.Force); // adds force in the move direction

        if (!grounded && !sprinting) // calls this function if you are not grounded or sprinting
            rb.AddForce(moveDirection.normalized * walkSpeed * 10f * airMultiplier, ForceMode.Force); // adds force in the move direction but multiplied by the airMultiplier
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > walkSpeed && walking) // calls this function if the you are walking and are over walkspeed
        {
            Vector3 limitedVel = flatVel.normalized * walkSpeed; // sets limitedVel to the walkspeed
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); // limits the velocity with limitedVel
        }

        else if (flatVel.magnitude > sprintMultiplier && sprinting) // calls this function if the you are sprinting and are over sprint speed
        {
            Vector3 limitedVel = flatVel.normalized * sprintMultiplier; // sets limitedVel to the sprintspeed
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); // limits the velocity with limited vel
        }

        else if (flatVel.magnitude > crouchSpeed && crouching) // calls this function if the you are crouching and are over crouch speed
        {
            Vector3 limitedVel = flatVel.normalized * crouchSpeed; // sets limitedVel to the crouchSpeed
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); // limits the velocity with limited vel       
        }
    }
    private void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // restets the Y velocity

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); // adds force upwards
    }
    private void ResetJump()
    {
        readyToJump = true; // sets ready to jump to true
    }
}