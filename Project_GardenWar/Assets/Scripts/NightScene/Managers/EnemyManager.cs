using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public ObjectPool enemyPool;
    public float timeSpawn;
    public GameObject spawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            enemyPool.ObjectAwake(spawn.transform.position);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
