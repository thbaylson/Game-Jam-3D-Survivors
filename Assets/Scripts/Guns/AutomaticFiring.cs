using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFiring : GunBase
{
    // TODO: Implement https://github.com/thbaylson/Unity-Third-Person-Combat/commit/306633699d5a92031d1240833c5a821857c926cc
    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Instance.Register(bulletPrefab, 35);
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
