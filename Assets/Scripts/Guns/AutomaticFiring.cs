using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFiring : GunBase
{
    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Instance.Register(bulletPrefab, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= 1f / shotsPerSecond)
        {
            shootTimer = 0f;
            Shoot();
        }
    }
}
