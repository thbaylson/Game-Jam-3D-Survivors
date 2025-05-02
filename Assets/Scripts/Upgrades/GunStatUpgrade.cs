using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Upgrade", menuName = "Upgrades/Gun/Stats")]
public class GunStatUpgrade : Upgrade
{
    public float damageIncrease;

    [Tooltip("Input as a whole number. Ex: 10 = 10% increase, -50 = 50% decrease, etc.")]
    public float shotsPerSecondMultiplier;

    public int multiShotIncrease;
    public int pierceIncrease;

    private void OnEnable() => Type = UpgradeType.Gun;

    public override void Apply(GameObject player, GunBase gun)
    {
        if (gun == null) return;

        gun.baseDamage = Mathf.Clamp(gun.baseDamage + damageIncrease, 1, 100);
        gun.shotsPerSecond = Mathf.Clamp(gun.shotsPerSecond * HandlePercentage(shotsPerSecondMultiplier), 0.0001f, 10f);
        gun.multiShot += multiShotIncrease;
        gun.pierceCount += pierceIncrease;
    }

    private float HandlePercentage(float value)
    {
        float percentageValue = value / 100f;
        return 1f + percentageValue;
    }
}
