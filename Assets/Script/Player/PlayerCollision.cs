using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    #region Variables
    [SerializeField] private float maxHealth = 3;
    private float currentHealth;

    [SerializeField] private PlayerHealth playerHealth;

    private bool isHitted;
    #endregion

    private void Start()
    {
        currentHealth = maxHealth;
        playerHealth.UpdateHealthBar(maxHealth, currentHealth);
        playerHealth._currentHealth = currentHealth;
    }

    private void Update()
    {
        TrackHealth();
    }


    #region player collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hurt") && currentHealth > 0)
        {
            isHitted = true;
            currentHealth -= 1;
        }
    }
    #endregion

    #region Tracking Health
    private void TrackHealth()
    {
        if (isHitted)
        {
            playerHealth.UpdateHealthBar(maxHealth, currentHealth);
        }
        if (currentHealth == 0)
        {
            playerHealth.isDead = true;
        }
    }
    #endregion
}
