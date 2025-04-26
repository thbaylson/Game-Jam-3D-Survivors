using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public Queue<GameObject> queue = new();
    public GameObject prefab;
    public Transform parent;

    public Pool(GameObject prefab, int preload, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;

        for(int i = 0; i < preload; i++)
        {
            queue.Enqueue(CreateInstance());
        }
    }

    public GameObject Spawn()
    {
        GameObject go = queue.Count > 0 ? queue.Dequeue() : CreateInstance();
        go.SetActive(true);
        // This will look for components on the gameobject itself as well as any children.
        foreach(IPoolable poolable in go.GetComponentsInChildren<IPoolable>())
        {
            poolable.OnSpawn();
            poolable.SetPrefabRef(prefab);
        }

        return go;
    }

    public void Despawn(GameObject go)
    {
        go.SetActive(false);
        queue.Enqueue(go);
    }

    private GameObject CreateInstance()
    {
        GameObject go = Object.Instantiate(prefab, parent);
        go.SetActive(false);
        return go;
    }
}
