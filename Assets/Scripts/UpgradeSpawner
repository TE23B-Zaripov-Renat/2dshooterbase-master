using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    [SerializeField] GameObject upgradePrefab;
    [SerializeField] float timeBetweenSpawns = 5f;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns)
        {
            SpawnUpgrade();
            timer = 0f;
        }
    }

    void SpawnUpgrade()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9f, 9f), 4f);
        Instantiate(upgradePrefab, spawnPos, Quaternion.identity);
    }
}