using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFiring : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 0.25f;
    public Transform bulletSpawnPoint;

    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            shootTimer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        Vector3 spawnPos = bulletSpawnPoint ? bulletSpawnPoint.position : transform.position + transform.forward;
        Quaternion rotation = transform.rotation;

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, rotation);
    }
}
