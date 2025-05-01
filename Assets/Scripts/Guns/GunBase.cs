using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float baseDamage = 10f;
    public float shotsPerSecond = 4f;
    public int multiShot = 1;
    public int pierceCount = 0;

    protected void Shoot()
    {
        // Do not shoot if the game is paused.
        if (Time.timeScale > 0f)
        {
            SpawnBullet(transform.forward);
        }
    }

    protected void SpawnBullet(Vector3 dir)
    {
        for (int i = 0; i < multiShot; i++)
        {
            Quaternion rot = Quaternion.LookRotation(RotateForSpread(dir, i));
            var bullet = PoolManager.Instance.Spawn(bulletPrefab,
                          bulletSpawnPoint ? bulletSpawnPoint.position : transform.position + dir,
                          rot);

            // Set bullet stats.
            var b = bullet.GetComponent<BulletDamage>();
            if (b)
            {
                b.damage = baseDamage;
                //b.PierceLeft = pierceCount;
            }
        }
    }

    protected Vector3 RotateForSpread(Vector3 dir, int shotIndex)
    {
        if (multiShot == 1) return dir;
        float spread = 10f;
        float offset = (shotIndex - (multiShot - 1) / 2f) * spread;
        return Quaternion.AngleAxis(offset, Vector3.up) * dir;
    }
}
