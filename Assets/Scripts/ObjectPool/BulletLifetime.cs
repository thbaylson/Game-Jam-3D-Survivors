using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifetime : MonoBehaviour, IPoolable
{
    public float life = 3f;
    float timer;
    GameObject prefabRef;

    //void Awake() => prefabRef = transform.root.gameObject;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= life) OnDespawn();
    }

    public void SetPrefabRef(GameObject prefabRef)
    {
        this.prefabRef = prefabRef;
    }

    public void OnSpawn() => timer = 0f;
    public void OnDespawn() => PoolManager.Instance.Despawn(prefabRef, gameObject);
}
