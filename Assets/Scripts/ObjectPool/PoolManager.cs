using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    private Dictionary<GameObject, Pool> pools = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Register(GameObject prefab, int preload= 0, Transform parent= null)
    {
        if (pools.ContainsKey(prefab)) return;

        pools[prefab] = new Pool(prefab, preload, parent ?? transform);
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!pools.ContainsKey(prefab)) Register(prefab, 0);

        GameObject go = pools[prefab].Spawn();
        go.transform.SetPositionAndRotation(position, rotation);
        return go;
    }

    /// <summary>
    /// Despawn the instance of the prefab if it belongs to a pool, otherwise just destroy it.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="instance"></param>
    public void Despawn(GameObject prefab, GameObject instance)
    {
        if (pools.TryGetValue(prefab, out Pool pool))
        {
            pool.Despawn(instance);
        }
        else
        {
            Destroy(instance);
        }
    }
}
