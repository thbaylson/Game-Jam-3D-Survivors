using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public void SetPrefabRef(GameObject prefabRef);
    public void OnSpawn();
    public void OnDespawn();
}
