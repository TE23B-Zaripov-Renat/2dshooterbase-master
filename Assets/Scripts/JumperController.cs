using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField]
    float jumpforce = 2;

    [SerializeField]
    float speed = 3;

    [SerializeField]
    GameObject groundChecker;

    [SerializeField]
    LayerMask groundLayer;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = Vector2.right * inputX;
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void FixedUpdate() // 30ggr/sek
    {
        bool isGrounded = Physics2D.OverlapCircle(
            groundChecker.transform.position,
            .1f,
            groundLayer
        );
        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
}
