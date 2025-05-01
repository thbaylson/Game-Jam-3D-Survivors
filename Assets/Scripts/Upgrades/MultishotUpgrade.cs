using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Gun/Multishot")]
public class MultishotUpgrade : Upgrade
{
    public int multiShotIncrease;

    private void OnEnable() => Type = UpgradeType.Gun;

    public override void Apply(GameObject player, GunBase gun)
    {
        if (gun == null) return;
        gun.multiShot += multiShotIncrease;
    }
}
