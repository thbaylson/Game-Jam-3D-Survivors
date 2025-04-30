using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Gun/DamageUp")]
public class GunDamageUpgrade : Upgrade
{
    public float damageIncrease;

    private void OnEnable() => Type = UpgradeType.Gun;

    public override void Apply(GameObject player, IGun gun)
    {
        Debug.Log("GunDamageUpgrade applied! Damage increase: " + damageIncrease);
        //if (gun == null) return;
        //gun.BaseDamage += damageIncrease;
    }
}

