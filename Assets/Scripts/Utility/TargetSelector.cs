using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetSelector
{
    public static Transform FindNearestEnemy(Vector3 origin, float maxRange)
    {
        var enemies = PoolManager.Instance.GetAllActive<PlayerDetectorAttackTrigger>();
        float bestDistSqr = maxRange * maxRange;
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = (enemy.transform.position - origin).sqrMagnitude;
            if (distance < bestDistSqr)
            {
                bestDistSqr = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }
}
