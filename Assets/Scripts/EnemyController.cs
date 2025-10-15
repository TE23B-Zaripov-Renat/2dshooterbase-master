using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]

    float EnemySpeed = 4;

    [SerializeField]
    GameObject boomPrefab;


    void Start()
    {
        Vector2 newPos = new();
        newPos.x = Random.Range(-9f, 9f);
        newPos.y = 7;

        transform.position = newPos;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.down * EnemySpeed;
        transform.Translate(movement * Time.deltaTime);

       if (transform.position.y < -Camera.main.orthographicSize - 1)
    {
      Destroy(this.gameObject);
    }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        GameObject player = GameObject.Find("Ship");
        player.GetComponent<PlayerController>().KilledAnEnemy();
    }
}
