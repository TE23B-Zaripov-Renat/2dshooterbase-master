using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy2Prefab;

    float timeSinceLastSpawn = 0f;
    [SerializeField] float timeBetweenSpawn = 4f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawn)
        {
            Instantiate(enemy2Prefab);
            timeSinceLastSpawn = 0;
        }
    }
}
