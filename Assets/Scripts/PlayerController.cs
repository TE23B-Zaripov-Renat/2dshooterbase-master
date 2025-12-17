using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float speed = 0.02f;
    [SerializeField]
    GameObject boltPrefab;


    float timeSinceLastShot = 0;
    [SerializeField]
    float timeBetweenShots = 0.5f;

    float currentHP = 0;
    [SerializeField]
    float maxHP = 3;

    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    TMP_Text killsText;

    [SerializeField]
    TMP_Text coinsText;


    [SerializeField]
    float currentkills = 0;
    float currentcoins = 0;
    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;

        killsText.text = "Kills: " + currentkills;
        coinsText.text = "Coins:" + currentcoins;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputX
                         + Vector2.up * inputY;
        transform.Translate(movement * speed * Time.deltaTime);

        //--------------------------------------------------------------------
        //Skjuta
        //--------------------------------------------------------------------

        // timeBetweenShots = timeBetweenShots + Time.deltaTime;
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
        if (collision.gameObject.tag == "enemy")
        {
            currentHP--;
            hpSlider.value = currentHP;

            if (currentHP <= 0)
            {
                print("GAME OVER");
                SceneManager.LoadScene("GAMEOVER");
            }

        }
    }

    public void KilledAnEnemy()
    {
        currentkills++;
        killsText.text = "Kills: " + currentkills;
        print(currentkills);
    }
    public void CollectedCoin()
    {
        currentcoins++;
        coinsText.text = "Coins:" + currentcoins;
        print(currentcoins);
    }
    public void CollectedHeal()
    {
        currentHP++;

        if (currentHP > maxHP)
            currentHP = maxHP;
          hpSlider.value = currentHP;
}

}

