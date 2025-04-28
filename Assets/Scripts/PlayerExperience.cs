using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int current;

    [SerializeField] private int baseRequired = 30;
    [SerializeField] private float growthRate = 1.25f;

    public int Level { get => level; private set { } }
    public int Current { get => current; private set { } }

    // eg: 30, 38, 47, 59, 73, etc
    public int requiredForNextLvl => Mathf.RoundToInt(baseRequired * Mathf.Pow(growthRate, level - 1));

    public event System.Action<int> OnLevelChanged;
    public event System.Action<float> OnExpChanged;

    public void Add(int amount)
    {
        current += amount;
        if (current >= requiredForNextLvl)
        {
            current -= requiredForNextLvl;
            level++;
            OnLevelChanged?.Invoke(level);
        }

        OnExpChanged?.Invoke((float)current / requiredForNextLvl);
    }
}
