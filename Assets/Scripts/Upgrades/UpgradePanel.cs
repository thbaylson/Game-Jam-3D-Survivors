using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Transform optionContainer;
    [SerializeField] private UpgradeOption optionPrefab;
    [SerializeField] private GunChoicePopup gunChoicePopup;
    [SerializeField] private PassiveChoicePopup passiveChoicePopup;

    private GameObject player;
    private List<UpgradeOption> upgradeOptions = new();

    public void Open(GameObject player, List<Upgrade> upgrades)
    {
        if (upgrades == null) { return; }

        // Pause the game and show the cursor.
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Display the Upgrade UI.
        this.player = player;
        gameObject.SetActive(true);
        SpawnOptions(upgrades);
    }

    public void Close()
    {
        // Hide the Upgrade UI and clear options.
        DespawnOptions();
        gunChoicePopup.CloseImmediate();
        gameObject.SetActive(false);

        // Resume the game and hide the cursor.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    private void SpawnOptions(List<Upgrade> upgrades)
    {
        foreach (Upgrade upgrade in upgrades)
        {
            UpgradeOption option = Instantiate(optionPrefab, optionContainer);
            upgradeOptions.Add(option);
            option.Init(upgrade, chosenUpgrade =>
            {
                HandleUpgradeChosen(option, chosenUpgrade);
            });
        }
    }

    private void DespawnOptions()
    {
        foreach (UpgradeOption option in upgradeOptions)
        {
            Destroy(option.gameObject);
        }
        upgradeOptions.Clear();
    }

    private void HandleUpgradeChosen(UpgradeOption option, Upgrade upgrade)
    {
        if (upgrade.Type == UpgradeType.Passive)
        {
            PassiveChoicePopup passiveChoice = Instantiate(passiveChoicePopup, option.transform);
            passiveChoice.Open(option, () =>
            {
                upgrade.Apply(player);
                Close();
            });
        }
        else
        {
            GunChoicePopup gunChoice = Instantiate(gunChoicePopup, option.transform);
            gunChoice.Open(option, (chosenGun) =>
            {
                upgrade.Apply(player, chosenGun);
                Close();
            });
        }
    }
}
