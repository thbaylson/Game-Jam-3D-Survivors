using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _damageSoundVolume;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _damageSounds;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    public event System.Action<float> OnHealthChanged;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (_currentHealth <= 0) return;
        _currentHealth = Mathf.Max(0, _currentHealth - amount);
        OnHealthChanged?.Invoke(_currentHealth / _maxHealth);
        int randomDamageSound = Random.Range(0, _damageSounds.Length);
        _audioSource.PlayOneShot(_damageSounds[randomDamageSound],_damageSoundVolume);
    }
}
