using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualFiring : GunBase
{
    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Instance.Register(bulletPrefab, 35);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }
}
