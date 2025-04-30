using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Database")]
public class UpgradeDatabase : ScriptableObject
{
    public List<Upgrade> allUpgrades;

    // TODO: Remove magic number
    public List<Upgrade> RollThree()
    {
        var pool = new List<Upgrade>(allUpgrades);
        var result = new List<Upgrade>();
        for (int i = 0; i < 3; i++)
        {
            var pick = pool[Random.Range(0, pool.Count)];
            result.Add(pick);
            pool.Remove(pick);
        }
        return result;
    }
}

