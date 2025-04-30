using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Passive/MoveSpeed")]
public class MoveSpeedUpgrade : Upgrade
{
    [Min(0)] public float speedMultiplier;

    private void OnEnable() => Type = UpgradeType.Passive;

    public override void Apply(GameObject player, IGun gun = null)
    {
        Debug.Log("MoveSpeedUpgrade applied! Speed multiplier: " + speedMultiplier);
        player.GetComponent<FirstPersonController>().MoveSpeed *= speedMultiplier;
    }
}

