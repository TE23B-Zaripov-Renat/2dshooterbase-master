using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    GameObject enemyPrefab;

    float timeSinceLastSpawn = 0;
    [SerializeField]
    float timeBetweenSpawn = 3f;

    void Start()
    {

    }


    void Update()
    {

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawn)
        {
            Instantiate(enemyPrefab);

            timeSinceLastSpawn = 0;
        }
    }
}
