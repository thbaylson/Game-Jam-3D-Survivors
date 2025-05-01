using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour, IPoolable
{
    public float damage = 10f;

    private GameObject prefabRef;

    private void OnTriggerEnter(Collider other)
    {
        // Get health component on the target
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Deal damage to the target
            health.TakeDamage(damage);
        }

        // After hit, the projectile ends
        OnDespawn();
    }

    public void SetPrefabRef(GameObject prefabRef)
    {
        this.prefabRef = prefabRef;
    }

    public void OnSpawn() { }
    public void OnDespawn() => PoolManager.Instance.Despawn(prefabRef, gameObject);
}
