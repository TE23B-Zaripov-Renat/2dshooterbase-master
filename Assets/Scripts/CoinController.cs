using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] float coinSpeed = 4f;

    void Update()
    {
        transform.Translate(Vector2.down * coinSpeed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            GameObject player = GameObject.Find("Ship");
            player.GetComponent<PlayerController>().CollectedCoin();
            Destroy(gameObject);
        }
    }
}
