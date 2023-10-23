using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;

    private void OnTriggerEnter(Collider other) // using a trigger system using collider 
    {
        if (other.gameObject.CompareTag("Enemy")) // if object has an Enemy Tag 
        {
            TakeDamage(5); //player takes damage 
        }

        if (other.gameObject.CompareTag("MiniBoss")) 
        {
            TakeDamage(10);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            TakeDamage(15);
        }
    }

    private void Update()
    {
        if(healthAmount <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }
}
