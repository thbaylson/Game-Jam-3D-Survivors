using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveChoicePopup : MonoBehaviour
{
    [SerializeField] private Button selectButton;

    public void Open(UpgradeOption parentOption, Action onUpgradePicked)
    {
        gameObject.SetActive(true);
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => { onUpgradePicked?.Invoke(); });
    }

    public void CloseImmediate() => gameObject.SetActive(false);
}
