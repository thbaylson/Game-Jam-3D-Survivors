using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    public float MaxHealth => maxHealth;
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return;
        currentHealth = Mathf.Max(0, currentHealth - amount);
    }
}
