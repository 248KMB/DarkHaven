using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
 
    public GameObject Mace;

    private float comboTimeThreshold = 0.6f; // Time window between clicks for combo attacks
    private int comboCount = 0;
    private float lastAttackTime = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            print("Hi");
        }
    }
}
