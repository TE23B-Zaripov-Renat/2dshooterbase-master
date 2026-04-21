using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] float enemySpeed = 4f;
    [SerializeField] GameObject boomPrefab;

    int health = 2;   

    void Start()
    {
        Vector2 newPos = new();
        newPos.x = Random.Range(-9f, 9f);
        newPos.y = 7;
        transform.position = newPos;
    }

    void Update()
    {
        Vector2 movement = Vector2.down * enemySpeed;
        transform.Translate(movement * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        health--;  

        if (health <= 0)
        {
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            GameObject player = GameObject.Find("Ship");
            player.GetComponent<PlayerController>().KilledAnEnemy();

        }
    }
}
