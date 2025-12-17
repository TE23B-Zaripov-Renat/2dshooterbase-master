using UnityEngine;

public class HealController : MonoBehaviour
{
    [SerializeField] float healSpeed = 4f;

    void Update()
    {
        transform.Translate(Vector2.down * healSpeed * Time.deltaTime);

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
            player.GetComponent<PlayerController>().CollectedHeal();
            Destroy(gameObject);
        }
    }
}
