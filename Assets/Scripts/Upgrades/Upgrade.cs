using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType { Passive, Gun }

public abstract class Upgrade : ScriptableObject
{
    public string upgradeName;
    [TextArea] public string description;
    public Sprite icon;
    public UpgradeType Type;

    // Called after the player confirms the upgrade.
    public abstract void Apply(GameObject player, GunBase gun = null);
}

