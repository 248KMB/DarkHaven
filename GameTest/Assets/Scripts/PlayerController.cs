using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    private bool isMoving;
    private float timeSinceLastClick = 0f;
    private float comboTimeThreshold = 0.5f; // Time window between clicks for combo attacks
    private int comboCount = 0;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 gravityVector = Vector3.down * gravity * Time.deltaTime;
        characterController.Move(gravityVector);

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        characterController.Move(movement * speed * Time.deltaTime);

        isMoving = movement.magnitude > 0;

        animator.SetFloat("Speed", movement.magnitude); // Use magnitude for speed, not a fixed value

        animator.SetBool("IsRunning", isMoving);

        if (isMoving && Input.GetMouseButtonDown(0))
        {
            if (Time.time > timeSinceLastClick + comboTimeThreshold)
            {
                comboCount = 0;
            }

            comboCount++;
            timeSinceLastClick = Time.time;

            comboCount = Mathf.Clamp(comboCount, 1, 3);

            string attackAnimation = "Attack" + comboCount;
            animator.SetBool("IsAttacking", true);
            animator.SetTrigger(attackAnimation);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}