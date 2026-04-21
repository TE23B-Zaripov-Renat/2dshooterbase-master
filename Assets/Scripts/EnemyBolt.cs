using UnityEngine;

public class EnemyBolt : MonoBehaviour
{
    [SerializeField] float speed = 4;

    void Update()
    {
        // Skillnaden är HÄR:
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        }
    }
}