using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;
    [SerializeField] private Transform HealthLook;
    [SerializeField] private float reduceSpeed = 2;

    private float target = 1;

    [HideInInspector] public float _currentHealth;

    [HideInInspector] public bool isDead = false;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        HealthLook.transform.rotation = Quaternion.LookRotation(HealthLook.transform.position - cam.transform.position);


        healthBarSprite.fillAmount = Mathf.Lerp(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);

        if (isDead)
        {
            Invoke("Died", 0);
            isDead = true;
            gameObject.SetActive(false);
        }
    }

    void Died()
    {
        Debug.Log("You'r Dead");
        
    }

    public void UpdateHealthBar(float t_maxHealth, float t_currentHealth)
    {
        target = t_currentHealth / t_maxHealth;
    }

}
