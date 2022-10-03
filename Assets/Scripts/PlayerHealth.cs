using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;
    public void ReduceHealth(float damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
