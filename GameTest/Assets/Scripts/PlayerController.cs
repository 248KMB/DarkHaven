using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    private bool isMoving;
    private float comboTimeThreshold = 0.5f; // Time window between clicks for combo attacks
    private int comboCount = 0;
    private float lastAttackTime = 0f;

    public float speed;
    public float rotationSpeed;
    public float gravity = 9.81f;

    public float damageAmount = 10f; // Set the damage amount according to your game's balance
    public GameObject spiderGameObject; // Assign the spider GameObject in the Unity Editor


    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        // Find the spider GameObject using its tag
        spiderGameObject = GameObject.FindGameObjectWithTag("Enemy");

        if (spiderGameObject == null)
        {
            Debug.LogError("Spider GameObject not found!");
        }
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

        animator.SetBool("IsAttacking", false);

        // Check if enough time has passed for a new combo to start
        if (Time.time > lastAttackTime + comboTimeThreshold)
        {
            comboCount = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsAttacking", true);
            // Increment the combo count
            comboCount++;
            if (comboCount == 4)
            {
                comboCount = 1;
            }

            // Play the attack animation
            animator.SetInteger("ComboCount", comboCount);
            animator.SetTrigger("Attack" + comboCount);

            // Update the last attack time
            lastAttackTime = Time.time;
        }
    }

    private void DealDamageToSpider()
    {
        // Check if the spider is in range (you can use a similar approach as OnTriggerEnter)
        SpidersHealth spiderHealth = spiderGameObject.GetComponent<SpidersHealth>();

        // If the spider health script is found, deal damage to the spider
        if (spiderHealth != null)
        {
            spiderHealth.TakeDamage(damageAmount);
        }
    }
}