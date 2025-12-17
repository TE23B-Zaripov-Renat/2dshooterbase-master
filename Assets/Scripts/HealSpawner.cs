using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject healPrefab;
    [SerializeField]
    float timeBetweenSpawns = 2f;

     float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns)
        {
            SpawnHeal();
            timer = 0f;
        }
    }

    void SpawnHeal()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9f, 9f), 4f);
        Instantiate(healPrefab, spawnPos, Quaternion.identity);
    }
}
