using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Player Stats")]
    private GameObject player;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image expBar;

    [Header("Wave Stats")]
    private GameObject waveManager;
    [SerializeField] private TMP_Text waveNumberText;
    [SerializeField] private TMP_Text waveTimeText;

    private void Awake()
    {
        player = FindFirstObjectByType<PlayerExperience>().gameObject;
        waveManager = FindFirstObjectByType<EnemyWaveManager>().gameObject;
    }

    private void Start()
    {
        if (player != null)
        {
            player.GetComponent<Health>().OnHealthChanged += UpdateHealthBar;
            player.GetComponent<PlayerExperience>().OnLevelChanged += UpdateLevelText;
            player.GetComponent<PlayerExperience>().OnExpChanged += UpdateExpBar;
        }

        if(waveManager != null)
        {
            waveManager.GetComponent<EnemyWaveManager>().OnWaveCountChange += UpdateWaveNumberText;
            waveManager.GetComponent<EnemyWaveManager>().OnWaveTimerChange += UpdateWaveTimeText;
        }
    }

    private void UpdateHealthBar(float percentage)
    {
        healthBar.fillAmount = percentage;
    }

    private void UpdateLevelText(int level)
    {
        levelText.text = $"Level: {level}";
    }

    private void UpdateExpBar(float percentage)
    {
        expBar.fillAmount = percentage;
    }

    private void UpdateWaveTimeText(float duration)
    {
        int minutes = Mathf.FloorToInt(duration / 60);
        int seconds = Mathf.FloorToInt(duration % 60);
        waveTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpdateWaveNumberText(int num)
    {
        waveNumberText.text = $"Wave: {num}";
    }
}
