using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    float CoinSpeed = 3;
    void Start()
    {
        Vector2 newPos = new();
        newPos.x = Random.Range(-9f, 9f);
        newPos.y = 7;
        transform.position = newPos;
        
    }


    void Update()
    {
        Vector2 movement = Vector2.down * CoinSpeed;
        transform.Translate(movement * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        }
         void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Ship")
            {
                GameObject player = GameObject.Find("Ship");
                player.GetComponent<PlayerController>().CollectedCoin();
                Destroy(this.gameObject);
            }
        }
    }
}
