using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spwnTime;
    [SerializeField]
    GameObject enemyPrefab;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spwnTime);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
