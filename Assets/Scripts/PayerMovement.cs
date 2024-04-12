using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 12f;
    public float JumpHeight = 5f;
    public float gravity = -19.6f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance  = 0.4f;
    public LayerMask groundMask;


    bool isGrounded ;
    // Start is called before the first frame 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded&&velocity.y<0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x + transform.forward*z;

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        if (Input.GetButton("Sprint"))
        {
            Speed = 22f;
        }
        else
        {
            Speed = 12f;
        }
        Debug.Log(Speed);

        Controller.Move(move*Speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        Controller.Move(velocity*Time.deltaTime);

    }
}
