using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _damageSound;
    public float MaxHealth => maxHealth;
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public event System.Action<float> OnHealthChanged;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return;
        currentHealth = Mathf.Max(0, currentHealth - amount);
        OnHealthChanged?.Invoke(currentHealth / maxHealth);

        _audioSource.PlayOneShot(_damageSound);
    }
}
