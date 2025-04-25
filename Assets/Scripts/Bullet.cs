using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float Speed = 15f;
    public float Lifetime = 2f;
    private float lifeTimer;

    private void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    private IEnumerator UpdateCoroutine()
    {
        while (lifeTimer < Lifetime)
        {
            // Move projectile forward
            transform.position += transform.forward * Speed * Time.deltaTime;
            lifeTimer += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Lifetime expired
        Destroy(gameObject);
    }

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
        Destroy(gameObject);
    }
}
