
using UnityEngine;

public class boltcontroller : MonoBehaviour
{
    [SerializeField]
    float boltSpeed = 4;

    void Start()
    // Lösning skotten försvinner 1
    {
        // Destroy(this.gameObject, 3);
    }

    void Update()
    {
        Vector2 movement = Vector2.up * boltSpeed;
        transform.Translate(movement * Time.deltaTime);

        //Lösning skotten försvinner 2
        // if (transform.position.y > 6)
        // {
        //     Destroy(this.gameObject);
        // }

        // Lösning skotten försvinner 3
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(this.gameObject);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
        Destroy(this.gameObject); 
        }
    }
}
