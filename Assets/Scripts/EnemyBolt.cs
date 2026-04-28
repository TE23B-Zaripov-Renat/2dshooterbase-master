using UnityEngine;

public class EnemyBolt : MonoBehaviour
{
    [SerializeField] float speed = 4;

    void Update()
    {
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        }
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Ship"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.TakeDamage();

            Destroy(gameObject);
        }
    }
}