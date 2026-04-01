using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float min, max;
    private bool countStarted = false;

    void Update()
    {
        while (!countStarted)
        {
            StartCoroutine(SpawnDelay());
        }
    }

    IEnumerator SpawnDelay()
    {
        countStarted = true;
        yield return new WaitForSeconds(Random.Range(min, max));
        SpawnObject();
        countStarted = false;
    }

    void SpawnObject()
    {
        GameObject enemy;
        enemy = Instantiate(spawnObject, transform.position, transform.rotation);
    }
}
