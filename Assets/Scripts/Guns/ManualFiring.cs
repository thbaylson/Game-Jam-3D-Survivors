using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualFiring : MonoBehaviour, IGun
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Instance.Register(bulletPrefab, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletPrefab == null) return;

        Vector3 spawnPos = bulletSpawnPoint ? bulletSpawnPoint.position : transform.position + transform.forward;
        Quaternion rotation = transform.rotation;

        PoolManager.Instance.Spawn(bulletPrefab, spawnPos, rotation);
    }
}
