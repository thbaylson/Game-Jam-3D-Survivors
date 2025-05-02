using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private event System.Func<Vector3, Quaternion> OnCalcDirection;
    public event System.Action<BulletDamage> OnBulletSpawned;

    public float baseDamage = 10f;
    public float shotsPerSecond = 4f;
    public int multiShot = 1;
    public int pierceCount = 1;

    // This sets the initial direction of the bullet. There's no reason to have more than one.
    public void SetCalcDirection(System.Func<Vector3, Quaternion> handle)
    {
        OnCalcDirection = handle;
    }

    protected void Shoot()
    {
        // Do not shoot if the game is paused.
        if (Time.timeScale > 0f)
        {
            Vector3 direction = transform.forward;
            SpawnBullet(direction);
        }
    }

    private void SpawnBullet(Vector3 direction)
    {
        for (int i = 0; i < multiShot; i++)
        {
            Quaternion rotation = Quaternion.LookRotation(RotateForSpread(direction, i));
            // TODO: Is Spawn implementation the reason why we can't shoot where we're looking?
            GameObject bulletInstance = PoolManager.Instance.Spawn(
                bulletPrefab,
                bulletSpawnPoint ? bulletSpawnPoint.position : transform.position + direction,
                rotation
            );

            // Set bullet stats.
            BulletDamage bulletDamage = bulletInstance.GetComponent<BulletDamage>();
            if (bulletDamage)
            {
                bulletDamage.Damage = baseDamage;
                bulletDamage.PierceLeft = pierceCount;
            }
            OnBulletSpawned?.Invoke(bulletDamage);
        }
    }

    private Vector3 RotateForSpread(Vector3 direction, int shotIndex)
    {
        if (multiShot == 1) return direction;

        float spread = 10f;
        float offset = (shotIndex - (multiShot - 1) / 2f) * spread;
        return Quaternion.AngleAxis(offset, Vector3.up) * direction;
    }
}
