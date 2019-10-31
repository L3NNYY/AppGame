using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class baseStats : MonoBehaviour
{
    private float current_health;
    private bool gameOver = false;
    public AudioClip earthExplosion;
    public bool godmode;
    static Vector3 originalScale, largeScale;
    float damageTime;
    bool hitAnimEnding;
    public GameObject deathScreen;
    public GameObject onScreenUI;
    public GameObject deathScoreText;
    public GameObject coinsEarned;
    public GameObject highScoreText;
    public SpriteRenderer render;
    public AudioClip countUpEffect;
    public AudioClip highScoreReachedEffect;
    ClickMultiplier multiplier;
    bool scoreCountStopped = false;
    bool highScoreCounter = false;
    int maxScore, score;
    AudioSource audioSource;
    float time, counter;
    bool firstTimeLoop = true;
    void Start()
    {
        PlayerPrefs.SetInt("coins_gained", 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = countUpEffect;
        originalScale = transform.localScale;
        largeScale = transform.localScale * 1.3f;
        current_health = 100;
        multiplier = GameObject.Find("Game Wrapper").GetComponent<ClickMultiplier>();
    }
    // Update is called once per frame
    void Update()
    {
        if (HealthBarScript.health <= 0 && gameOver == false)
        {
            gameOver = true;
            maxScore = System.Convert.ToInt32(GameObject.Find("scoreText").GetComponent<Text>().text);
            StartCoroutine(Fade());

        }
        if (!scoreCountStopped && gameOver == true)
        {
            time += Time.unscaledDeltaTime;
            if(time > 0.001f){
            countUpScore(maxScore, deathScoreText.GetComponent<Text>());
            time = 0f;
            }
        }
        if (damageTime > 0)
        {
            damageTime -= Time.deltaTime * 7;
            if (hitAnimEnding)
            {
                transform.localScale = Vector3.Lerp(originalScale, largeScale, damageTime);
            }
            else
            {
                transform.localScale = Vector3.Lerp(largeScale, originalScale, damageTime);
            }
            if (damageTime <= 0 && !hitAnimEnding)
            {
                hitAnimEnding = true;
                damageTime = 1f;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy") && !godmode)
        {
            damageTime = 1f;
            hitAnimEnding = false;
            multiplier.resetStreakAndMultiplier();
            Destroy(col.gameObject);
            HealthBarScript.health -= 5;
            AudioManager.instance.PlaySound(earthExplosion, transform.position);
        }

        //StartCoroutine(Lerpin());

    }
    IEnumerator Fade()
    {
        render = GameObject.Find("blackFade").GetComponent<SpriteRenderer>();
        Color tmp = render.color;



        Time.timeScale = 0f;
        onScreenUI.SetActive(false);
        while (render.color.a < 0.8f)
        {
            tmp.a += 0.15f;
            render.color = tmp;
            yield return null;
        }

        deathScreen.SetActive(true);

        yield return null;
    }
    IEnumerator Lerpin()
    {
        float startTime = Time.time;
        float overTime = 0.15f;
        while (Time.time < startTime + overTime)
        {
            transform.localScale = Vector3.Lerp(originalScale, largeScale, (Time.time - startTime) / overTime);
            print((Time.time - startTime) / overTime);
            yield return null;
        }
        transform.localScale = largeScale;

        startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.localScale = Vector3.Lerp(largeScale, originalScale, (Time.time - startTime) / overTime);
            print((Time.time - startTime) / overTime);
            yield return null;
        }
        transform.localScale = originalScale;
    }

    void countUpScore(int maxScore, Text scoreText)
    {
        if (score >= maxScore)
        {
            if(firstTimeLoop){
            audioSource.Stop();
            audioSource.clip = highScoreReachedEffect;
            audioSource.loop = false;
            audioSource.Play(0);
            firstTimeLoop = false;
            coinsEarned.SetActive(true);
            coinsEarned.GetComponent<Text>().text = "+" + PlayerPrefs.GetInt("coins_gained") + " coins";
            }
            PlayerPrefs.SetInt("coins_gained", 0);
            if(maxScore > PlayerPrefs.GetInt("top_score") || highScoreCounter == true){
                counter += 0.02f;
                highScoreCounter = true;
                PlayerPrefs.SetInt("top_score",maxScore);
                highScoreText.SetActive(true);
                highScoreText.GetComponent<Text>().color = Color.Lerp(Color.white,Color.yellow,counter);
                coinsEarned.GetComponent<Text>().color = Color.Lerp(Color.white,Color.yellow,counter);
                if(counter >= 1.0f){
                    scoreCountStopped = true;
                }
            }
            return;
        }
        score+=5;
        scoreText.text = "" + score;
        audioSource.pitch = Mathf.Lerp(0.7f, 1.7f, ((float)score/(float)maxScore));
        audioSource.Play(0);
    }
}
