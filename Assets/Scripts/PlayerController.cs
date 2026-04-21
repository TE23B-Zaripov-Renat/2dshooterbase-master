using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] GameObject bossPrefab;
    bool bossSpawned = false;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject boltPrefab;

    float timeSinceLastShot = 0;
    [SerializeField] float timeBetweenShots = 0.5f;

    float currentHP = 0;
    [SerializeField] float maxHP = 3;

    [SerializeField] Slider hpSlider;

    [SerializeField] TMP_Text killsText;
    [SerializeField] TMP_Text coinsText;

    [SerializeField] float currentkills = 0;
    float currentcoins = 0;

    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;

        hpSlider.gameObject.SetActive(false);

        killsText.text = "Kills: " + currentkills;
        coinsText.text = "Coins: " + currentcoins;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputX + Vector2.up * inputY;
        transform.Translate(movement * speed * Time.deltaTime);

        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            AudioSource speaker = GetComponent<AudioSource>();
            speaker.Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            currentHP--;
            hpSlider.value = currentHP;
            // hpSlider.gameObject.SetActive(true);

            if (currentHP <= 0)
            {
                SceneManager.LoadScene("GAMEOVER");
            }
        }
    }

    public void KilledAnEnemy()
    {
        currentkills++;
        killsText.text = "Kills: " + currentkills;

        if (currentkills >= 1)
    {
        hpSlider.gameObject.SetActive(true);
    }

            if (currentkills >= 1 && !bossSpawned)
        {
            Instantiate(bossPrefab, new Vector2(0, 7), Quaternion.identity);
            bossSpawned = true;
        }
    
    }

    public void CollectedCoin()
    {
        currentcoins++;
        coinsText.text = "Coins: " + currentcoins;
    }

    public void CollectedHeal()
    {
        currentHP++;

        if (currentHP > maxHP)
            currentHP = maxHP;

        hpSlider.value = currentHP;
    }
}