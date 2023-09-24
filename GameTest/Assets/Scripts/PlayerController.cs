using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    private bool isMoving;
    public float speed;
    public float rotationSpeed;
    public float gravity = 9.81f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Get input from the WASD keys or arrow keys.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 gravityVector = Vector3.down * gravity * Time.deltaTime;
        characterController.Move(gravityVector);

        // Calculate the movement vector.
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement.Normalize();

        characterController.Move(movement * speed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if the player is providing movement input.
        isMoving = movement.magnitude > 0;

        animator.SetFloat("Speed", speed);

        animator.SetBool("IsRunning", isMoving);
        

    }
}