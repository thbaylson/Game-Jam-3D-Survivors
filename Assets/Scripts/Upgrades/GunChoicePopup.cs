using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunChoicePopup : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    public void Open(UpgradeOption parentOption, Action<GunBase> onGunPicked)
    {
        // TODO: Maybe just pass the player from UpgradePanel instead of finding it here?
        GunBase player = FindFirstObjectByType<GunBase>();
        if (player == null) { return; }

        gameObject.SetActive(true);

        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();

        leftButton.onClick.AddListener(() => { onGunPicked?.Invoke(player.GetComponent<ManualFiring>()); });
        rightButton.onClick.AddListener(() => { onGunPicked?.Invoke(player.GetComponent<AutomaticFiring>()); });
    }

    public void CloseImmediate() => gameObject.SetActive(false);
}

