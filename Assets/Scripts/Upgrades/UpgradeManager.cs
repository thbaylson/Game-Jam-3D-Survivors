using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UpgradeDatabase database;
    [SerializeField] private UpgradePanel panel;

    private void Awake()
    {
        player.GetComponent<PlayerExperience>().OnLevelChanged += OpenChoices;
    }

    private void OpenChoices(int newLevel)
    {
        var candidates = database.RollThree();
        panel.Open(player, candidates);
    }
}

