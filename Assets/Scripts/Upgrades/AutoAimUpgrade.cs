using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoAim", menuName = "Upgrades/Gun/AutoAim")]
public class AutoAimUpgrade : Upgrade
{
    public float range = 20f;

    public override void Apply(GameObject player, GunBase gun = null)
    {
        System.Func<Vector3, Quaternion> handle = (origin) =>
        {
            var nearestEnemy = TargetSelector.FindNearestEnemy(origin, range);
            if(nearestEnemy == null)
            {
                return Quaternion.identity;
            }

            var direction = (nearestEnemy.position - origin).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            return rotation;
        };

        gun.SetCalcDirection(handle);
    }
}
