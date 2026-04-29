using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

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
            player.GetComponent<PlayerController>().ActivateDoubleShot();
            Destroy(gameObject);
        }
    }
}