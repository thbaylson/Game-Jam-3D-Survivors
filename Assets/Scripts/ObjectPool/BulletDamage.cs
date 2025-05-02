using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour, IPoolable
{
    public float Damage { get; set; } = 10f;
    public int PierceLeft { get; set; } = 0;

    public event System.Action<BulletDamage, Collider> OnHit;

    private GameObject prefabRef;
    private HashSet<Collider> hitColliders = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null && !hitColliders.Contains(other))
        {
            health.TakeDamage(Damage);
            OnHit?.Invoke(this, other);
            
            // Make sure we only ever hit this target once with this bullet.
            hitColliders.Add(other);
            
            // Pierce check.
            PierceLeft--;
            if (PierceLeft <= 0)
            {
                OnDespawn();
            }
        }
        else
        {
            // Always despawn if a non-enemy is hit, eg. walls, trees, etc.
            OnDespawn();
        }
    }

    public void SetPrefabRef(GameObject prefabRef)
    {
        this.prefabRef = prefabRef;
    }

    public void OnSpawn() { hitColliders.Clear(); }
    public void OnDespawn() => PoolManager.Instance.Despawn(prefabRef, gameObject);
}
