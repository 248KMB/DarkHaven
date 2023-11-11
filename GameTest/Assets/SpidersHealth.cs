using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SpidersHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;
    public float damagePerSecond = 10f; // Damage per second when player is touching the spider
    public EnemyHealth enemyHealth;
    public PlayerController playerController;
    private bool isTouchingSpider = false;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (healthAmount <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        // Check for mouse button click and if player is touching the spider
        if (isTouchingSpider && Input.GetMouseButton(0)) // 0 represents the left mouse button
        {
            TakeDamage(damagePerSecond * Time.deltaTime); // Continuous damage per second
            Debug.Log("Spider took " + (damagePerSecond * Time.deltaTime) + " damage. Current health: " + healthAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouchingSpider = true; // Player is touching the spider
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouchingSpider = false; // Player is not touching the spider anymore
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Destroy the spider when health is less than or equal to zero
        Debug.Log("Spider defeated!");
    }

    public void TakeDamage(float Damage)
    {
        if(!playerController.isMoving)
        {
            int damageInt = Mathf.CeilToInt(Damage); // Round the float up to the nearest integer
            damageInt = Mathf.Max(1, damageInt); // Ensure a minimum of 1 damage is dealt
            healthAmount -= damageInt;
            healthBar.fillAmount = healthAmount / 100;
            Debug.Log("Spider's health: " + healthAmount + ", Health Bar fill amount: " + healthBar.fillAmount);

            // Call TakeDamage method from EnemyHealth script
            enemyHealth.TakeDamage(damageInt);

            if (healthAmount <= 0)
            {
                Die();
            }
        }
    }
}