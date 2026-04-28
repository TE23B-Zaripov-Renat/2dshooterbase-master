using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [SerializeField] int maxHP = 200;
    int currentHP;

    [SerializeField]
    GameObject boomPrefab;

    [SerializeField] Slider bossSlider;

    [SerializeField] GameObject enemyBoltPrefab;

    float shootTimer = 0f;
    [SerializeField] float timeBetweenShots = 1.5f;

    void Start()
    {
        bossSlider = GameObject.Find("BossHP").GetComponent<Slider>();



        currentHP = maxHP;

        bossSlider.gameObject.SetActive(true);
        bossSlider.maxValue = maxHP;
        bossSlider.value = currentHP;

        transform.position = new Vector2(0, 3);
    }

    void Update()
    {

        float moveX = Mathf.Sin(Time.time) * 3f;
        transform.position = new Vector2(moveX, transform.position.y);


        shootTimer += Time.deltaTime;

        if (shootTimer > timeBetweenShots)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(enemyBoltPrefab, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(enemyBoltPrefab, transform.position, Quaternion.Euler(0, 0, 150));
        Instantiate(enemyBoltPrefab, transform.position, Quaternion.Euler(0, 0, 210));
    }

    public void SetSlider(Slider slider)
    {
        bossSlider = slider;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            currentHP--;
            bossSlider.value = currentHP;

            Destroy(collision.gameObject);

            if (currentHP <= 0)
            {
                bossSlider.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        GameObject player = GameObject.Find("Ship");
    }
    
}