using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOption : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text upgradeNameText;
    [SerializeField] private TMP_Text descriptionText;

    public void Init(Upgrade upgrade, Action<Upgrade> onClickCallback)
    {
        upgradeNameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.description;

        // Pass the chosen upgrade back to UpgradePanel.
        button.onClick.AddListener(() =>
        {
            onClickCallback?.Invoke(upgrade);
        });
    }
}
