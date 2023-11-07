using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 100;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider we hit is an enemy
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.TakeDamage(damage);
        }
    }
}