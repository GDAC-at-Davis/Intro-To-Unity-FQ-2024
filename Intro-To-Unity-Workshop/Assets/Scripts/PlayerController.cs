using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]

    [SerializeField, Tooltip("How fast does the player move horizontally?")]
    private float moveSpeed;

    [SerializeField, Tooltip("How high can the player jump, in Units?")]
    private float jumpHeight;

    [SerializeField, Tooltip("What is the gravity acceleration?")]
    private float gravity;
    
    private CharacterController characterController;
    
    // input fields
    private Vector2 input;
    private Vector2 transformedInput;
    private bool jumpPressed;
    
    // movement fields
    private float yVelocity;
    private float rotateAngle;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        GetInput();
        Move();
        Rotate();
    }
    
    private void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        
        jumpPressed = Input.GetButtonDown("Jump");
        
        // rotate input based on camera
        transformedInput = new Vector2(input.x, input.y).normalized;
        transformedInput = Quaternion.Euler(0, 0, -Camera.main.transform.eulerAngles.y) * transformedInput;
    }
    
    private void Move()
    {
        Vector3 move = new Vector3(transformedInput.x, 0, transformedInput.y) * (moveSpeed * Time.deltaTime);
        
        // Vertical movement
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if (characterController.isGrounded)
        {
            yVelocity = -2f;
        }
        
        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity * Time.deltaTime;
        
        characterController.Move(move);
    }
    
    private void Rotate()
    {
        if (transformedInput != Vector2.zero)
        {
            rotateAngle = Mathf.Atan2(transformedInput.x, transformedInput.y) * Mathf.Rad2Deg;
        }
        
        float t = 1 - Mathf.Pow(1 - 0.99f, Time.deltaTime / 0.5f);
        
        transform.rotation = Quaternion.Lerp( transform.rotation, Quaternion.Euler(0, rotateAngle, 0), t);
    }
}
