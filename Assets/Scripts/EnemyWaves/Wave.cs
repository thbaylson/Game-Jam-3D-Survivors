using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int count = 5;
    public float radius = 15f;
    public float timer = 20f;
}
