using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;


    public float groundDrag;

    public float jumpForce;
    public float airMultiplier;

    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform orientation;

    private float inputX;
    private float inputY;

    private Vector3 moveDirection;

    private Rigidbody rb;

    public GameObject footsteps;

    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, ((playerHeight * 0.5f) + 0.2f), whatIsGround);

        Controls();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

    
    }

    private void FixedUpdate()
    {
        Move();
       
    }

    private void Controls()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

    }

    private void Move()
    {
        moveDirection = (orientation.forward * inputY) + (orientation.right * inputX);

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);           
        }
    }

    public void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        float CurrentSpeed = rb.velocity.magnitude;

        if(CurrentSpeed < 0.1f)
        {
            anim.SetFloat("speed", 0f);
            footsteps.SetActive(false);
        }

        else if(CurrentSpeed > 0.01f)
        {
            anim.SetFloat("speed", 1f);
            footsteps.SetActive(true);
        }

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

}
